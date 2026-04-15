using System.Net.Http.Json;
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
        _client.GetFromJsonAsync<GetNextResponse>("/api/GetNext", cancellationToken);

    public Task<GetAllResponse?> GetAllAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<GetAllResponse>("/api/Getall", cancellationToken);

    public Task<IReadOnlyList<SeriesDto>?> GetSeriesListAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<IReadOnlyList<SeriesDto>?>("/api/series", cancellationToken);

    public Task<SeriesDto?> GetSeriesDetailAsync(int id, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<SeriesDto?>($"/api/series/{id}", cancellationToken);

    public Task<UpdateSeriesResponse?> UpdateSeriesAsync(int id, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<UpdateSeriesResponse?>($"/api/series/{id}", cancellationToken);

    public Task<IReadOnlyList<CancellationDto>?> GetCancellationListAsync(int seriesId, CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<IReadOnlyList<CancellationDto>?>($"/api/series/{seriesId}/cancellations", cancellationToken);

    public async Task<CancellationDto?> CreateCancellationAsync(int seriesId, CreateCancellationRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync($"/api/series/{seriesId}/cancellations", request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CancellationDto>(cancellationToken: cancellationToken) ?? new CancellationDto();
        }
        return null;
    }

    public async Task<UpdateCancellationResponse?> UpdateCancellationAsync(
        int seriesId, UpdateCancellationRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync($"/api/series/{seriesId}/cancellations", request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UpdateCancellationResponse>(cancellationToken: cancellationToken) ?? new UpdateCancellationResponse();
        }
        return null;
    }

    public async Task<DeleteCancellationResponse?> DeleteCancellationAsync(int seriesId, int cancellationId, CancellationToken cancellationToken = default)
    {
        var response = await _client.DeleteAsync($"/api/series/{seriesId}/cancellations/{cancellationId}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<DeleteCancellationResponse>(cancellationToken: cancellationToken) ?? new DeleteCancellationResponse();
        }
        return null;
    }

    public Task<IReadOnlyList<SpecialDto>?> GetSpecialsAsync(CancellationToken cancellationToken = default) =>
        _client.GetFromJsonAsync<IReadOnlyList<SpecialDto>?>("/api/specials", cancellationToken);

    public async Task<CreateSpecialResponse?> CreateSpecialAsync(CreateSpecialRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PostAsJsonAsync($"/api/specials", request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CreateSpecialResponse>(cancellationToken: cancellationToken);
        }
        return null;
    }

    public async Task<UpdateSpecialResponse?> UpdateSpecialAsync(int specialId, UpdateSpecialRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync($"/api/specials/{specialId}", request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UpdateSpecialResponse>(cancellationToken: cancellationToken);
        }
        return null;
    }

    public async Task<DeleteSpecialResponse?> DeleteSpecialAsync(int specialId, CancellationToken cancellationToken = default)
    {
        var response = await _client.DeleteAsync($"/api/specials/{specialId}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<DeleteSpecialResponse>(cancellationToken: cancellationToken);
        }
        return null;
    }
}
