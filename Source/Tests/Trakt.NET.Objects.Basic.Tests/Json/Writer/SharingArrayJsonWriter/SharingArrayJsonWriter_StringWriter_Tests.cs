﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class SharingArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
            IEnumerable<ITraktSharing> traktSharing = new List<TraktSharing>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktSharing);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<TraktSharing>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSharing);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSharing);
                json.Should().Be(@"[{""twitter"":true,""google"":true," +
                                 @"""tumblr"":true,""medium"":true,""slack"":true}]");
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktSharing> traktSharing = new List<ITraktSharing>
            {
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                },
                new TraktSharing
                {
                    Twitter = true,
                    Google = true,
                    Tumblr = true,
                    Medium = true,
                    Slack = true
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktSharing>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktSharing);
                json.Should().Be(@"[{""twitter"":true,""google"":true," +
                                 @"""tumblr"":true,""medium"":true,""slack"":true}," +
                                 @"{""twitter"":true,""google"":true," +
                                 @"""tumblr"":true,""medium"":true,""slack"":true}]");
            }
        }
    }
}
