﻿namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Implementations
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.Implementations")]
    public class TraktSyncRecommendationsPostResponseNotFoundGroup_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsPostResponseNotFoundGroup_Default_Constructor()
        {
            var syncRecommendationsPostResponseNotFoundGroup = new TraktSyncRecommendationsPostResponseNotFoundGroup();

            syncRecommendationsPostResponseNotFoundGroup.Movies.Should().BeNull();
            syncRecommendationsPostResponseNotFoundGroup.Shows.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncRecommendationsPostResponseNotFoundGroup_From_Json()
        {
            var jsonReader = new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();
            var syncRecommendationsPostResponseNotFoundGroup = await jsonReader.ReadObjectAsync(JSON) as TraktSyncRecommendationsPostResponseNotFoundGroup;

            syncRecommendationsPostResponseNotFoundGroup.Should().NotBeNull();

            syncRecommendationsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktMovieIds[] notFoundMovies = syncRecommendationsPostResponseNotFoundGroup.Movies.ToArray();

            notFoundMovies[0].Should().NotBeNull();
            notFoundMovies[0].Trakt.Should().Be(0U);
            notFoundMovies[0].Slug.Should().BeNull();
            notFoundMovies[0].Imdb.Should().Be("tt0000111");
            notFoundMovies[0].Tmdb.Should().BeNull();

            syncRecommendationsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktShowIds[] notFoundShows = syncRecommendationsPostResponseNotFoundGroup.Shows.ToArray();

            notFoundShows[0].Should().NotBeNull();
            notFoundShows[0].Trakt.Should().Be(0U);
            notFoundShows[0].Slug.Should().BeNull();
            notFoundShows[0].Imdb.Should().Be("tt0000222");
            notFoundShows[0].Tvdb.Should().BeNull();
            notFoundShows[0].Tmdb.Should().BeNull();

        }

        private const string JSON =
            @"{
                ""movies"": [
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000111""
                    }
                  }
                ],
                ""shows"": [
                  {
                    ""ids"": {
                      ""imdb"": ""tt0000222""
                    }
                  }
                ]
              }";
    }
}
