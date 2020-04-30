using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public class DonationService: IDonationService
    {
        private readonly LibDbContext _context;

        public DonationService(LibDbContext context)
        {
            _context = context;
        }

        public async Task<Donation> Add(Donation donation)
        {
            _context.Donation.Add(donation);
            await _context.SaveChangesAsync();
            return donation;
        }

        public async Task<List<Donation>> Get()
        {
            return await _context.Donation.ToListAsync();
        }

        public async Task<Donation> Get(int id)
        {
            var donation = await _context.Donation.FindAsync(id);

            return donation;
        }
    }
}
