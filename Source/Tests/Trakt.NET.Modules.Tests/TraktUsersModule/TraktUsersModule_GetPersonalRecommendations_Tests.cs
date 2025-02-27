﻿namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_PERSONAL_RECOMMENDATIONS_URI = $"users/{USERNAME}/recommendations";

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_PERSONAL_RECOMMENDATIONS_URI,
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response = await client.Users.GetPersonalRecommendationsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}",
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}",
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?extended={EXTENDED_INFO}",
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?page={PAGE}",
                USER_RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}",
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                USER_RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?page={PAGE}",
                USER_RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_RecommendationType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}",
                USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                USER_RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?page={PAGE}",
                USER_RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                USER_RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Users.GetPersonalRecommendationsAsync(USERNAME, RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PERSONAL_RECOMMENDATIONS_URI, statusCode);

            try
            {
                await client.Users.GetPersonalRecommendationsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetPersonalRecommendations_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_PERSONAL_RECOMMENDATIONS_URI, USER_RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktRecommendation>>> act = () => client.Users.GetPersonalRecommendationsAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Users.GetPersonalRecommendationsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Users.GetPersonalRecommendationsAsync("user name");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
