﻿namespace TraktNet.Objects.Post.Tests.Scrobbles.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Post.Scrobbles.Responses;
    using TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class MovieScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().NotBeNull();
            movieScrobbleResponse.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            movieScrobbleResponse.Movie.Year.Should().Be(2015);
            movieScrobbleResponse.Movie.Ids.Should().NotBeNull();
            movieScrobbleResponse.Movie.Ids.Trakt.Should().Be(94024U);
            movieScrobbleResponse.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movieScrobbleResponse.Movie.Ids.Imdb.Should().Be("tt2488496");
            movieScrobbleResponse.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(3373536623UL);
            movieScrobbleResponse.Action.Should().Be(TraktScrobbleActionType.Stop);
            movieScrobbleResponse.Progress.Should().Be(85.9f);
            movieScrobbleResponse.Sharing.Should().NotBeNull();
            movieScrobbleResponse.Sharing.Twitter.Should().BeTrue();
            movieScrobbleResponse.Sharing.Google.Should().BeTrue();
            movieScrobbleResponse.Sharing.Tumblr.Should().BeTrue();
            movieScrobbleResponse.Sharing.Medium.Should().BeTrue();
            movieScrobbleResponse.Sharing.Slack.Should().BeTrue();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            movieScrobbleResponse.Should().NotBeNull();
            movieScrobbleResponse.Id.Should().Be(0UL);
            movieScrobbleResponse.Action.Should().BeNull();
            movieScrobbleResponse.Progress.Should().BeNull();
            movieScrobbleResponse.Sharing.Should().BeNull();
            movieScrobbleResponse.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();
            Func<Task<ITraktMovieScrobblePostResponse>> movieScrobbleResponse = () => jsonReader.ReadObjectAsync(default(string));
            await movieScrobbleResponse.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieScrobblePostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieScrobblePostResponseObjectJsonReader();

            var movieScrobbleResponse = await jsonReader.ReadObjectAsync(string.Empty);
            movieScrobbleResponse.Should().BeNull();
        }
    }
}
