using JST.DataAccess;
using JST.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JST.Tests.DataAccess
{
    [TestClass]
    public class AccountDataServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            AccountDataService accountDataService = new AccountDataService();

            Account account = accountDataService.SelectByAccountId(1);


        }
    }
}
