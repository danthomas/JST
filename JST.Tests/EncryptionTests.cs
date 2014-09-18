using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using JST.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JST.Tests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void Test()
        {
            const string password = "burpee";

            string hash = new AccountBusiness(null, null, null, null).HashPassword(password);

        }


    }
}
