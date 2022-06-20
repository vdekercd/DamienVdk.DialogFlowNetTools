using DamienVdk.DialogFlowNetTools.Integration.Contracts;



namespace DamienVdk.DialogFlowNetTools.Integration.Services;

public class DialogFlowIntentDetecter : IDialogFlowIntentDetecter
{
    private readonly DialogFlowIntegrationOption _dialogFlowIntegrationOption;
    private GoogleCredential _googleCredential = null!;

    public DialogFlowIntentDetecter(DialogFlowIntegrationOption dialogFlowIntegrationOption)
    {
        _dialogFlowIntegrationOption = dialogFlowIntegrationOption;
    }

    public async Task<GoogleCloudDialogflowV2QueryResult> DetectIntentAsync(string sessionId, string text,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await DetectIntentAsync(sessionId, text, _dialogFlowIntegrationOption.DefaultLanguage, cancellationToken);
    }

    public async Task<GoogleCloudDialogflowV2QueryResult> DetectIntentAsync(string sessionId, string text, string language, CancellationToken cancellationToken = new CancellationToken())
    {
        var response = await new DialogflowService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = await GetGoogleCredentialScopeAsync(cancellationToken),
            ApplicationName = _dialogFlowIntegrationOption.ProjectId
        }).Projects.Agent.Sessions.DetectIntent(new GoogleCloudDialogflowV2DetectIntentRequest()
        {
            QueryInput = new GoogleCloudDialogflowV2QueryInput()
            {
                Text = new GoogleCloudDialogflowV2TextInput()
                {
                    Text = text,
                    LanguageCode = string.IsNullOrWhiteSpace(language)
                        ? _dialogFlowIntegrationOption.DefaultLanguage
                        : language
                }
            }
        }, $"projects/{_dialogFlowIntegrationOption.ProjectId}/agent/sessions/{sessionId}").ExecuteAsync();

        return response.QueryResult;
    }

    private async ValueTask<GoogleCredential> GetGoogleCredentialScopeAsync(CancellationToken cancellationToken)
    {
        if (_googleCredential == null)
        {
            using (Stream configStream = new FileStream(_dialogFlowIntegrationOption.GoogleKeyFilePath, FileMode.Open))
            {
                _googleCredential = await GoogleCredential.FromStreamAsync(configStream, cancellationToken);
            }
        }

        return _googleCredential.CreateScoped();
    }
}