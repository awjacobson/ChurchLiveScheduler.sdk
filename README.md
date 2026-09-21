# ChurchLiveScheduler.sdk

## Example Usage
```csharp
const string baseUrl = "https://__FUNCTIONS__.azurewebsites.net";
const string key = "__PRIVATE_KEY__";
var client = new ChurchLiveSchedulerClient(baseUrl, key);
var next = await client.GetNextAsync();
Console.WriteLine(JsonSerializer.Serialize(next));
```

## Version History

### 1.1.0 - 2026-09-21

- Switched to Source Generation to support Native AOT and trimmed apps
- target framework changed from .NET 8.0 to .NET 10.0

### 1.0.8 - 2026-04-14

- This README.md file added.
- BaseApiClient merged with ChurchLiveSchedulerClient and BaseApiClient removed.
- Cancellations and Specials added to the API.
- Special's Date property renamed to DateTime and the type changed to DateTime.