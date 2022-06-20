namespace DamienVdk.DialogFlowNetTools.Integration.Contracts;

public interface IDialogFlowIntentDetecter
{
    Task<GoogleCloudDialogflowV2QueryResult> DetectIntentAsync(string sessionId, string text, CancellationToken cancellationToken = new CancellationToken());
    Task<GoogleCloudDialogflowV2QueryResult> DetectIntentAsync(string sessionId, string text, string language, CancellationToken cancellationToken = new CancellationToken());
}