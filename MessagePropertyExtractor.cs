using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MessagePropertyExtractor
{
    public static List<Dictionary<string, string>> ExtractPropertiesFromServiceBusMessages(string jsonData, List<string> propertiesToExtract, bool filterDuplicates)
    {
        var extractedValues = new List<Dictionary<string, string>>();
        var messages = JsonConvert.DeserializeObject<List<ServiceBusMessage>>(jsonData);

        foreach (var message in messages)
        {
            var body = JObject.Parse(message.Body);
            if (body.ContainsKey("EntityName") && body["EntityName"].ToString() == "BillOfQuantity")
            {
                var extractedValue = new Dictionary<string, string>();
                var shouldAddMessage = true;

                foreach (var propertyName in propertiesToExtract)
                {
                    if (body.ContainsKey(propertyName))
                    {
                        var value = body[propertyName].ToString();
                        extractedValue[propertyName] = value;
                    }
                    else
                    {
                        shouldAddMessage = false;
                        break;
                    }
                }

                if (shouldAddMessage && (!filterDuplicates || !extractedValues.Any(ev => ev.SequenceEqual(extractedValue))))
                {
                    extractedValues.Add(extractedValue);
                }
            }
        }

        return extractedValues;
    }
}

public class ServiceBusMessage
{
    public string Body { get; set; }
    // Add other properties if needed
}