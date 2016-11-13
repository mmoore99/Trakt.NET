﻿namespace TraktApiSharp.Services
{
    using Authentication;
    using Enums;
    using Newtonsoft.Json;
    using System;
    using Utils;

    /// <summary>Provides helper methods for serializing and deserializing Trakt objects.</summary>
    public static class TraktSerializationService
    {
        /// <summary>Serializes an <see cref="TraktAuthorization" /> instance to a JSON string.</summary>
        /// <param name="authorization">The authorization information, which should be serialized.</param>
        /// <returns>A Json string, containing all properties of the given authorization.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given authorization is null.</exception>
        public static string Serialize(TraktAuthorization authorization)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            var scope = authorization.AccessScope ?? TraktAccessScope.Public;
            var tokenType = authorization.TokenType ?? TraktAccessTokenType.Bearer;

            var authorizationWrapper = new
            {
                AccessToken = authorization.AccessToken ?? string.Empty,
                RefreshToken = authorization.RefreshToken ?? string.Empty,
                ExpiresIn = authorization.ExpiresInSeconds,
                Scope = scope.ObjectName,
                TokenType = tokenType.ObjectName,
                CreatedAtTicks = authorization.Created.Ticks,
                IgnoreExpiration = authorization.IgnoreExpiration
            };

            return Json.Serialize(authorizationWrapper);
        }

        /// <summary>Deserializes a JSON string to an <see cref="TraktAuthorization" /> instance.</summary>
        /// <param name="authorizationJson">The JSON string, which should be deserialized.</param>
        /// <returns>
        /// An <see cref="TraktAuthorization" /> instance, containing the information from the JSON string, if successful.
        /// If the JSON string could not be parsed, null will be returned.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown, if the given authorizationJson is null or empty.</exception>
        public static TraktAuthorization DeserializeAuthorization(string authorizationJson)
        {
            if (string.IsNullOrEmpty(authorizationJson))
                throw new ArgumentException("authorization JSON is invalid", nameof(authorizationJson));

            var authorizationWrapper = new
            {
                AccessToken = string.Empty,
                RefreshToken = string.Empty,
                ExpiresIn = 0,
                Scope = string.Empty,
                TokenType = string.Empty,
                CreatedAtTicks = 0L,
                IgnoreExpiration = false
            };

            var anonymousAuthorization = JsonConvert.DeserializeAnonymousType(authorizationJson, authorizationWrapper);

            if (anonymousAuthorization != null)
            {
                var accessToken = anonymousAuthorization.AccessToken;
                var refreshToken = anonymousAuthorization.RefreshToken;
                var expiresIn = anonymousAuthorization.ExpiresIn;
                var scope = anonymousAuthorization.Scope;
                var tokenType = anonymousAuthorization.TokenType;
                var createdAtTicks = anonymousAuthorization.CreatedAtTicks;
                var ignoreExpiration = anonymousAuthorization.IgnoreExpiration;

                if (accessToken == null || refreshToken == null || scope == null || tokenType == null)
                    return default(TraktAuthorization);

                var accessScope = scope != string.Empty ? TraktEnumeration.FromObjectName<TraktAccessScope>(scope) : TraktAccessScope.Public;
                var accessTokenType = tokenType != string.Empty ? TraktEnumeration.FromObjectName<TraktAccessTokenType>(tokenType) : TraktAccessTokenType.Bearer;
                var createdDateTime = new DateTime(createdAtTicks, DateTimeKind.Utc);

                var authorization = new TraktAuthorization
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresInSeconds = expiresIn,
                    AccessScope = accessScope,
                    TokenType = accessTokenType,
                    IgnoreExpiration = ignoreExpiration,
                    Created = createdDateTime
                };

                return authorization;
            }

            return default(TraktAuthorization);
        }
    }
}
