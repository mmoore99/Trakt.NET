﻿namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();
            Func<Task<ITraktUserHiddenItem>> traktUserHiddenItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktUserHiddenItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserHiddenItem.Should().BeNull();
        }
    }
}
