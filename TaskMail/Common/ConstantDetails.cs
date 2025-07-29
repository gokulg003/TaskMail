namespace TaskMail.common
{
    public class ConstantDetails
    {
        //DB
        public const string databaseName = "SimpleInspireDB";


        //constants 
        public const string dbparamstatus = "@Status";
        public const string dbparamerrmsg = "@ErrorMsg";
        public const string status = "Status";
        public const string errMsg = "ErrorMsg";


        public const string TM_User_PK = "TM_User_PK";
        // public const string UserName = "UsersName";
        // public const string Email = "Email";
        public const string TM_Type = "TM_Type";

        //Login

        public const string dbparamUserName = "@UserName";
        public const string dbparamPassword = "@Password";
        public const string Email = "@Email";

        //TaskHeader
        public const string errmsg = "@ErrorMsgGrid";
        public const string Resource = "@UserName";
        public const string Type = "@Type";
        public const string Month = "@Month";
        public const string Date = "@Date";
        public const string Year = "@Year";
        public const string InTime = "@InTime";
        public const string OutTime = "@OutTime";
        public const string TotalDuration = "@TotalDuration";
        public const string BreakDuration = "@BreakDuration";
        public const string ActWorkHours = "@ActWorkHours";
        public const string Comments = "@Comments";
        public const string TM_InsertedBy = "@InsertedBy";
        public const string TM_InsertDate = "@InsertDate";
        public const string TM_UpdatedBy = "@UpdatedBy";
        public const string TM_UpdatedDate = "@UpdatedDate";
        public const string TM_Users_FK = "@UsersFK";

        //TaskDetails
        public const string errmsgDetails = "@errormsg";
        public const string StatusDetails = "@StatusCode";
        public const string Project = "@Project";
        public const string Sprint = "@Sprint";
        public const string TaskName = "@TaskName";
        public const string Types = "@Type";
        public const string SOWIssueNo = "@SOWIssueNo";
        public const string IsBillable = "@IsBillable";
        public const string BillingType = "@BillingType";
        public const string ResName = "@ResName";
        public const string Team = "@Team";
        public const string EstStDt = "@EstStDt";
        public const string EstEndDt = "EstEndDt";
        public const string EstHours = "@EstHours";
        public const string ActStDt = "@ActStDt";
        public const string ActEndDt = "@ActEndDt";
        public const string StTime = " @StTime";
        public const string EndTime = " @EndTime";
        public const string ActHours = "@ActHours";
        public const string Percentage = "@Percentage";
        public const string Status = "@Status";
        public const string CommentsDetails = "@Comments";
        public const string TaskHeaderFK = "@TaskHeaderFK";
        public const string Users_FK = "@UsersFK";
        public const string InsertedBy = "@InsertedBy";
        public const string InsertDate = "@InsertDate";
        public const string UpdatedBy = "@UpdatedBy";
        public const string UpdatedDate = "@UpdatedDate";

        //CodeMaster
        public const string CodeType = "@CodeType";

        //Stored Procedure
        //Login
        public const string Login_SP = "TM_LoginValidation";
        //TaskHeader
        public const string TaskHeader_SP = "TM_TaskHeader‌put";
        //TaskDetails
        public const string TaskDetails_SP = "TM_TaskDetails_Insert";

        //Code_MasterSP
        public const string CodeMasterSP = "TM_Retrive_DDL_TaskDetails";

    }
}