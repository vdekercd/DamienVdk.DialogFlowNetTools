namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDialogFlowFulfillment(this IServiceCollection @this)
    {
        @this.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
        @this.AddScoped<IDetectIntentAndGetResponseStrategy, DefaultDetectIntentAndGetResponseStrategy>();
        return @this;
    }
}