﻿namespace TraktNet.Objects.Authentication.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class AuthorizationArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);
                traktAuthorizations.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Complete()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);

                traktAuthorizations.Should().NotBeNull();
                ITraktAuthorization[] items = traktAuthorizations.ToArray();

                items[0].Should().NotBeNull();
                items[0].AccessToken.Should().Be("mockAccessToken1");
                items[0].RefreshToken.Should().Be("mockRefreshToken1");
                items[0].Scope.Should().Be(TraktAccessScope.Public);
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[0].IgnoreExpiration.Should().BeTrue();

                items[1].Should().NotBeNull();
                items[1].AccessToken.Should().Be("mockAccessToken2");
                items[1].RefreshToken.Should().Be("mockRefreshToken2");
                items[1].Scope.Should().Be(TraktAccessScope.Public);
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[1].IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);

                traktAuthorizations.Should().NotBeNull();
                ITraktAuthorization[] items = traktAuthorizations.ToArray();

                items[0].Should().NotBeNull();
                items[0].AccessToken.Should().BeNull();
                items[0].RefreshToken.Should().Be("mockRefreshToken1");
                items[0].Scope.Should().Be(TraktAccessScope.Public);
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[0].IgnoreExpiration.Should().BeTrue();

                items[1].Should().NotBeNull();
                items[1].AccessToken.Should().Be("mockAccessToken2");
                items[1].RefreshToken.Should().Be("mockRefreshToken2");
                items[1].Scope.Should().Be(TraktAccessScope.Public);
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[1].IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);

                traktAuthorizations.Should().NotBeNull();
                ITraktAuthorization[] items = traktAuthorizations.ToArray();

                items[0].Should().NotBeNull();
                items[0].AccessToken.Should().Be("mockAccessToken1");
                items[0].RefreshToken.Should().Be("mockRefreshToken1");
                items[0].Scope.Should().Be(TraktAccessScope.Public);
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[0].IgnoreExpiration.Should().BeTrue();

                items[1].Should().NotBeNull();
                items[1].AccessToken.Should().Be("mockAccessToken2");
                items[1].RefreshToken.Should().BeNull();
                items[1].Scope.Should().BeNull();
                items[1].ExpiresInSeconds.Should().Be(0);
                items[1].TokenType.Should().BeNull();
                items[1].CreatedAtTimestamp.Should().Be(0);
                items[1].IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);

                traktAuthorizations.Should().NotBeNull();
                ITraktAuthorization[] items = traktAuthorizations.ToArray();

                items[0].Should().NotBeNull();
                items[0].AccessToken.Should().BeNull();
                items[0].RefreshToken.Should().Be("mockRefreshToken1");
                items[0].Scope.Should().Be(TraktAccessScope.Public);
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[0].IgnoreExpiration.Should().BeTrue();

                items[1].Should().NotBeNull();
                items[1].AccessToken.Should().Be("mockAccessToken2");
                items[1].RefreshToken.Should().Be("mockRefreshToken2");
                items[1].Scope.Should().Be(TraktAccessScope.Public);
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[1].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[1].IgnoreExpiration.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader
            {
                CompleteDeserialization = true
            };

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);

                traktAuthorizations.Should().NotBeNull();
                ITraktAuthorization[] items = traktAuthorizations.ToArray();

                items[0].Should().NotBeNull();
                items[0].AccessToken.Should().Be("mockAccessToken1");
                items[0].RefreshToken.Should().Be("mockRefreshToken1");
                items[0].Scope.Should().Be(TraktAccessScope.Public);
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].TokenType.Should().Be(TraktAccessTokenType.Bearer);
                items[0].CreatedAtTimestamp.Should().Be(1506271312UL);
                items[0].IgnoreExpiration.Should().BeTrue();

                items[1].Should().NotBeNull();
                items[1].AccessToken.Should().BeNull();
                items[1].RefreshToken.Should().BeNull();
                items[1].Scope.Should().BeNull();
                items[1].ExpiresInSeconds.Should().Be(0);
                items[1].TokenType.Should().BeNull();
                items[1].CreatedAtTimestamp.Should().Be(0);
                items[1].IgnoreExpiration.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Null()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();
            Func<Task<IEnumerable<ITraktAuthorization>>> traktAuthorizations = () => objectJsonReader.ReadArrayAsync(default(Stream));
            await traktAuthorizations.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AuthorizationArrayJsonReader_ReadObject_From_Stream_Empty()
        {
            var objectJsonReader = new AuthorizationArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktAuthorization> traktAuthorizations = await objectJsonReader.ReadArrayAsync(stream);
                traktAuthorizations.Should().BeNull();
            }
        }
    }
}
