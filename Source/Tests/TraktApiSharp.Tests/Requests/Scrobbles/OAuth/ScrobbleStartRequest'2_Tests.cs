﻿namespace TraktApiSharp.Tests.Requests.Scrobbles.OAuth
{
    using FluentAssertions;
    using System;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Scrobbles.OAuth;
    using Xunit;

    [Category("Requests.Scrobbles.OAuth")]
    public class ScrobbleStartRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public string HttpContentAsString => throw new NotImplementedException();

            public HttpContent ToHttpContent() => throw new NotImplementedException();

            public void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Has_Valid_UriTemplate()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.UriTemplate.Should().Be("scrobble/start");
        }

        [Fact]
        public void Test_ScrobbleStartRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new ScrobbleStartRequest<int, RequestBodyMock>();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
