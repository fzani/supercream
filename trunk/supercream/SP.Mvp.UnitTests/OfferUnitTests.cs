using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace SP.Mvp.UnitTests
{
    public class OfferUnitTests
    {
        #region Setup

        [SetUp]
        public void Init()
        {
            //_mockRepository = new MockRepository();
            //_versionService = _mockRepository.DynamicMock<Versions>();
            //_dwsService = _mockRepository.DynamicMock<Dws>();
            //_listService = _mockRepository.DynamicMock<Lists>();
            //_copyService = _mockRepository.DynamicMock<Copy>();

            //_filePersistance = _mockRepository.StrictMock<IFilePersistence>();
            //_configurationSettings = _mockRepository.DynamicMock<IConfigurationSettings>();
        }

        #endregion

        #region Upload File Tests

        [Test]
        public void UploadFileFromSourceFile()
        {
            //using (_mockRepository.Ordered())
            //{
            //    var configurationSettings = MockRepository.GenerateStub<IConfigurationSettings>();
            //    configurationSettings["Test"] = "http://localhost:8181/myservice/";

            //    Expect.Call(_filePersistance.ReadBytesFromTextFile(@"C:\Test\South")).Return(new byte[1024]);

            //    FieldInformation[] fieldInformation;
            //    CopyResult[] copyResults;
            //    byte[] fileBytes;
            //    string[] destinationUrl = SetupCopyIntoItems(out fieldInformation, out fileBytes);

            //    Expect.Call(_copyService.CopyIntoItems(@"C:\Test\South", destinationUrl, fieldInformation, fileBytes,
            //                                           out copyResults))
            //        .IgnoreArguments()
            //        .Return(0);
            //}

            //_mockRepository.ReplayAll();

            //var mossServiceAdapter =
            //    new MossServiceAdapter(_configurationSettings, _versionService, _dwsService, _listService, _copyService, _filePersistance);

            //var uploadFileInfoInputXml = ApplicationResource.UploadFileInfoInputXML;

            //var result = mossServiceAdapter.UploadFile(uploadFileInfoInputXml);
            //Assert.AreEqual(result, ApplicationResource.ResultOK);

            ////_mockRepository.VerifyAll();
        }

        #endregion
    }
}
