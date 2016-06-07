using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UsBank.Core.Stubbed;

namespace UsBank.Core.Services
{
    public class StubbedDataService
    {
        public const string CRMServiceURL = "https://usbankpmo.cognizant.com/MSCRM/Service1.svc";
        //"http://usbankerdesktoppoc.cognizant.com/Service1.svc";

        private static StubbedDataService _currentInstance = new StubbedDataService();

        public static StubbedDataService CurrentInstance
        {
            get
            {
                if(_currentInstance == null)
                {
                    _currentInstance = new StubbedDataService();
                }
                return _currentInstance;
            }
            
        }

        public bool IsMockup { get; set; }

        private CRMService.IService1 serviceClient;

        //should be private. need to change after validation on impact on private
        public StubbedDataService()
        {
            BasicHttpBinding basicBinding = new BasicHttpBinding();
            basicBinding.Security.Mode = BasicHttpSecurityMode.Transport;
            EndpointAddress serviceEndpoint = new EndpointAddress(CRMServiceURL);
            var channelFactory = new ChannelFactory<CRMService.IService1>(basicBinding, serviceEndpoint);
            serviceClient = channelFactory.CreateChannel();
            //serviceClient = new  CRMService.Service1Client();
        }

        public async Task<List<LeadData>> GetLeadData(string username)
        {
            if (IsMockup)
            {
                await Task.Delay(500);
                List<string> LeadNamelist = new List<string>() { "Irvin Black", "Isabelle Benson", "Charles siebert" };
                List<string> ProductNamelist = new List<string>() { "15-Year Fixed - Jumbo", "15-Year Fixed - VA - Purchase", "30-Year Fixed - Jumbo" };
                if (username.Contains("Nicole Anderson"))
                {
                    LeadNamelist = new List<string>() { "Mike Herman", "David Blatt", "Nicholas Aglen" };
                    ProductNamelist = new List<string>() {  "15-Year Fixed - VA - Purchase", "15-Year Fixed - Jumbo", "30-Year Fixed - Jumbo" };
                }
                if (username.Contains("Brian David"))
                {
                    LeadNamelist = new List<string>() { "Scott mccarron", "Jack huston", "Nancy  Kelly" };
                    ProductNamelist = new List<string>() { "30-Year Fixed - Jumbo", "15-Year Fixed - VA - Purchase", "15-Year Fixed - Jumbo" };
                }
                return new List<LeadData>
                {
                    new LeadData
                    {
                        LeadId = Guid.Empty,
                        LeadName = LeadNamelist[0],
                        ProductName = ProductNamelist[0],
                    },
                    new LeadData
                    {
                        LeadId = Guid.Empty,
                        LeadName = LeadNamelist[1],
                        ProductName = ProductNamelist[1],
                    },
                    new LeadData
                    {
                        LeadId = Guid.Empty,
                        LeadName = LeadNamelist[2],
                        ProductName = ProductNamelist[2],
                    },
                };
            }
            else
            {
                List<LeadData> leaddata = new List<LeadData>();
                ObservableCollection<UsBank.Core.CRMService.LeadData> leadlist = await serviceClient.GetLeadDataAsync(username);
                if (leadlist != null && leadlist.Count > 0)
                {
                    foreach (var leads in leadlist)
                    {
                        leaddata.Add(new LeadData() { LeadId = leads.LeadId, LeadName = leads.LeadName, ProductName = leads.ProductName });
                    }
                }
                return leaddata;
            }
        }

