// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientTests.cs" company="Jörg Battermann">
//   Copyright © Jörg Battermann 2011
// </copyright>
// <summary>
//   This is a test class for <see cref="SimpleGeo.Net.Client"/> and is intended
//   to contain all corresponding Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hammock.Authentication.OAuth;

namespace SimpleGeo.Net.Tests
{
    using System;

    /// <summary>
    ///This is a test class for <see cref="SimpleGeo.Net.Client"/> and is intended
    ///to contain all corresponding Unit Tests
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
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClientConstructorThrowsArgumentNullExceptionOnNullOAuthCredentials()
        {
            OAuthCredentials oauthCredentials = null;
            Client target = new Client(oauthCredentials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ClientConstructorThrowsArgumentNullExceptionOnEmptyOAuthToken()
        {
            string oauthToken = string.Empty;
            string oauthSecret = "Some OAuth Secret";
            Client target = new Client(oauthToken, oauthSecret);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ClientConstructorThrowsArgumentNullExceptionOnEmptyOAuthSecret()
        {
            string oauthToken = "Some OAuth Token";
            string oauthSecret = string.Empty;
            Client target = new Client(oauthToken, oauthSecret);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ClientConstructorThrowsArgumentNullExceptionOnEmptyAuthorityUrl()
        {
            string oauthToken = "Some OAuth Token";
            string oauthSecret = "Some OAuth Secret";
            string authority = string.Empty;
            Client target = new Client(oauthToken, oauthSecret, authority);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ClientConstructorThrowsArgumentNullExceptionOnEmptyApiVersion()
        {
            string oauthToken = "Some OAuth Token";
            string oauthSecret = "Some OAuth Secret";
            string apiVersion = string.Empty;
            Client target = new Client(oauthToken, oauthSecret, versionPath:apiVersion);
        }

        [TestMethod]
        public void ClientConstructorTest()
        {
            string oauthToken = "Some OAuth Token";
            string oauthSecret = "Some OAuth Secret";
            string apiVersion = "2.0";
            string authorityUrl = "http://api.someurl.com";

            Client target = new Client(oauthToken, oauthSecret, authorityUrl, apiVersion);
            Assert.IsNotNull(target);
            Assert.IsNotNull(target.Credentials);
            Assert.AreEqual(((OAuthCredentials)target.Credentials).ConsumerKey, oauthToken);
            Assert.AreEqual(((OAuthCredentials)target.Credentials).ConsumerSecret, oauthSecret);
            Assert.AreEqual(target.Authority, authorityUrl);
            Assert.AreEqual(target.VersionPath, apiVersion);
        }

        public void GetFeatureByHandleTest()
        {
                    
        }
    }
}
