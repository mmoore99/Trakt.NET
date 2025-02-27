﻿namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().BeNull();

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().BeNull();

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().BeNull();

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().BeNull();

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().BeNull();

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().BeNull();

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().BeNull();

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().BeNull();

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().BeNull();

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().BeNull();

                lastActivities.Lists.Should().NotBeNull();
                lastActivities.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
                lastActivities.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
                lastActivities.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());

                lastActivities.Movies.Should().NotBeNull();
                lastActivities.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
                lastActivities.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
                lastActivities.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
                lastActivities.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
                lastActivities.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
                lastActivities.Movies.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Episodes.Should().NotBeNull();
                lastActivities.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                lastActivities.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                lastActivities.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                lastActivities.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                lastActivities.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                lastActivities.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

                lastActivities.Shows.Should().NotBeNull();
                lastActivities.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
                lastActivities.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
                lastActivities.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());
                lastActivities.Shows.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Seasons.Should().NotBeNull();
                lastActivities.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
                lastActivities.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
                lastActivities.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());
                lastActivities.Seasons.HiddenAt.Should().Be(DateTime.Parse("2016-08-20T06:51:30.000Z").ToUniversalTime());

                lastActivities.Comments.Should().NotBeNull();
                lastActivities.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);

                lastActivities.Should().NotBeNull();
                lastActivities.All.Should().BeNull();
                lastActivities.Movies.Should().BeNull();
                lastActivities.Episodes.Should().BeNull();
                lastActivities.Shows.Should().BeNull();
                lastActivities.Seasons.Should().BeNull();
                lastActivities.Comments.Should().BeNull();
                lastActivities.Lists.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncLastActivities>> lastActivities = () => jsonReader.ReadObjectAsync(default(Stream));
            await lastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SyncLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var lastActivities = await jsonReader.ReadObjectAsync(stream);
                lastActivities.Should().BeNull();
            }
        }
    }
}
