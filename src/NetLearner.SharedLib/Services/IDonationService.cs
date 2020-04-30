using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public interface IDonationService
    {
        Task<List<Donation>> Get();
        Task<Donation> Get(int id);
        Task<Donation> Add(Donation donation);
    }
}
