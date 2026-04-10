using ChurchLiveScheduler.sdk.Models;

namespace ChurchLiveScheduler.sdk;

public interface IChurchLiveSchedulerClient
{
    Task<string> GetCurrentTimeAsync(CancellationToken cancellationToken = default);
    Task<GetNextResponse?> GetNextAsync(CancellationToken cancellationToken = default);
    Task<GetAllResponse?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<SeriesDto>?> GetSeriesListAsync(CancellationToken cancellationToken = default);
    Task<SeriesDto?> GetSeriesDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<UpdateSeriesResponse?> UpdateSeriesAsync(int id, CancellationToken cancellationToken = default);
    Task GetCancellationListAsync(int seriesId, CancellationToken cancellationToken = default);
}

public class ChurchLiveSchedulerClient(string baseUrl, string code) : BaseApiClient(baseUrl, code), IChurchLiveSchedulerClient
{
    public Task<string> GetCurrentTimeAsync(CancellationToken cancellationToken = default) =>
        GetStringAsync("/api/GetCurrentTime", cancellationToken);

    public Task<GetNextResponse?> GetNextAsync(CancellationToken cancellationToken = default) =>
        GetFromJsonAsync<GetNextResponse>("/api/GetNext", cancellationToken);

    public Task<GetAllResponse?> GetAllAsync(CancellationToken cancellationToken = default) =>
        GetFromJsonAsync<GetAllResponse>("/api/Getall", cancellationToken);

    public Task<List<SeriesDto>?> GetSeriesListAsync(CancellationToken cancellationToken = default) =>
        AuthorizedGetFromJsonAsync<List<SeriesDto>?>("/api/series", cancellationToken);

    public Task<SeriesDto?> GetSeriesDetailAsync(int id, CancellationToken cancellationToken = default) =>
        AuthorizedGetFromJsonAsync<SeriesDto?>($"/api/series/{id}", cancellationToken);

    public Task<UpdateSeriesResponse?> UpdateSeriesAsync(int id, CancellationToken cancellationToken = default) =>
        AuthorizedPutFromJsonAsync<UpdateSeriesResponse?>($"/api/series/{id}", cancellationToken);

    public Task GetCancellationListAsync(int seriesId, CancellationToken cancellationToken = default) =>
        AuthorizedGetFromJsonAsync<List<CancellationDto>?>($"/api/series/{seriesId}/cancellations", cancellationToken);
}
