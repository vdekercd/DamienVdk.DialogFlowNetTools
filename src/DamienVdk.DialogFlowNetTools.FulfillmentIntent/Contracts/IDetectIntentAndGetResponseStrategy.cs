namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Contracts;

public interface IDetectIntentAndGetResponseStrategy
{
    Task<WebhookResponse> DetectIntentAndReturnResponseAsync(WebhookRequest request);
}