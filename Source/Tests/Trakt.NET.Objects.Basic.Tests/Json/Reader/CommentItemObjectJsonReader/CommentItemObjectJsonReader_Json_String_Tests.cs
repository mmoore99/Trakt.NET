﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().BeNull();

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().BeNull();

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().BeNull();

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().BeNull();

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().BeNull();
            traktCommentItem.Show.Should().BeNull();
            traktCommentItem.Season.Should().BeNull();
            traktCommentItem.Episode.Should().BeNull();
            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().BeNull();
            traktCommentItem.Season.Should().BeNull();
            traktCommentItem.Episode.Should().BeNull();
            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().BeNull();

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().BeNull();
            traktCommentItem.Episode.Should().BeNull();
            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().BeNull();
            traktCommentItem.Show.Should().BeNull();

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().BeNull();
            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().BeNull();
            traktCommentItem.Show.Should().BeNull();
            traktCommentItem.Season.Should().BeNull();

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().BeNull();
            traktCommentItem.Show.Should().BeNull();
            traktCommentItem.Season.Should().BeNull();
            traktCommentItem.Episode.Should().BeNull();

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().BeNull();

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().BeNull();

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().BeNull();

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().BeNull();

            traktCommentItem.List.Should().NotBeNull();
            traktCommentItem.List.Name.Should().Be("Star Wars in machete order");
            traktCommentItem.List.Description.Should().Be("Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.");
            traktCommentItem.List.Privacy.Should().Be(TraktAccessScope.Public);
            traktCommentItem.List.DisplayNumbers.Should().BeTrue();
            traktCommentItem.List.AllowComments.Should().BeFalse();
            traktCommentItem.List.SortBy.Should().Be("rank");
            traktCommentItem.List.SortHow.Should().Be("asc");
            traktCommentItem.List.CreatedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.UpdatedAt.Should().Be(DateTime.Parse("2014-11-09T17:00:54.000Z").ToUniversalTime());
            traktCommentItem.List.ItemCount.Should().Be(5);
            traktCommentItem.List.CommentCount.Should().Be(1);
            traktCommentItem.List.Likes.Should().Be(2);
            traktCommentItem.List.Ids.Should().NotBeNull();
            traktCommentItem.List.Ids.Trakt.Should().Be(55U);
            traktCommentItem.List.Ids.Slug.Should().Be("star-wars-in-machete-order");
            traktCommentItem.List.User.Should().NotBeNull();
            traktCommentItem.List.User.Username.Should().Be("sean");
            traktCommentItem.List.User.IsPrivate.Should().BeFalse();
            traktCommentItem.List.User.Name.Should().Be("Sean Rudford");
            traktCommentItem.List.User.IsVIP.Should().BeTrue();
            traktCommentItem.List.User.IsVIP_EP.Should().BeFalse();
            traktCommentItem.List.User.Ids.Should().NotBeNull();
            traktCommentItem.List.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().Be(TraktObjectType.Movie);

            traktCommentItem.Movie.Should().NotBeNull();
            traktCommentItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCommentItem.Movie.Year.Should().Be(2015);
            traktCommentItem.Movie.Ids.Should().NotBeNull();
            traktCommentItem.Movie.Ids.Trakt.Should().Be(94024U);
            traktCommentItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCommentItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCommentItem.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCommentItem.Show.Should().NotBeNull();
            traktCommentItem.Show.Title.Should().Be("Game of Thrones");
            traktCommentItem.Show.Year.Should().Be(2011);
            traktCommentItem.Show.Ids.Should().NotBeNull();
            traktCommentItem.Show.Ids.Trakt.Should().Be(1390U);
            traktCommentItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktCommentItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktCommentItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktCommentItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktCommentItem.Show.Ids.TvRage.Should().Be(24493U);

            traktCommentItem.Season.Should().NotBeNull();
            traktCommentItem.Season.Number.Should().Be(1);
            traktCommentItem.Season.Ids.Should().NotBeNull();
            traktCommentItem.Season.Ids.Trakt.Should().Be(61430U);
            traktCommentItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktCommentItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktCommentItem.Season.Ids.TvRage.Should().Be(36939U);

            traktCommentItem.Episode.Should().NotBeNull();
            traktCommentItem.Episode.SeasonNumber.Should().Be(1);
            traktCommentItem.Episode.Number.Should().Be(1);
            traktCommentItem.Episode.Title.Should().Be("Winter Is Coming");
            traktCommentItem.Episode.Ids.Should().NotBeNull();
            traktCommentItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktCommentItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktCommentItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktCommentItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktCommentItem.Episode.Ids.TvRage.Should().Be(1065008299U);

            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktCommentItem.Should().NotBeNull();
            traktCommentItem.Type.Should().BeNull();
            traktCommentItem.Movie.Should().BeNull();
            traktCommentItem.Show.Should().BeNull();
            traktCommentItem.Season.Should().BeNull();
            traktCommentItem.Episode.Should().BeNull();
            traktCommentItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            Func<Task<ITraktCommentItem>> traktCommentItem = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktCommentItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CommentItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new CommentItemObjectJsonReader();
            ITraktCommentItem traktCommentItem = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktCommentItem.Should().BeNull();
        }
    }
}
