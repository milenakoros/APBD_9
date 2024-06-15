using APBD_9.Models;

namespace APBD_9.Repositories;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllTripsAsync();
    Task<Trip?> GetTripByIdAsync(int tripId);
    Task<bool> SaveChangesAsync();
}