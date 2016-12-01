using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace WebApiWithUnitTests.Helpers
{
    public class AlwaysJsonContent : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;

        public AlwaysJsonContent(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(
                       Type type,
                       HttpRequestMessage request,
                       IEnumerable<MediaTypeFormatter> formatters)
        {
            // no complex logic. always return the json formatter
            var result = new ContentNegotiationResult(_jsonFormatter,
                             new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
}