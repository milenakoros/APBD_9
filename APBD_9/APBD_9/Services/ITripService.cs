using APBD_9.Models;

public interface ITripService
{
    Task<IEnumerable<Trip>> GetTripsAsync(int page, int pageSize);
}