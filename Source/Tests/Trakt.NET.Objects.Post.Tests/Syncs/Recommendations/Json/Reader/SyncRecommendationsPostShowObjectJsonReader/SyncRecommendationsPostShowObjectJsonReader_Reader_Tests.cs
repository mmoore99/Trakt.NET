﻿namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.JsonReader")]
    public partial class SyncRecommendationsPostShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncRecommendationsPostShow.Should().NotBeNull();
            traktSyncRecommendationsPostShow.Title.Should().Be("Breaking Bad");
            traktSyncRecommendationsPostShow.Year.Should().Be(2008);
            traktSyncRecommendationsPostShow.Ids.Should().NotBeNull();
            traktSyncRecommendationsPostShow.Ids.Trakt.Should().Be(1U);
            traktSyncRecommendationsPostShow.Ids.Slug.Should().Be("breaking-bad");
            traktSyncRecommendationsPostShow.Ids.Tvdb.Should().Be(81189U);
            traktSyncRecommendationsPostShow.Ids.Imdb.Should().Be("tt0903747");
            traktSyncRecommendationsPostShow.Ids.Tmdb.Should().Be(1396U);
            traktSyncRecommendationsPostShow.Notes.Should().Be("I AM THE DANGER!");
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostShow>> traktSyncRecommendationsPostShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncRecommendationsPostShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostShowObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostShow traktSyncRecommendationsPostShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncRecommendationsPostShow.Should().BeNull();
        }
    }
}
