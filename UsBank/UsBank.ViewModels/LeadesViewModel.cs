
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using UsBank.Model;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;
using UsBank.Core.Utilities;
using UsBank.Core.Services;
using UsBank.Core.Stubbed;
using UsBank.Core;

namespace UsBank.ViewModels
{
    public class LeadsViewModel : BindableBase
    {
        private StubbedDataService _service;
        private IAccountManager _accountManager;

        private List<user> _users;
        private user _selectedUser;

        private List<LeadData> _leads;
        private LeadData _selectedLead;

        private LeadDetails _leadDetails;

        public LeadsViewModel(StubbedDataService service, IAccountManager accountManager)
        {
            _service = service;
            _accountManager = accountManager;
            GetLeadsCommand = new DelegateCommand(GetLeads);
            LoadCommand = new DelegateCommand(LoadData);
            GetLeadDetailsCommand = new DelegateCommand(GetLeadDetails);
        }

        public ICommand GetLeadsCommand { get; private set; }

        public ICommand GetLeadDetailsCommand { get; private set; }

        public ICommand LoadCommand { get; private set; }

        public List<user> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(() => Users);
            }
        }

        public user SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(() => SelectedUser);
            }
        }

        public List<LeadData> Leads
        {
            get { return _leads; }
            set
            {
                _leads = value;
                OnPropertyChanged(() => Leads);
            }
        }

        public LeadData SelectedLead
        {
            get { return _selectedLead; }
            set
            {
                _selectedLead = value;
                OnPropertyChanged(() => SelectedLead);
            }
        }

        public LeadDetails LeadDetails
        {
            get { return _leadDetails; }
            set
            {
                _leadDetails = value;
                OnPropertyChanged(() => LeadDetails);
            }
        }

        private void LoadData()
        {
            GetUsers();
            //_salesReps = new List<DummyLead> 
            //{
            //   new DummyLead
            //   {
            //       LeadId = "1",
            //       FirstName = "Lary",
            //       LastName = "Jhonson",
            //       Gender = "Male",
            //       DOB = DateTime.Now,
            //       ProductAndServices = "Credit Cards",
            //       Address = "54 Bsd Street Pune",
            //       Leads = new List<DummyLead>
            //       {
            //            new DummyLead
            //            {
            //                LeadId = "456",
            //                FirstName = "David",
            //                LastName = "Gray",
            //                Gender = "Male",
            //                DOB = DateTime.Now,
            //                ProductAndServices = "Home Mortgage",
            //                Address = "54 Bsd Street Mumbai",
            //            },
            //            new DummyLead
            //            {
            //                LeadId = "457",
            //                FirstName = "Luke",
            //                LastName = "Jhonson",
            //                Gender = "Male",
            //                DOB = DateTime.Now,
            //                ProductAndServices = "Credit Cards",
            //                Address = "54 Bsd Street Hyd",
            //            },
            //            new DummyLead
            //            {
            //                LeadId = "458",
            //                FirstName = "Lary",
            //                LastName = "Jhonson",
            //                Gender = "Male",
            //                DOB = DateTime.Now,
            //                ProductAndServices = "Credit Cards",
            //                Address = "54 Bsd Street Pune",
            //            },
            //            new DummyLead
            //            {
            //                LeadId = "459",
            //                FirstName = "Lary",
            //                LastName = "Jhonson",
            //                Gender = "Male",
            //                DOB = DateTime.Now,
            //                ProductAndServices = "Credit Cards",
            //                Address = "54 Bsd Street Pune",
            //            },
            //       },

            //   },

            //   new DummyLead
            //   {
            //       FirstName = "Nicole",
            //       LastName = "Anderson",
            //   },

            //   new DummyLead
            //   {
            //       FirstName = "Lary",
            //       LastName = "Jhonson",
            //   },
            //};
        }

        private async void GetLeadDetails()
        {
            LeadDetails = null;
            if (SelectedLead != null)
            {
                LeadDetails = await _service.GetLeadDetailsInfo(SelectedLead.LeadName);
            }
        }

        private async void GetLeads()
        {

            Leads = null;
            Leads = await _service.GetLeadData(SelectedUser.username);
        }

        private async void GetUsers()
        {
            Users = await _service.GetUserData(_accountManager.CurrentUser.UserId);
        }
    }

    public class DummyLead
    {
        public string LeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string FormattedDate { get { return DateParser.Parse(DOB); } }
        public string ProductAndServices { get; set; }
        public string Address { get; set; }
        public List<DummyLead> Leads { get; set; }
    }
}
