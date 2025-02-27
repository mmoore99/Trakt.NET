﻿namespace TraktNet.Objects.Get.Tests.Seasons.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonWriter")]
    public partial class SeasonWatchedProgressObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktSeasonWatchedProgress));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Number_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Number = 1
            };

            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonWatchedProgress);
            json.Should().Be(@"{""number"":1}");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Aired_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Aired = 24
            };

            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonWatchedProgress);
            json.Should().Be(@"{""aired"":24}");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Completed_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Completed = 12
            };

            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonWatchedProgress);
            json.Should().Be(@"{""completed"":12}");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Only_Episodes_Property()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Episodes = new List<ITraktEpisodeWatchedProgress>
                {
                    new TraktEpisodeWatchedProgress
                    {
                        Number = 1,
                        Completed = true,
                        LastWatchedAt = LAST_WATCHED_AT
                    },
                    new TraktEpisodeWatchedProgress
                    {
                        Number = 2,
                        Completed = true,
                        LastWatchedAt = LAST_WATCHED_AT
                    }
                }
            };

            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonWatchedProgress);
            json.Should().Be(@"{""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}");
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktSeasonWatchedProgress traktSeasonWatchedProgress = new TraktSeasonWatchedProgress
            {
                Number = 1,
                Aired = 24,
                Completed = 12,
                Episodes = new List<ITraktEpisodeWatchedProgress>
                {
                    new TraktEpisodeWatchedProgress
                    {
                        Number = 1,
                        Completed = true,
                        LastWatchedAt = LAST_WATCHED_AT
                    },
                    new TraktEpisodeWatchedProgress
                    {
                        Number = 2,
                        Completed = true,
                        LastWatchedAt = LAST_WATCHED_AT
                    }
                }
            };

            var traktJsonWriter = new SeasonWatchedProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktSeasonWatchedProgress);
            json.Should().Be(@"{""number"":1,""aired"":24,""completed"":12," +
                             @"""episodes"":[" +
                             $"{{\"number\":1,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"{{\"number\":2,\"completed\":true,\"last_watched_at\":\"{LAST_WATCHED_AT.ToTraktLongDateTimeString()}\"}}" +
                             "]}");
        }
    }
}
