using DamienVdk.DialogFlowNetTools.FulfillmentIntent.Attributes;
using DamienVdk.DialogFlowNetTools.FulfillmentIntent.Contracts;
using Google.Cloud.Dialogflow.V2;

namespace SampleToDelete.Intents;

[Intent("^Hello$")]
public class HelloIntentHandler : IIntentHandler
{
    public HelloIntentHandler(IServiceProvider _serviceProvider){}
    
    public Task<WebhookResponse> GetResponseAsync(WebhookRequest request)
    {
        return Task.FromResult(new WebhookResponse() { FulfillmentText = "Hello!" });
    }
}