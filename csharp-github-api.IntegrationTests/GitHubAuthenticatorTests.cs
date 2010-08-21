﻿using NUnit.Framework;
using RestSharp;

namespace csharp_github_api.IntegrationTests
{
    [TestFixture]
    public class GitHubAuthenticatorTests
    {
        private SecretsHandler _secretsHandler;
        private RestRequest _restRequest;

        [SetUp]
        public void Setup()
        {
            _secretsHandler = new SecretsHandler(@"C:\secretpasswordfile.xml");

            _restRequest = new RestRequest
            {
                Resource = "/user/show/sgrassie"
            };
        }

        [Test]
        public void MakeAuthenticatedRequest()
        {
            var client = new RestClient
                             {
                                 BaseUrl = "http://github.com/api/v2/json",
                                 Authenticator = new GitHubAuthenticator(_secretsHandler.Username, _secretsHandler.Password, false)
                             };

            var response = client.Execute(_restRequest);

            Assert.That(response.Content, Is.StringContaining("total_private_repo_count"));
        }
    }
}