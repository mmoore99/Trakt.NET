﻿namespace TraktNet.Objects.Get.Tests.Collections.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Get.Collections.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Collections.JsonWriter")]
    public partial class CollectionShowSeasonObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new CollectionShowSeasonObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonWriter_WriteObject_Object_Only_Number_Property()
        {
            ITraktCollectionShowSeason traktCollectionShowSeason = new TraktCollectionShowSeason
            {
                Number = 1
            };

            var traktJsonWriter = new CollectionShowSeasonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionShowSeason);
            json.Should().Be(@"{""number"":1}");
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonWriter_WriteObject_Object_Only_Episodes_Property()
        {
            ITraktCollectionShowSeason traktCollectionShowSeason = new TraktCollectionShowSeason
            {
                Episodes = new List<ITraktCollectionShowEpisode>
                {
                    new TraktCollectionShowEpisode
                    {
                        Number = 1,
                        CollectedAt = COLLECTED_AT,
                        Metadata = new TraktMetadata
                        {
                            MediaType = TraktMediaType.Digital,
                            MediaResolution = TraktMediaResolution.HD_720p,
                            Audio = TraktMediaAudio.AAC,
                            AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                            ThreeDimensional = true
                        }
                    },
                    new TraktCollectionShowEpisode
                    {
                        Number = 1,
                        CollectedAt = COLLECTED_AT,
                        Metadata = new TraktMetadata
                        {
                            MediaType = TraktMediaType.Digital,
                            MediaResolution = TraktMediaResolution.HD_720p,
                            Audio = TraktMediaAudio.AAC,
                            AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                            ThreeDimensional = true
                        }
                    }
                }
            };

            var traktJsonWriter = new CollectionShowSeasonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionShowSeason);
            json.Should().Be(@"{""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}]}");
        }

        [Fact]
        public async Task Test_CollectionShowSeasonObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktCollectionShowSeason traktCollectionShowSeason = new TraktCollectionShowSeason
            {
                Number = 1,
                Episodes = new List<ITraktCollectionShowEpisode>
                {
                    new TraktCollectionShowEpisode
                    {
                        Number = 1,
                        CollectedAt = COLLECTED_AT,
                        Metadata = new TraktMetadata
                        {
                            MediaType = TraktMediaType.Digital,
                            MediaResolution = TraktMediaResolution.HD_720p,
                            Audio = TraktMediaAudio.AAC,
                            AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                            ThreeDimensional = true
                        }
                    },
                    new TraktCollectionShowEpisode
                    {
                        Number = 1,
                        CollectedAt = COLLECTED_AT,
                        Metadata = new TraktMetadata
                        {
                            MediaType = TraktMediaType.Digital,
                            MediaResolution = TraktMediaResolution.HD_720p,
                            Audio = TraktMediaAudio.AAC,
                            AudioChannels = TraktMediaAudioChannel.Channels_5_1,
                            ThreeDimensional = true
                        }
                    }
                }
            };

            var traktJsonWriter = new CollectionShowSeasonObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktCollectionShowSeason);
            json.Should().Be(@"{""number"":1,""episodes"":[{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}," +
                             @"{""number"":1," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             @"""metadata"":{""media_type"":""digital""," +
                             @"""resolution"":""hd_720p"",""audio"":""aac""," +
                             @"""audio_channels"":""5.1"",""3d"":true}}]}");
        }
    }
}
