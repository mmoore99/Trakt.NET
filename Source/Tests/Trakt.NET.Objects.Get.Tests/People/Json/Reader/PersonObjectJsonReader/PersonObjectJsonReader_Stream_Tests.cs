﻿namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Complete()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_COMPLETE.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Incomplete_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_INCOMPLETE_1.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Incomplete_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_INCOMPLETE_2.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_NOT_VALID_1.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_NOT_VALID_2.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = MINIMAL_JSON_NOT_VALID_3.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Complete()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_COMPLETE.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_1.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_2.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_3()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_3.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_4()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_4.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_5()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_5.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_6()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_6.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_7()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_7.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_8()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_8.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_9()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_9.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_10()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_10.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_11()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_11.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_12()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_12.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_13()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_13.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Incomplete_14()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_INCOMPLETE_14.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_1.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_2.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_3()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_3.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_4()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_4.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_5()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_5.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_6()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_6.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_7()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_7.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Full_Not_Valid_8()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = FULL_JSON_NOT_VALID_8.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new PersonObjectJsonReader();
            Func<Task<ITraktPerson>> traktPerson = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktPerson.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktPerson = await traktJsonReader.ReadObjectAsync(stream);
                traktPerson.Should().BeNull();
            }
        }
    }
}
