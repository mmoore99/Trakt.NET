﻿namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCastItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            showCreditsCastItems.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().NotBeNull();
            items[1].Show.Title.Should().Be("The Flash");
            items[1].Show.Year.Should().Be(2014);
            items[1].Show.Ids.Should().NotBeNull();
            items[1].Show.Ids.Trakt.Should().Be(60300U);
            items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
            items[1].Show.Ids.Tvdb.Should().Be(279121U);
            items[1].Show.Ids.Imdb.Should().Be("tt3107288");
            items[1].Show.Ids.Tmdb.Should().Be(60735U);
            items[1].Show.Ids.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().BeNull();
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().NotBeNull();
            items[1].Show.Title.Should().Be("The Flash");
            items[1].Show.Year.Should().Be(2014);
            items[1].Show.Ids.Should().NotBeNull();
            items[1].Show.Ids.Trakt.Should().Be(60300U);
            items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
            items[1].Show.Ids.Tvdb.Should().Be(279121U);
            items[1].Show.Ids.Imdb.Should().Be("tt3107288");
            items[1].Show.Ids.Tmdb.Should().Be(60735U);
            items[1].Show.Ids.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().BeNull();
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().NotBeNull();
            items[1].Show.Title.Should().Be("The Flash");
            items[1].Show.Year.Should().Be(2014);
            items[1].Show.Ids.Should().NotBeNull();
            items[1].Show.Ids.Trakt.Should().Be(60300U);
            items[1].Show.Ids.Slug.Should().Be("the-flash-2014");
            items[1].Show.Ids.Tvdb.Should().Be(279121U);
            items[1].Show.Ids.Imdb.Should().Be("tt3107288");
            items[1].Show.Ids.Tmdb.Should().Be(60735U);
            items[1].Show.Ids.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            showCreditsCastItems.Should().NotBeNull();
            var items = showCreditsCastItems.ToArray();

            items[0].Should().NotBeNull();
            items[0].Characters.Should().BeNull();
            items[0].Show.Should().NotBeNull();
            items[0].Show.Title.Should().Be("Game of Thrones");
            items[0].Show.Year.Should().Be(2011);
            items[0].Show.Ids.Should().NotBeNull();
            items[0].Show.Ids.Trakt.Should().Be(1390U);
            items[0].Show.Ids.Slug.Should().Be("game-of-thrones");
            items[0].Show.Ids.Tvdb.Should().Be(121361U);
            items[0].Show.Ids.Imdb.Should().Be("tt0944947");
            items[0].Show.Ids.Tmdb.Should().Be(1399U);
            items[0].Show.Ids.TvRage.Should().Be(24493U);

            items[1].Should().NotBeNull();
            items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Iris West");
            items[1].Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();
            Func<Task<IEnumerable<ITraktPersonShowCreditsCastItem>>> showCreditsCastItems = () => jsonReader.ReadArrayAsync(default(string));
            await showCreditsCastItems.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemArrayJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktPersonShowCreditsCastItem>();

            var showCreditsCastItems = await jsonReader.ReadArrayAsync(string.Empty);
            showCreditsCastItems.Should().BeNull();
        }
    }
}
