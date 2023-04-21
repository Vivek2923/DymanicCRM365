

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using UoPeople.NGPortal.Service.Repository.MSDynamics.Connection;
using UoPeople.NGPortal.Service.Settings;
using UoPeople.NGPortal.Utility;

namespace UoPeople.NGPortal.Service.Repository.MSDynamics
{
    public class DynamicsRepository : IDynamicsRepository
    {
        private readonly IDynamicsConnectionManager connectionManager;
        private Int16 newPADurationInDays;
        public DynamicsRepository(IConfiguration configuration, IDynamicsConnectionManager _crmConnManager)
        {
            var appConfig = configuration.GetSection(nameof(ApplicationConfig)).Get<ApplicationConfig>();
            newPADurationInDays = appConfig.NewPADurationInDays;
            connectionManager = _crmConnManager;
        }

        public async Task<string> Insert(string studentID)
        {

            // Define the query expression
            QueryExpression query = new QueryExpression("account");

            // Add the columns to retrieve
            query.ColumnSet = new ColumnSet("new_age", "new_dateofbirth", "new_firstname", "new_middlename", "new_familyname", "new_street1", "new_street2", "new_studentstatus");

            // Add the filter criteria
            query.Criteria.AddCondition("accountid", ConditionOperator.Equal, studentID);

            EntityCollection firstItem = await connectionManager.getConnection().RetrieveMultipleAsync(query);

            if (firstItem != null)
            {
                Entity result = firstItem.Entities.FirstOrDefault();
                var FirstName = result.GetAttributeValue<string>("new_firstname");
                var LastName = result.GetAttributeValue<string>("new_familyname");
                var myAccount = new Entity("new_studentlatestupdate");
                myAccount.Attributes["new_name"] = FirstName + " " + LastName;
                Guid RecordID = connectionManager.getConnection().Create(myAccount);

                return FirstName + " " + LastName + " record added successfully.StudenID = " + RecordID;
            }
            else{
                return "No record found";
            }
            
        }

        public async Task<string> Update(string studentID)
        {

            // Define the query expression
            QueryExpression query = new QueryExpression("new_studentlatestupdate");

            // Add the columns to retrieve
            query.ColumnSet = new ColumnSet("new_name");

            // Add the filter criteria
            query.Criteria.AddCondition("new_studentlatestupdateid", ConditionOperator.Equal, studentID);

            EntityCollection firstItem = await connectionManager.getConnection().RetrieveMultipleAsync(query);

            if (firstItem != null)
            {
                Entity result = firstItem.Entities.FirstOrDefault();
                var FName = result.GetAttributeValue<string>("new_name");
                var myAccount = new Entity("new_studentlatestupdate");
                myAccount.Id = new Guid(studentID);
                myAccount.Attributes["new_name"] = FName + " Edited";
                connectionManager.getConnection().Update(myAccount);
                return FName + " record updated successfully.";
            }
            else
            {
                return "No record found";
            }

        }

        public async Task<string> Delete(string studentID)
        {

            // Define the query expression
            QueryExpression query = new QueryExpression("new_studentlatestupdate");

            // Add the columns to retrieve
            query.ColumnSet = new ColumnSet("new_name");

            // Add the filter criteria
            query.Criteria.AddCondition("new_studentlatestupdateid", ConditionOperator.Equal, studentID);

            EntityCollection firstItem = await connectionManager.getConnection().RetrieveMultipleAsync(query);

            if (firstItem != null)
            {
                Entity result = firstItem.Entities.FirstOrDefault();
                var FName = result.GetAttributeValue<string>("new_name");
                Guid RecordID = new Guid(studentID);
                connectionManager.getConnection().Delete("new_studentlatestupdate", RecordID);
                return FName + " record deleted successfully.";
            }
            else
            {
                return "No record found";
            }

        }
    }
}
