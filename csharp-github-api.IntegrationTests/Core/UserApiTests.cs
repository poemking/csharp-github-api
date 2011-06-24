﻿using NUnit.Framework;
using csharp_github_api.IntegrationTests.Bootstrap;
using NUnit.Framework;
using StructureMap;

namespace csharp_github_api.IntegrationTests
namespace csharp_github_api.IntegrationTests.Core
{
    [TestFixture]
    public class UserApiTests
    {
        private Github _github;

        [TestFixtureSetUp]
        public void Setup()
        {
            _
            Bootstrapper.Bootstrap();
            _github = ObjectFactory.GetInstance<Github>();
        }

        [Test]
        public void GetUser_shouldReturnDeserialisedUserObject()
        {
            var user = _github.User.GetUser("sgrassie");

            Assert.That(user.Name, Is.StringMatching("Stuart Grassie"));
        }

        [Test]
        public void GetFollowing_fromUser_shouldReturnSomeData()
        {
            var user = _github.User.GetUser("sgrassie");

            var following = user.Following;

            Assert.That(following, Is.Not.Empty);
            Assert.That(following, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetUser_returns_validUserObject()
        {
            var user = _github.User.GetUser("defunkt");

            Assert.That(user.Name, Is.StringMatching("Chris Wanstrath"));
        }
    }
}