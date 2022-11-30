using NUnit.Framework;
using NUnit.Framework.Internal;
using AssetManagement.TestSetup;
using AssetManagement.Common;

namespace AssetManagement.TestCases
{
    [TestFixture]
    public class FT63_ManageUserTest : ProjectNUnitTestSetup
    {
        [Test]
        public void LoginAsAdminAndViewUserList()
        {
            CommonFlow.LoginAsAdminFlow(driver);
        }


    }
}