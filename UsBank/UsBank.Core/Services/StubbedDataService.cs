using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsBank.Core.Stubbed;

namespace UsBank.Core.Services
{
    public class StubbedDataService
    {
        public async Task<List<LeadData>> GetLeadData(string usename)
        {
            await Task.Delay(2000);
            return new List<LeadData>
            {
                new LeadData
                {
                    LeadId = Guid.Empty,
                    LeadName = "Irvin Black",
                    ProductName = "30-Year Fixed - Jumbo",
                },
                new LeadData
                {
                    LeadId = Guid.Empty,
                    LeadName = "Isabelle Benson",
                    ProductName = "15-Year Fixed - VA - Purchase",
                },
                new LeadData
                {
                    LeadId = Guid.Empty,
                    LeadName = "Irvin Black",
                    ProductName = "30-Year Fixed - Jumbo",
                },
            };
        }

        public async Task<LeadDetails> GetLeadDetailsInfo(string leadname)
        {
            await Task.Delay(2000);
            return new LeadDetails
            {
                Address = "HSG Street",
                City = "Chicago",
                Description = "",
                DOB = "10/6/1992 6:30:00 PM",
                FullName = "Owen Pratt",
                Gender = "Male",
                leadId = Guid.Empty,
                leadNumber = "LD-00003",
                PhoneNo = "",
                Product = "30-Year Fixed - Jumbo",
                State = "Chicago",
            };
        }

        public async Task<List<user>> GetUserData(string username)
        {
            return new List<user>
            {
                new user
                {
                    userid = Guid.Empty,
                    username = "Lary Johnon",
                    userImage = "/Assets/Pic3.png"
                },
                new user
                {
                    userid = Guid.Empty,
                    username = "Nicole Anderson",
                    userImage = "/Assets/Pic2.png"
                },
                new user
                {
                    userid = Guid.Empty,
                    username = "Brian David",
                    userImage = "/Assets/Pic1.png"
                },
            };
        }
    }
}
