using System;
using System.Collections.Generic;
using System.Text;

namespace NetLearner.SharedLib.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string TrackingNumber { get; set; }
        public string DonationItems { get; set; }        
    }
}
