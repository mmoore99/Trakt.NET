﻿namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Syncs.Playback;
    using System.Collections.Generic;

    internal class TraktSyncPlaybackProgressRequest : TraktGetRequest<TraktListResult<TraktSyncPlaybackProgressItem>, TraktSyncPlaybackProgressItem>
    {
        internal TraktSyncPlaybackProgressRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal TraktSyncType? Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type.HasValue && Type != TraktSyncType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            return uriParams;
        }

        protected override string UriTemplate => "sync/playback{/type}{?extended,limit}";

        protected override bool IsListResult => true;

        protected override bool SupportsPaginationParameters => true;
    }
}
