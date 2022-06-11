namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class IntentAttribute : Attribute
{
    public IntentAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}