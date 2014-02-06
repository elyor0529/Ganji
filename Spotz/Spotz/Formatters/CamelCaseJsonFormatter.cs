using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http.Routing;


public class CamelCaseJsonFormatter : JsonMediaTypeFormatter
{
    private IHttpRouteData _route;


    public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
    {
        _route = request.GetRouteData();
        return base.GetPerRequestFormatterInstance(type, request, mediaType);
    }

    public override Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, HttpContent content, TransportContext transportContext)
    {
        // Set the SerializerSettings for the specific area
        this.SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
    }
}