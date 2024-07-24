﻿using System;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shelly.Abstractions.TwoFactor.Providers.Time
{
    /// <summary>
    /// Provides time information from a webserver by doing a HEAD request and extracting the Date HTTP response header.
    /// </summary>
    public class HttpTimeProvider : ITimeProvider
    {
        /// <summary>
        /// The default Uri used to 'query'.
        /// </summary>
        public const string DEFAULTURI = "https://google.com";

        /// <summary>
        /// Gets the Uri to be queried.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets/sets the <see cref="RequestCachePolicy"/> used when performing requests.
        /// </summary>
        public RequestCachePolicy CachePolicy { get; set; } = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

        /// <summary>
        /// Gets/sets the <see cref="IWebProxy"/> to use when performing requests.
        /// </summary>
        public IWebProxy Proxy { get; set; }


        /// <summary>
        /// Initializes a new instance of a <see cref="HttpTimeProvider"/>.
        /// </summary>
        /// <param name="uri">The uri to query; defaults to <see cref="DEFAULTURI"/>.</param>
        public HttpTimeProvider(string uri = DEFAULTURI)
            : this(new Uri(uri)) { }

        /// <summary>
        /// Initializes a new instance of a <see cref="HttpTimeProvider"/>.
        /// </summary>
        /// <param name="uri"></param>
        public HttpTimeProvider(Uri uri)
        {
            Uri = uri ?? new Uri(DEFAULTURI);
        }

        /// <summary>
        /// Gets the time from the webserver by performing a HEAD request on the specified <see cref="Uri"/>.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<DateTime> GetTimeAsync()
        {
            try
            {
                using (var ch = new HttpClientHandler()
                {
                    Proxy = Proxy,
                    UseProxy = Proxy != null,
                    AllowAutoRedirect = false
                })
                using (var c = new HttpClient(ch))
                {
                    using (var req = new HttpRequestMessage(HttpMethod.Head, Uri))
                    {
                        var response = await c.SendAsync(req).ConfigureAwait(false);

                        if (response.Headers.Date.HasValue)
                            return response.Headers.Date.Value.UtcDateTime;
                    }
                }
            }
            catch (HttpRequestException) { }
            catch (TaskCanceledException) { }

            throw new TimeProviderException($"Unable to retrieve time data from {Uri}");
        }
    }
}
