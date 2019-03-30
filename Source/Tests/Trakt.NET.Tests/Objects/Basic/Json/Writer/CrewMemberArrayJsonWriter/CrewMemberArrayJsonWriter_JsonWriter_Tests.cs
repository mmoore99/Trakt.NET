﻿namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class CrewMemberArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_CrewMemberArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<TraktCrewMember>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCrewMembers);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<TraktCrewMember>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCrewMembers);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
                {
                    Job = "Crew Member",
                    Person = new TraktPerson
                    {
                        Name = "Bryan Cranston",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 297737U,
                            Slug = "bryan-cranston",
                            Imdb = "nm0186505",
                            Tmdb = 17419U,
                            TvRage = 1797U
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCrewMembers);
                stringWriter.ToString().Should().Be(@"[{""job"":""Crew Member""," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
            }
        }

        [Fact]
        public async Task Test_CrewMemberArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCrewMember> traktCrewMembers = new List<ITraktCrewMember>
            {
                new TraktCrewMember
                {
                    Job = "Crew Member",
                    Person = new TraktPerson
                    {
                        Name = "Bryan Cranston",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 297737U,
                            Slug = "bryan-cranston",
                            Imdb = "nm0186505",
                            Tmdb = 17419U,
                            TvRage = 1797U
                        }
                    }
                },
                new TraktCrewMember
                {
                    Job = "Crew Member",
                    Person = new TraktPerson
                    {
                        Name = "Bryan Cranston",
                        Ids = new TraktPersonIds
                        {
                            Trakt = 297737U,
                            Slug = "bryan-cranston",
                            Imdb = "nm0186505",
                            Tmdb = 17419U,
                            TvRage = 1797U
                        }
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCrewMembers);
                stringWriter.ToString().Should().Be(@"[{""job"":""Crew Member""," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}," +
                                                    @"{""job"":""Crew Member""," +
                                                    @"""person"":{""name"":""Bryan Cranston""," +
                                                    @"""ids"":{""trakt"":297737,""slug"":""bryan-cranston""," +
                                                    @"""imdb"":""nm0186505"",""tmdb"":17419,""tvrage"":1797}}}]");
            }
        }
    }
}
