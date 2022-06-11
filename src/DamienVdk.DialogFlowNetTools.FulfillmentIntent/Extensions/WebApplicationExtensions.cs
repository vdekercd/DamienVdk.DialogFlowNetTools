namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Extensions;

public static class IApplicationBuilderExtensions
{
    private static JsonParser _jsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
    
    public static IEndpointRouteBuilder  MapFulfillmentIntent(this IEndpointRouteBuilder  @this, string endpoint)
    {
        @this.MapPost(endpoint,async (HttpRequest httpRequest, IDetectIntentAndGetResponseStrategy detectIntentAndGetResponseStrategy) =>
        {
            WebhookRequest request;
            using (var reader = new StreamReader(httpRequest.Body))
            {
                request = _jsonParser.Parse<WebhookRequest>(reader);
            }
            
            var jsonResponse = (await detectIntentAndGetResponseStrategy.DetectIntentAndReturnResponseAsync(request)).ToString();
            return new ContentResult { Content = jsonResponse, ContentType = "application/json" }.Content;
        });
        return @this;
    }
}