        public async Task<LeadDetails> GetLeadDetailsInfo(string leadname)
        {
            if (IsMockup)
            {
                await Task.Delay(500);
                List<LeadDetails> leaddetaillist = new List<LeadDetails>()
                {
                    new LeadDetails { Address = "HSG Street", City = "Chicago", Description = "", DOB = "10/6/1992 6:30:00 PM", FullName = "Irvin Black", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00001",  PhoneNo = "",  Product = "15-Year Fixed - Jumbo", State = "Chicago"},
                    new LeadDetails { Address = "Lakewood Avenue", City = "Chicago", Description = "", DOB = "12/8/1985 6:30:00 PM", FullName = "Charles siebert", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00002",  PhoneNo = "",  Product = "30-Year Fixed - Jumbo", State = "Chicago"},
                    new LeadDetails { Address = "W. Tremont St", City = "Chicago", Description = "", DOB = "9/12/1990 6:30:00 PM", FullName = "Isabelle Benson", Gender = "Female", leadId = Guid.Empty, leadNumber = "LD-00003",  PhoneNo = "",  Product = "15-Year Fixed - VA - Purchase", State = "Chicago"},
                    new LeadDetails { Address = "Peoria St", City = "Chicago", Description = "", DOB = "2/2/1980 6:30:00 PM", FullName = "Mike Herman", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00004",  PhoneNo = "",  Product = "15-Year Fixed - VA - Purchase", State = "Chicago"},
                    new LeadDetails { Address = "Lakewood Avenue", City = "Chicago", Description = "", DOB = "3/1/1987 6:30:00 PM", FullName = "David Blatt", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00005",  PhoneNo = "",  Product = "15-Year Fixed - Jumbo", State = "Chicago"},
                    new LeadDetails { Address = "W. Tremont St", City = "Chicago", Description = "", DOB = "4/4/1991 6:30:00 PM", FullName = "Nicholas Aglen", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00006",  PhoneNo = "",  Product = "30-Year Fixed - Jumbo", State = "Chicago"},
                    new LeadDetails { Address = "Peoria St", City = "Chicago", Description = "", DOB = "9/9/1986 6:30:00 PM", FullName = "Scott mccarron", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00007",  PhoneNo = "",  Product = "30-Year Fixed - Jumbo", State = "Chicago"},
                    new LeadDetails { Address = "Lakewood Avenue", City = "Chicago", Description = "", DOB = "8/12/1985 6:30:00 PM", FullName = "Jack huston", Gender = "Male", leadId = Guid.Empty, leadNumber = "LD-00008",  PhoneNo = "",  Product = "15-Year Fixed - VA - Purchase", State = "Chicago"},
                    new LeadDetails { Address = "HSG Street", City = "Chicago", Description = "", DOB = "7/3/1983 6:30:00 PM", FullName = "Nancy  Kelly", Gender = "Female", leadId = Guid.Empty, leadNumber = "LD-00009",  PhoneNo = "",  Product = "15-Year Fixed - Jumbo", State = "Chicago"},
                };
                var leaddetail = leaddetaillist.Where(o => o.FullName.Contains(leadname));
                if (leaddetail != null && leaddetail.Count() > 0)
                {
                    return leaddetail.FirstOrDefault();
                }
                else
                {
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
            }
            else
            {
                LeadDetails leadinfo = new LeadDetails();
                UsBank.Core.CRMService.LeadDetails leaddetail = await serviceClient.GetLeadDetailsInfoAsync(leadname);
                if (leaddetail != null)
                {
                    leadinfo = new LeadDetails()
                    {
                        Address = string.Format("{0} {1} {2}", leaddetail.Address, leaddetail.City, leaddetail.State),
                        City = leaddetail.City,
                        Description = leaddetail.Description,
                        DOB = leaddetail.DOB,
                        FullName = leaddetail.FullName,
                        Gender = leaddetail.Gender,
                        leadId = leaddetail.leadId,
                        leadNumber = leaddetail.leadNumber,
                        PhoneNo = leaddetail.PhoneNo,
                        Product = leaddetail.Product,
                        State = leaddetail.State

                    };
                }
                return leadinfo;
            }
            
        }

        public async Task<List<user>> GetUserData(string username)
        {
            if (IsMockup)
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
            else
            {
                //TODO : remove the hard coding one service return response for cath
                username = "Sagar Shirsath";
                List<user> userlist = new List<user>();
                ObservableCollection<UsBank.Core.CRMService.user> crmuserlist = await serviceClient.GetUserDataAsync(username);
                if (crmuserlist != null && crmuserlist.Count > 0)
                {
                    int i = 1;
                    foreach (var users in crmuserlist)
                    {
                        if (!users.username.Contains(username))
                        {
                            userlist.Add(new user() { userid = users.userid, username = users.username, userImage = string.Format("/Assets/Pic{0}.png", i++) });
                        }
                    }
                }
                return userlist;
            }
        }
    }
}
