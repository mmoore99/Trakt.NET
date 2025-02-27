﻿namespace TraktNet.Modules.Tests.TraktSearchModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Search")]
    public partial class TraktSearchModule_Tests
    {
        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUriMulitpleTypes,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetTextQueryUri}&{FILTER}",
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetTextQueryUriMulitpleTypes}&{FILTER}",
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, null,
                                                             EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null, null,
                                                             pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER,
                                                             EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_Complete_With_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_Complete_With_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
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
        public async Task Test_TraktSearchModule_GetTextQueryResults_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, statusCode);

            try
            {
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(default, null);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Unspecified, TEXT_QUERY);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
