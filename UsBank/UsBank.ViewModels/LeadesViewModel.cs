
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using UsBank.Model;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;

namespace UsBank.ViewModels
{
    public class LeadsViewModel : BindableBase
    {
        private List<DummyLead> _leads;
        private List<DummyLead> _selectedLeadDetails;
        private DummyLead _selectedLeadDetail;

        public LeadsViewModel()
        {
            LoadCommand = new DelegateCommand(LoadData);
            LeadDetailsCommand = new DelegateCommand(GetLeadDetails);
        }
        public ICommand LoadCommand { get; private set; }
        public ICommand LeadDetailsCommand { get; private set; }

        public List<DummyLead> Leads
        {
            get { return _leads; }
        }

        public List<DummyLead> SelectedLeadDetails
        {
            get { return _selectedLeadDetails; }
            set
            {
                _selectedLeadDetails = value;
                OnPropertyChanged(() => SelectedLeadDetails);
            }
        }

        public DummyLead SelectedLeadDetail
        {
            get { return _selectedLeadDetail; }
            set
            {
                _selectedLeadDetail = value;
                OnPropertyChanged(() => SelectedLeadDetail);
            }
        }

        private void LoadData()
        {
            _leads = new List<DummyLead> 
            {
               new DummyLead
               {
                   LeadId = "1",
                   FirstName = "Lary",
                   LastName = "Jhonson",
                   Gender = "Male",
                   DOB = DateTime.Now,
                   ProductAndServices = "Credit Cards",
                   Address = "54 Bsd Street Pune",
                   Leads = new List<DummyLead>
                   {
                        new DummyLead
                        {
                            LeadId = "456",
                            FirstName = "David",
                            LastName = "Lavendor",
                            Gender = "Male",
                            DOB = DateTime.Now,
                            ProductAndServices = "Home Mortgage",
                            Address = "54 Bsd Street Mumbai",
                        },
                        new DummyLead
                        {
                            LeadId = "457",
                            FirstName = "Luke",
                            LastName = "Jhonson",
                            Gender = "Male",
                            DOB = DateTime.Now,
                            ProductAndServices = "Credit Cards",
                            Address = "54 Bsd Street Hyd",
                        },
                        new DummyLead
                        {
                            LeadId = "458",
                            FirstName = "Lary",
                            LastName = "Jhonson",
                            Gender = "Male",
                            DOB = DateTime.Now,
                            ProductAndServices = "Credit Cards",
                            Address = "54 Bsd Street Pune",
                        },
                        new DummyLead
                        {
                            LeadId = "459",
                            FirstName = "Lary",
                            LastName = "Jhonson",
                            Gender = "Male",
                            DOB = DateTime.Now,
                            ProductAndServices = "Credit Cards",
                            Address = "54 Bsd Street Pune",
                        },
                   },

               },

               new DummyLead
               {
                   FirstName = "Nicole",
                   LastName = "Anderson",
               },

               new DummyLead
               {
                   FirstName = "Lary",
                   LastName = "Jhonson",
               },
            };
        }

        private void GetLeadDetails()
        {
            var lead = Leads.FirstOrDefault(x => x.LeadId == SelectedLeadDetail.LeadId);
            SelectedLeadDetails = lead.Leads;
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
        public string ProductAndServices { get; set; }
        public string Address { get; set; }
        public List<DummyLead> Leads { get; set; }
    }
}
