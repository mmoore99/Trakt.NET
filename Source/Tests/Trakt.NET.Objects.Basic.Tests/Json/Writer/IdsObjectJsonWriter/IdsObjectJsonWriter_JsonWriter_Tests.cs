﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class IdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new IdsObjectJsonWriter();
            ITraktIds traktIds = new TraktIds();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktIds);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_Trakt_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Trakt = 123
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_Slug_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Slug = "ids slug"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""slug"":""ids slug""}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tvdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Tvdb = 456
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvdb"":456}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_Imdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Imdb = "ids imdb"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""imdb"":""ids imdb""}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_Tmdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Tmdb = 789
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tmdb"":789}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Only_TvRage_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":0,""tvrage"":101}");
            }
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktIds traktIds = new TraktIds
            {
                Trakt = 123,
                Slug = "ids slug",
                Tvdb = 456,
                Imdb = "ids imdb",
                Tmdb = 789,
                TvRage = 101
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new IdsObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktIds);
                stringWriter.ToString().Should().Be(@"{""trakt"":123,""slug"":""ids slug"",""tvdb"":456," +
                                                    @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}");
            }
        }
    }
}
