using System.Net;
using System.Net.Http;

namespace Songhay.Extensions
{
    /// <summary>
    /// Extensions of <see cref="HttpResponseMessage"/>
    /// </summary>
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Returns <c>true</c> when <see cref="HttpResponseMessage"/>
        /// is <see cref="HttpStatusCode.Moved"/>, <see cref="HttpStatusCode.MovedPermanently"/>
        /// or <see cref="HttpStatusCode.Redirect"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        public static bool IsMovedOrRedirected(this HttpResponseMessage response) =>
            response.StatusCode == HttpStatusCode.Moved ||
            response.StatusCode == HttpStatusCode.MovedPermanently ||
            response.StatusCode == HttpStatusCode.Redirect;
    }
}