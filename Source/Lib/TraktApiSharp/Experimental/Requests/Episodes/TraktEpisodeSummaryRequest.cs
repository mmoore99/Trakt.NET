﻿namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktEpisodeSummaryRequest : ATraktEpisodeRequest<TraktEpisode>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }
        
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
