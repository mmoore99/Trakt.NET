﻿namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCastMemberObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().NotBeNull();
                traktCastMember.Person.Name.Should().Be("Bryan Cranston");
                traktCastMember.Person.Ids.Should().NotBeNull();
                traktCastMember.Person.Ids.Trakt.Should().Be(297737U);
                traktCastMember.Person.Ids.Slug.Should().Be("bryan-cranston");
                traktCastMember.Person.Ids.Imdb.Should().Be("nm0186505");
                traktCastMember.Person.Ids.Tmdb.Should().Be(17419U);
                traktCastMember.Person.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().Be("Joe Brody");
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);

                traktCastMember.Should().NotBeNull();
                traktCastMember.Character.Should().BeNull();
                traktCastMember.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            var traktCastMember = await jsonReader.ReadObjectAsync(default(Stream));
            traktCastMember.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCastMemberObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktCastMemberObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCastMember = await jsonReader.ReadObjectAsync(stream);
                traktCastMember.Should().BeNull();
            }
        }
    }
}
