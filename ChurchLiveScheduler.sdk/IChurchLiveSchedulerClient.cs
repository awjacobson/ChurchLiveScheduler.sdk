using ChurchLiveScheduler.sdk.Models;

namespace ChurchLiveScheduler.sdk;

public interface IChurchLiveSchedulerClient
{
    Task<string> GetCurrentTimeAsync(CancellationToken cancellationToken = default);
    Task<GetNextResponse?> GetNextAsync(CancellationToken cancellationToken = default);
    Task<GetAllResponse?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SeriesDto>?> GetSeriesListAsync(CancellationToken cancellationToken = default);
    Task<SeriesDto?> GetSeriesDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<UpdateSeriesResponse?> UpdateSeriesAsync(int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<CancellationDto>?> GetCancellationListAsync(int seriesId, CancellationToken cancellationToken = default);
    Task<CancellationDto?> CreateCancellationAsync(int seriesId, CreateCancellationRequest request, CancellationToken cancellationToken = default);
    Task<UpdateCancellationResponse?> UpdateCancellationAsync(int seriesId, UpdateCancellationRequest request, CancellationToken cancellationToken = default);
    Task<DeleteCancellationResponse?> DeleteCancellationAsync(int seriesId, int cancellationId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<SpecialDto>?> GetSpecialsAsync(CancellationToken cancellationToken = default);
    Task<CreateSpecialResponse?> CreateSpecialAsync(CreateSpecialRequest request, CancellationToken cancellationToken = default);
    Task<UpdateSpecialResponse?> UpdateSpecialAsync(int specialId, UpdateSpecialRequest request, CancellationToken cancellationToken = default);
    Task<DeleteSpecialResponse?> DeleteSpecialAsync(int specialId, CancellationToken cancellationToken = default);
}
