﻿namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class RatingObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new RatingObjectJsonWriter();
            ITraktRating traktRating = new TraktRating();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktRating);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Only_Rating_Property()
        {
            ITraktRating traktRating = new TraktRating
            {
                Rating = 7.4561f
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new RatingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRating);
                stringWriter.ToString().Should().Be(@"{""rating"":7.4561}");
            }
        }

        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Only_Votes_Property()
        {
            ITraktRating traktRating = new TraktRating
            {
                Votes = 2453
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new RatingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRating);
                stringWriter.ToString().Should().Be(@"{""votes"":2453}");
            }
        }

        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Only_Distribution_Property()
        {
            ITraktRating traktRating = new TraktRating
            {
                Distribution = new Dictionary<string, int>
                {
                    ["1"] = 1,
                    ["2"] = 2,
                    ["3"] = 3,
                    ["4"] = 4,
                    ["5"] = 5,
                    ["6"] = 6,
                    ["7"] = 7,
                    ["8"] = 8,
                    ["9"] = 9,
                    ["10"] = 10
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new RatingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRating);
                stringWriter.ToString().Should().Be(@"{""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}");
            }
        }

        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Only_Distribution_Property_Incomplete()
        {
            ITraktRating traktRating = new TraktRating
            {
                Distribution = new Dictionary<string, int>
                {
                    ["1"] = 1,
                    ["2"] = 2,
                    ["3"] = 3,
                    ["5"] = 5,
                    ["6"] = 6,
                    ["8"] = 8,
                    ["9"] = 9
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new RatingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRating);
                stringWriter.ToString().Should().Be(@"{""distribution"":{""1"":1,""2"":2,""3"":3,""4"":0,""5"":5,""6"":6,""7"":0,""8"":8,""9"":9,""10"":0}}");
            }
        }

        [Fact]
        public async Task Test_RatingObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktRating traktRating = new TraktRating
            {
                Rating = 7.4561f,
                Votes = 2453,
                Distribution = new Dictionary<string, int>
                {
                    ["1"] = 1,
                    ["2"] = 2,
                    ["3"] = 3,
                    ["4"] = 4,
                    ["5"] = 5,
                    ["6"] = 6,
                    ["7"] = 7,
                    ["8"] = 8,
                    ["9"] = 9,
                    ["10"] = 10
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new RatingObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktRating);
                stringWriter.ToString().Should().Be(@"{""rating"":7.4561,""votes"":2453," +
                                                    @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}");
            }
        }
    }
}
