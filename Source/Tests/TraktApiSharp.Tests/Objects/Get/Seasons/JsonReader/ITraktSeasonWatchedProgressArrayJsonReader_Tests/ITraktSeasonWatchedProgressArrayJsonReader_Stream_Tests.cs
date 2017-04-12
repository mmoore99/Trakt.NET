﻿namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().BeNull();
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().BeNull();
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().BeNull();
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().BeNull();

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().BeNull();

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().BeNull();
                watchedProgresses[0].Completed.Should().BeNull();
                watchedProgresses[0].Episodes.Should().BeNull();

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().BeNull();
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().BeNull();
                watchedProgresses[1].Episodes.Should().BeNull();

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().BeNull();
                watchedProgresses[2].Aired.Should().BeNull();
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().BeNull();
                watchedProgresses[0].Aired.Should().BeNull();
                watchedProgresses[0].Completed.Should().BeNull();
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().BeNull();
                watchedProgresses[1].Aired.Should().BeNull();
                watchedProgresses[1].Completed.Should().BeNull();
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().BeNull();
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().BeNull();
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().BeNull();
                watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().Be(1);
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().Be(3);
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().Be(2);
                watchedProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

                watchedProgresses[0].Number.Should().BeNull();
                watchedProgresses[0].Aired.Should().Be(3);
                watchedProgresses[0].Completed.Should().Be(2);
                watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[1].Number.Should().Be(2);
                watchedProgresses[1].Aired.Should().BeNull();
                watchedProgresses[1].Completed.Should().Be(2);
                watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

                episodesWatchedProgress[0].Should().NotBeNull();
                episodesWatchedProgress[0].Number.Should().Be(1);
                episodesWatchedProgress[0].Completed.Should().BeTrue();
                episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesWatchedProgress[1].Should().NotBeNull();
                episodesWatchedProgress[1].Number.Should().Be(2);
                episodesWatchedProgress[1].Completed.Should().BeTrue();
                episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                watchedProgresses[2].Number.Should().Be(3);
                watchedProgresses[2].Aired.Should().Be(3);
                watchedProgresses[2].Completed.Should().BeNull();
                watchedProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktSeasonWatchedProgresses.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new ITraktSeasonWatchedProgressArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSeasonWatchedProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgresses.Should().BeNull();
            }
        }
    }
}
