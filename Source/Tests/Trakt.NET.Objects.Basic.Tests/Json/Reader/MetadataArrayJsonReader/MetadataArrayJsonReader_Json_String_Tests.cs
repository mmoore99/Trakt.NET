﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class MetadataArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktMetadatas.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().BeNull();
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().BeNull();
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().BeNull();
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().Be(TraktMediaType.Digital);
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().BeNull();
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktMetadatas.Should().NotBeNull();
            ITraktMetadata[] metadatas = traktMetadatas.ToArray();

            metadatas[0].Should().NotBeNull();
            metadatas[0].MediaType.Should().BeNull();
            metadatas[0].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[0].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[0].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[0].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[0].ThreeDimensional.Should().BeTrue();

            metadatas[1].Should().NotBeNull();
            metadatas[1].MediaType.Should().BeNull();
            metadatas[1].MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            metadatas[1].Audio.Should().Be(TraktMediaAudio.AAC);
            metadatas[1].AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            metadatas[1].HDR.Should().Be(TraktMediaHDR.DolbyVision);
            metadatas[1].ThreeDimensional.Should().BeTrue();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            Func<Task<IEnumerable<ITraktMetadata>>> traktMetadatas = () => jsonReader.ReadArrayAsync(default(string));
            await traktMetadatas.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MetadataArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktMetadata>();
            IEnumerable<ITraktMetadata> traktMetadatas = await jsonReader.ReadArrayAsync(string.Empty);
            traktMetadatas.Should().BeNull();
        }
    }
}
