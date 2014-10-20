using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Net;
using System.ServiceModel.Description;
using System.Text;
using UsBank.Core.ServiceReference1;

namespace UsBank.Core
{
    public class OrgnizationProxy
    {
        public OrgnizationProxy()
        {
            //IOrganizationService orgnizationService = GetOrganizationService();
            //StringBuilder sb = new StringBuilder();
            //QueryExpression query = new QueryExpression("phonecall");
            //query.ColumnSet = new ColumnSet("description", "modifiedby");
            //EntityCollection result = orgnizationService.RetrieveMultiple(query);

            OrganizationServiceClient client = new OrganizationServiceClient(new System.ServiceModel.BasicHttpBinding(), 
                new System.ServiceModel.EndpointAddress("https://cts11384.api.crm5.dynamics.com/XRMServices/2011/Organization.svc"));
        }

        internal static OrganizationServiceProxy GetOrganizationService()
        {
            try
            {
                ClientCredentials Credentials = new ClientCredentials();
                Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;

                //// Set the crmDomain
                Credentials.Windows.ClientCredential.Domain = "CTS";

                //// Set the crmUser
                Credentials.UserName.UserName = "pankajsvnit@cts11384.onmicrosoft.com";
                //Credentials.UserName.UserName = "bansal";

                //// Set the crmPassword
                Credentials.UserName.Password = "236eL4in";
                //Credentials.UserName.Password = "B15nCrDe";

                //Uri OrganizationUri = new Uri("http://bisw08tcrm0001/OneCRM/XRMServices/2011/Organization.svc");
                Uri OrganizationUri = new Uri("https://cts11384.api.crm5.dynamics.com/XRMServices/2011/Organization.svc");
                Uri HomeRealmUri = null;

                OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealmUri, Credentials, null);
                serviceProxy.EnableProxyTypes();

                return serviceProxy;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
