﻿using APBD_9.Context;
using APBD_9.Models;
using APBD_9.Repositories;
using Microsoft.EntityFrameworkCore;

public class TripRepository : ITripRepository
{
    private readonly Apbd9Context _context;

    public TripRepository(Apbd9Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trip>> GetAllTripsAsync()
    {
        return await _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.IdCountries)
            .OrderByDescending(t => t.DateFrom)
            .ToListAsync();
    }

    public async Task<Trip?> GetTripByIdAsync(int tripId)
    {
        return await _context.Trips
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .Include(t => t.IdCountries)
            .FirstOrDefaultAsync(t => t.IdTrip == tripId);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}