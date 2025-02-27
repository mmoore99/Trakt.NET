﻿namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRecommendationsPostResponseGroupObjectJsonWriter : AObjectJsonWriter<ITraktSyncRecommendationsPostResponseGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRecommendationsPostResponseGroup obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
