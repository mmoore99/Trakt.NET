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
    public partial class UserCommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserCommentObjectJsonReader();
            Func<Task<ITraktUserComment>> traktUserComment = () => jsonReader.ReadObjectAsync(default(string));
            await traktUserComment.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserCommentObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserCommentObjectJsonReader();

            var traktUserComment = await jsonReader.ReadObjectAsync(string.Empty);
            traktUserComment.Should().BeNull();
        }
    }
}
