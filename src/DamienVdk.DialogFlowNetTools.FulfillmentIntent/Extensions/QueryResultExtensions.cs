namespace DamienVdk.DialogFlowNetTools.FulfillmentIntent.Extensions;

public static class QueryResultExtensions
{
    public static double GetNumberFieldOrDefaultValue(this QueryResult @this, string fieldName, double defaultValue = default)
    {
        var intFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName);
        return intFromRequest.Value?.NumberValue ?? defaultValue;
    }

    public static bool GetBoolFieldOrDefaultValue(this QueryResult @this, string fieldName, bool defaultValue = default)
    {
        var intFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName);
        return intFromRequest.Value?.BoolValue ?? defaultValue;
    }

    public static string GetStringFieldOrDefaultValue(this QueryResult @this, string fieldName, string defaultValue = "")
    {
        var stringFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName);
        return string.IsNullOrWhiteSpace(stringFromRequest.Value.ToString()) ? defaultValue : stringFromRequest.Value.ToString();
    }
    
    public static List<double> GetNumberFieldList(this QueryResult @this, string fieldName)
    {
        var intListFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName).Value;
        return intListFromRequest.ListValue.Values.Select(item => item.NumberValue).ToList();
    }

    public static List<bool> GetBoolFieldList(this QueryResult @this, string fieldName)
    {
        var intListFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName).Value;
        return intListFromRequest.ListValue.Values.Select(item => item.BoolValue).ToList();
    }

    public static List<string> GetStringFieldList(this QueryResult @this, string fieldName,  string defaultValue = "")
    {
        var stringListFromRequest = @this.Parameters.Fields.FirstOrDefault(item => item.Key == fieldName).Value;
        var list = stringListFromRequest.ListValue.Values.Select(item => item.StringValue).ToList();
        return list.Select(item => string.IsNullOrWhiteSpace(item.ToString()) ? defaultValue : item.ToString()).ToList();
    }
}