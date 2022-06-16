# DamienVdk.DialogFlowNetTools
Tools to call an agent in DialogFlow, or to create a Fullfilment

## DamienVdk.DialogFlowNetTools.FulfillmentIntent
This nuget package allows you to quickly create a webhook for your DialogFlow agent

```powershell
Install-Package DamienVdk.DialogFlowNetTools.FulfillmentIntent
```

### Configuration

The configuration is done in the `program.cs` file. The first step is to add the necessary dependencies. This is easily done through an extension method, which adds the methode `AddDialogFlowFulfillment` to the `IServiceCollection` interface.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add services ...
builder.Services.AddDialogFlowFulfillment();
```

The second step is to map an endpoint that will be used by DialogFlow. As with `AddDialogFlowFulfillment`, a extension method `UseDialogFlowFulfillment`  is available in the package.

```csharp
var app = builder.Build();

app.UseDialogFlowFulfillment("/DialogFlow");
```

### Usage

When you create an intent in DialogFlow, you can respond to it via a fulfillment (webhook). In order to respect the Single Responsabilty Principle (SRP), the goal is to create a class by intent. 

In order not to have to write a long code composed of several if/else to detect which class called according to the intent, the package can automatically find the class to call and formulate the answer based on the name of the intent.

To create a class that will create the response of an intent, it is necessary to create a class with an attribute `Intent` which takes as a parameter a regex expression to know to which intent the class must respond. This class must also implement the `IIntentHandler` interface which has a method `GetResponseAsync`.

This class must have a constructor with a parameter of type `IServiceProvider`. From the latter, you can recover all the dependencies that your class needs.

```csharp
[Intent("^Hello$")]
public class HelloIntentHandler : IIntentHandler
{
    public HelloIntentHandler(IServiceProvider serviceProvider)
    {
        //_superDependency = serviceProvider.GetServices<ISuperDependency>()
    }
    
    public Task<WebhookResponse> GetResponseAsync(WebhookRequest request)
    {
        return Task.FromResult(new WebhookResponse() { FulfillmentText = "Hello response!" });
    }
}
```

