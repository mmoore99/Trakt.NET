﻿namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class ASyncPostRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public string HttpContentAsString => throw new NotImplementedException();

            public HttpContent ToHttpContent() => throw new NotImplementedException();

            public void Validate() => throw new NotImplementedException();
        }

        internal class SyncPostRequestMock : ASyncPostRequest<int, RequestBodyMock>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncPostRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ASyncPostRequest_2_Returns_Valid_UriPathParameters()
        {
            var request = new SyncPostRequestMock();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();
        }
    }
}
