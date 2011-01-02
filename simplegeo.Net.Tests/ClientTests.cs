// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientTests.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   This is a test class for Client.cs and is intended
//   to contain all ClientTests Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hammock.Authentication.OAuth;

namespace SimpleGeo.Net.Tests
{
    
    
    /// <summary>
    ///This is a test class for Client.cs and is intended
    ///to contain all ClientTests Unit Tests
    ///</summary>
    [TestClass()]
    public class ClientTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Client Constructor
        ///</summary>
        [TestMethod()]
        public void ClientConstructorTests()
        {
            OAuthCredentials oauthCredentials = null; // TODO: Initialize to an appropriate value
            string authority = string.Empty; // TODO: Initialize to an appropriate value
            string versionPath = string.Empty; // TODO: Initialize to an appropriate value
            Client target = new Client(oauthCredentials, authority, versionPath);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Client Constructor
        ///</summary>
        [TestMethod()]
        public void ClientConstructorTests1()
        {
            string oauthKey = string.Empty; // TODO: Initialize to an appropriate value
            string oauthSecret = string.Empty; // TODO: Initialize to an appropriate value
            string authority = string.Empty; // TODO: Initialize to an appropriate value
            string versionPath = string.Empty; // TODO: Initialize to an appropriate value
            Client target = new Client(oauthKey, oauthSecret, authority, versionPath);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
