using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace SuperCreamAdmin.Controllers
{
    public class ManageUsersController : Controller
    {
        IMembershipService MembershipService
        {
            get;
            set;
        }

        public ManageUsersController()
        {
            MembershipService = new AccountMembershipService();
        }

        //
        // GET: /ManageUsers/

        public ActionResult Index()
        {
            return View(Membership.GetAllUsers());
        }

        //
        // GET: /ManageUsers/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public RedirectToRouteResult Delete(string userName)
        {
            Membership.DeleteUser(userName);
            return RedirectToAction("Index");
        }

        //
        // GET: /ManageUsers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageUsers/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManageUsers/Edit/5

        public ActionResult Edit(string userName)
        {
            return View(Membership.GetUser(userName));
        }

        //
        // POST: /ManageUsers/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string userName,
            string currentPassword,
            string newPassword,
            string confirmPassword,
            string submitButton)
        {
            if (submitButton == "Cancel")
            {
                return RedirectToAction("Index", "ManageUsers");
            }

            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword))
            {
                return View(Membership.GetUser(userName));
            }

            try
            {
                if (MembershipService.ChangePassword(userName, currentPassword, newPassword))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                    return View(Membership.GetUser(userName));
                }
            }
            catch
            {
                ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                return View(Membership.GetUser(userName));
            }
        }

        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (String.IsNullOrEmpty(currentPassword))
            {
                ModelState.AddModelError("currentPassword", "You must specify a current password.");
            }
            if (newPassword == null)
            {
                ModelState.AddModelError("newPassword",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a new password"));
            }

            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }

            return ModelState.IsValid;
        }


        public class AccountMembershipService : IMembershipService
        {
            private MembershipProvider _provider;

            public AccountMembershipService()
                : this(null)
            {
            }

            public AccountMembershipService(MembershipProvider provider)
            {
                _provider = provider ?? Membership.Provider;
            }

            public int MinPasswordLength
            {
                get
                {
                    return _provider.MinRequiredPasswordLength;
                }
            }

            public bool ValidateUser(string userName, string password)
            {
                return _provider.ValidateUser(userName, password);
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email)
            {
                MembershipCreateStatus status;
                _provider.CreateUser(userName, password, email, null, null, true, null, out status);
                return status;
            }

            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
        }
    }
}
