using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumFramework.TestSetup;
using AssetManagement.Resources;
using AssetManagement.Services;

namespace AssetManagement.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToURL(Resources.Constants.BASE_URL);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}