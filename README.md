# ChurchLiveScheduler.sdk

## Example Usage
```csharp
const string baseUrl = "https://__FUNCTIONS__.azurewebsites.net";
const string key = "__PRIVATE_KEY__";
var client = new ChurchLiveSchedulerClient(baseUrl, key);
var next = await client.GetNextAsync();
Console.WriteLine(JsonSerializer.Serialize(next));
```
