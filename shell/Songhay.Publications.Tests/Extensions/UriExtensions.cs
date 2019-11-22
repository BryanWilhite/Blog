using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Songhay.Extensions
{
    /// <summary>
    /// Extensions of <see cref="Uri" />
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Uri" />
        /// to its ‘expanded’ version.
        /// </summary>
        /// <param name="expandableUri"></param>
        /// <returns></returns>
        public static async Task<Uri> ToExpandedUriAsync(this Uri expandableUri)
        {
            if (expandableUri == null) throw new ArgumentNullException($"The expected {nameof(expandableUri)} is not here.");

            var message = new HttpRequestMessage(HttpMethod.Get, expandableUri);
            var response = await message.SendAsync();

            if ((response.Headers.Location == null) &&
                (response.StatusCode == HttpStatusCode.OK))
            {
                return message.RequestUri;
            }

            if (response.IsMovedOrRedirected())
            {
                return response.Headers.Location;
            }

            return await response.Headers.Location.ToExpandedUriAsync();
        }

        /// <summary>
        /// Converts the specified <see cref="Uri" />
        /// to its ‘expanded’ version.
        /// </summary>
        /// <param name="expandableUri"></param>
        /// <returns></returns>
        public static async Task<KeyValuePair<Uri, Uri>> ToExpandedUriPairAsync(this Uri expandableUri)
        {
            var expandedUri = await expandableUri.ToExpandedUriAsync();
            return new KeyValuePair<Uri, Uri>(expandableUri, expandedUri);
        }
    }
}