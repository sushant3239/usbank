using System;

namespace UsBank.Core.Stubbed
{
    public class user
    {
        public Guid userid { get; set; }
        public string username { get; set; }
        // Added temporarily
        public string userImage { get; set; }
    }
    public class lead
    {
        public string username { get; set; }
        public Guid leadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class LeadData
    {
        public string LeadName { get; set; }
        public string ProductName { get; set; }
        public Guid LeadId { get; set; }
    }

    public class LeadDetails
    {
        public Guid leadId { get; set; }
        public string leadNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Product { get; set; }
        public string Address { get; set; }
    }

}
