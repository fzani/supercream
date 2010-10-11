using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Web;
using System.Web.UI.WebControls;
using SP.Mvp;
using SP.Mvp.Repository;
using WebFormsMvp;

public class EditBundledOrderPresenter : Presenter<IEditBundledOrderView>
{
    private IRepository<Offer> _linqRepository;

    private List<Offer> _offers = new List<Offer>
                                        {
                                            new Offer
                                                {
                                                    ID = 1,
                                                    Name = "Blue Offer",
                                                    ValidFrom = DateTime.Now,
                                                    ValidTo = DateTime.Now

                                                },
                                                new Offer
                                                {
                                                    ID = 2,
                                                    Name = "Green Offer",
                                                    ValidFrom = DateTime.Now,
                                                    ValidTo = DateTime.Now

                                                },
                                                new Offer
                                                {
                                                    ID = 3,
                                                    Name = "Grey Offer",
                                                    ValidFrom = DateTime.Now,
                                                    ValidTo = DateTime.Now

                                                }
                                        };

    public EditBundledOrderPresenter()
        : this(null)
    {

    }

    public EditBundledOrderPresenter(IEditBundledOrderView view)
        : this(view, null)
    {
        // subscribe to the view's events :
        // in this case the Load event
        // View.Load += View_Load;
        var bundledDataContext = new BundledOffersDataContext(Connection.SuperCreamConnection);
        _linqRepository = _linqRepository ?? new LinqRepository<Offer>(bundledDataContext);

        View.GettingOffers += View_GettingOffers;
        //View.GettingOffersTotalCount += View_GettingOffersTotalCount;
        //View.UpdatingOffer += View_UpdatingOffer;
        //View.InsertingOffer += View_InsertingOffer;
        //View.DeletingOffer += View_DeletingOffer;
    }

    public EditBundledOrderPresenter(IEditBundledOrderView view, IRepository<SP.Mvp.Offer> offerRepository)
        : base(view)
    {

    }

    public override void ReleaseView()
    {
        // clean up the delegate by detaching it
        View.Load -= View_Load;
        View.GettingOffers -= View_GettingOffers;
        //View.UpdatingOffer -= View_UpdatingOffer;
        //View.InsertingOffer -= View_InsertingOffer;
        //View.DeletingOffer -= View_DeletingOffer;
    }

    void View_GettingOffers(object sender, GettingOfferEventArgs e)
    {
        View.Model.Offers = _offers;
        //View.Model.Offers = _linqRepository.FindAll()
        //    .Skip(e.StartRowIndex * e.MaximumRows)
        //    .Take(e.MaximumRows);
    }

    void View_GettingOffersTotalCount(object sender, EventArgs e)
    {
        View.Model.TotalCount = 3;
        // View.Model.TotalCount = _linqRepository.FindAll().Count();
    }

    void View_UpdatingOffer(object sender, UpdateOfferEventArgs e)
    {
        // _linqRepository.Save(e.Offer, e.OriginalOffer);
    }

    void View_InsertingOffer(object sender, EditOfferEventArgs e)
    {
        //_linqRepository.Save(e.Offer, null);
    }

    void View_DeletingOffer(object sender, EditOfferEventArgs e)
    {
        // TODO: Delete Offer
    }


    // the core logic of the app where the Model is instantiated, fetched
    // and binded to the view
    private void View_Load(object sender, EventArgs e)
    {
        //    var context = new BundledOffersDataContext(Connection.SuperCreamConnection);
        //    _linqRepository = _linqRepository ?? new LinqRepository<Offer>(context);

        //    AsyncManager.RegisterAsyncTask(
        //        (asyncSender, ea, callback, state) => // Begin
        //        {
        //            return _linqRepository.BeginFindAll(callback, state);
        //        },
        //            result => // End
        //            {
        //                var offers = _linqRepository.EndFindAll(result);
        //                if (offers != null)
        //                {
        //                    View.Model.Offers = offers;
        //                    View.Model.TotalCount = offers.Count();
        //                }
        //            },
        //        result => { } // Timeout
        //        , null, false);

        //    AsyncManager.ExecuteRegisteredAsyncTasks();
        //}


        //    View.GettingOffers += View_GettingOffers;
        //        View.GettingOffersTotalCount += View_GettingOffersTotalCount;
        //        View.UpdatingOffer += View_UpdatingOffer;
        //        View.InsertingOffer += View_InsertingOffer;
        //        View.DeletingOffer += View_DeletingOffer;
        //    }

        //    void View_GettingOffers(object sender, GettingOfferEventArgs e)
        //    {
        //        View.Model.Offers = Offers.FindAll()
        //            .Skip(e.StartRowIndex * e.MaximumRows)
        //            .Take(e.MaximumRows);
        //    }

        //    void View_GettingOffersTotalCount(object sender, EventArgs e)
        //    {
        //        View.Model.TotalCount = Offers.FindAll().Count();
    }
}

