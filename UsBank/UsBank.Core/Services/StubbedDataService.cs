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
        public const string CRMServiceURL = "http://usbankerdesktoppoc.cognizant.com/Service1.svc";

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
            EndpointAddress serviceEndpoint = new EndpointAddress(CRMServiceURL);
            var channelFactory = new ChannelFactory<CRMService.IService1>(basicBinding, serviceEndpoint);
            serviceClient = channelFactory.CreateChannel();
        }

        public async Task<List<LeadData>> GetLeadData(string username)
        {
            if (IsMockup)
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
                username = "Cathy Liz";
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
