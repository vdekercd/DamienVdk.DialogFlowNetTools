namespace DamienVdk.DialogFlowNetTools.Integration.Extensions;

public static class IServiceCollectionExtensions
{          
    public static IServiceCollection AddDialogFlowIntegration(this IServiceCollection @this, Action<DialogFlowIntegrationOption> configurationOption)
    {
        var dialogFlowIntegrationOption = new DialogFlowIntegrationOption() { DefaultLanguage = "en-US"};
        configurationOption(dialogFlowIntegrationOption);

        if (string.IsNullOrWhiteSpace(dialogFlowIntegrationOption.GoogleKeyFilePath))
            throw new MissingDialogConfigurationException("The Google key json file path must be specified!");
        
        if (string.IsNullOrWhiteSpace(dialogFlowIntegrationOption.GoogleKeyFilePath))
            throw new MissingDialogConfigurationException("The Google key json file path must be specified!");

        @this.AddSingleton<DialogFlowIntegrationOption>(dialogFlowIntegrationOption);
        @this.AddScoped<IDialogFlowIntentDetecter, DialogFlowIntentDetecter>();
        
        return @this;
    }
}