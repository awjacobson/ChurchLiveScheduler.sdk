using System.Net.Http.Json;
using System.Text.Json.Serialization;
using ChurchLiveScheduler.sdk.Models;

namespace ChurchLiveScheduler.sdk;

public sealed class ChurchLiveSchedulerClient : IChurchLiveSchedulerClient
{
    private readonly HttpClient _client;
    private readonly string _code;

    public ChurchLiveSchedulerClient(string baseUrl, string code)
    {
        _code = code;
        _client = new() { BaseAddress = new(baseUrl) };
        _client.DefaultRequestHeaders.Add("x-functions-key", _code);
    }

    public Task<string> GetCurrentTimeAsync(CancellationToken cancellationToken = default) =>
        _client.GetStringAsync("/api/GetCurrentTime", cancellationToken);

    public Task<GetNextResponse?> GetNextAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync("/api/GetNext", SourceGenerationContext.Default.GetNextResponse, cancellationToken);

    public Task<GetAllResponse?> GetAllAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync("/api/Getall", SourceGenerationContext.Default.GetAllResponse, cancellationToken);

    public Task<IEnumerable<SeriesDto>?> GetSeriesListAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync("/api/series", SourceGenerationContext.Default.IEnumerableSeriesDto, cancellationToken);

    public Task<SeriesDto?> GetSeriesDetailAsync(int id, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync($"/api/series/{id}", SourceGenerationContext.Default.SeriesDto, cancellationToken);

    public Task<UpdateSeriesResponse?> UpdateSeriesAsync(int id, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync($"/api/series/{id}", SourceGenerationContext.Default.UpdateSeriesResponse, cancellationToken);

    public Task<IEnumerable<CancellationDto>?> GetCancellationListAsync(int seriesId, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync($"/api/series/{seriesId}/cancellations", SourceGenerationContext.Default.IEnumerableCancellationDto, cancellationToken);

    public async Task<CancellationDto?> CreateCancellationAsync(int seriesId, CreateCancellationRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync($"/api/series/{seriesId}/cancellations", request, SourceGenerationContext.Default.CreateCancellationRequest, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.CancellationDto, cancellationToken) ?? new CancellationDto();
        }
        return null;
    }

    public async Task<UpdateCancellationResponse?> UpdateCancellationAsync(
        int seriesId, UpdateCancellationRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync($"/api/series/{seriesId}/cancellations", request, SourceGenerationContext.Default.UpdateCancellationRequest, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.UpdateCancellationResponse, cancellationToken) ?? new UpdateCancellationResponse();
        }
        return null;
    }

    public async Task<DeleteCancellationResponse?> DeleteCancellationAsync(int seriesId, int cancellationId, CancellationToken cancellationToken = default)
    {
        var response = await _client.DeleteAsync($"/api/series/{seriesId}/cancellations/{cancellationId}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.DeleteCancellationResponse, cancellationToken);
        }
        return null;
    }

    public Task<IEnumerable<SpecialDto>?> GetSpecialsAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<IEnumerable<SpecialDto>?>("/api/specials", cancellationToken);

    public async Task<CreateSpecialResponse?> CreateSpecialAsync(CreateSpecialRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync($"/api/specials", request, SourceGenerationContext.Default.CreateSpecialRequest, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.CreateSpecialResponse, cancellationToken);
        }
        return null;
    }

    public async Task<UpdateSpecialResponse?> UpdateSpecialAsync(int specialId, UpdateSpecialRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync($"/api/specials/{specialId}", request, SourceGenerationContext.Default.UpdateSpecialRequest, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.UpdateSpecialResponse, cancellationToken);
        }
        return null;
    }

    public async Task<DeleteSpecialResponse?> DeleteSpecialAsync(int specialId, CancellationToken cancellationToken = default)
    {
        var response = await _client.DeleteAsync($"/api/specials/{specialId}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync(SourceGenerationContext.Default.DeleteSpecialResponse, cancellationToken);
        }
        return null;
    }
}

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(GetNextResponse))]
[JsonSerializable(typeof(GetAllResponse))]
[JsonSerializable(typeof(IEnumerable<SeriesDto>))]
[JsonSerializable(typeof(SeriesDto))]
[JsonSerializable(typeof(UpdateSeriesResponse))]
[JsonSerializable(typeof(CreateCancellationRequest))]
[JsonSerializable(typeof(IEnumerable<CancellationDto>))]
[JsonSerializable(typeof(CancellationDto))]
[JsonSerializable(typeof(UpdateCancellationRequest))]
[JsonSerializable(typeof(UpdateCancellationResponse))]
[JsonSerializable(typeof(DeleteCancellationResponse))]
[JsonSerializable(typeof(IEnumerable<SpecialDto>))]
[JsonSerializable(typeof(CreateSpecialRequest))]
[JsonSerializable(typeof(CreateSpecialResponse))]
[JsonSerializable(typeof(UpdateSpecialRequest))]
[JsonSerializable(typeof(UpdateSpecialResponse))]
[JsonSerializable(typeof(DeleteSpecialResponse))]
internal partial class SourceGenerationContext : JsonSerializerContext { }