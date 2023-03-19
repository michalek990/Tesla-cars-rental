using backend.Interfaces;

namespace backend.Service.Rental;

public sealed class CheckEndRentalDate : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public CheckEndRentalDate(IServiceScopeFactory serviceScopeFactory)
    {
        _scopeFactory = serviceScopeFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        while (!stoppingToken.IsCancellationRequested)
        {
            await unitOfWork.Rentals.RemoveAllExpiredRentals();
            await unitOfWork.SaveAsync();
            await Task.Delay(3600, stoppingToken);
        }
    }
}