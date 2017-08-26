﻿namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface ITraktRequestHandler : ITraktPostRequestHandler, ITraktPutRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
