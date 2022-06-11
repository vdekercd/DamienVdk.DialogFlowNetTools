using Google.Cloud.Dialogflow.V2;

namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Contracts;

public interface IIntentHandler
{
    Task<WebhookResponse> GetResponseAsync(WebhookRequest request);
}