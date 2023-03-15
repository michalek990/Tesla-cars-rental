﻿using backend.Entity;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class RentalRepository : BaseRepository<Rental>, IRentalRepository
{
    public RentalRepository(AppDbContext context) : base(context) { }


    public async Task<bool?> ExistByPeselNumber(string pesel)
    {
        return await Context.Rentals
            .Where(r => r.PeselNumber == pesel && r.RentalDateStart <= DateTime.Now && r.RentalDateEnd >= DateTime.Now)
            .AnyAsync();
    }
}