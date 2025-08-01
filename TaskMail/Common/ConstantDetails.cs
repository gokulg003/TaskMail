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

        public const string dbparamHeaderPk = "@HeaderPk";
        public const string HeaderPk = "HeaderPk";




        public const string TM_User_PK = "TM_User_PK";
        public const string TM_Type = "TM_Type";

        //Login

        public const string dbparamUserName = "@UserName";
        public const string dbparamPassword = "@Password";
       
        //TaskHeader
        public const string errmsg = "@ErrorMsgGrid";
        public const string Resource = "@Resource";
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
        public const string InsertedBy = "@UserId";
        public const string UserFK = "@UserFk";

        //TaskDetails
        public const string errmsgDetails = "@errormsg";
        public const string StatusDetails = "@StatusCode";
        public const string IdPK = "@ID_PK";
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
        public const string StTime = "@StTime";
        public const string EndTime = "@EndTime";
        public const string ActHours = "@ActHours";
        public const string Percentage = "@Percentage";
        public const string Status = "@Status";
        public const string CommentsDetails = "@Comments";
        public const string TaskHeaderFK = "@TaskHeaderFK";
        public const string UsersFK = "@UsersFK";
        public const string UserName = "@UserName";
        // public const string InsertDate = "@InsertDate";
        public const string UpdatedBy = "@UpdatedBy";
        // public const string UpdatedDate = "@UpdatedDate";
        // public const string TMDetailsID = "@TaskDetailsID";

        //  public const string DetailsID = "TaskDetailsID";


        //CodeMaster
        public const string CodeType = "@CodeType";

        //Stored Procedure
        //Login
        public const string Login_SP = "TM_LoginValidation";
        //TaskHeaderInsert
        public const string TaskHeader_SP = "TM_TaskHeader‌put";

        //TaskHeaderUpdate
        public const string TaskHeaderUpdate_SP = "TM_TaskHeaderUpdate";

        //TaskDetails
        public const string TaskDetails_SP = "TM_TaskDetails_Insert";

        //Code_MasterSP
        public const string CodeMasterSP = "TM_Retrive_DDL_TaskDetails";

        // TaskDetails Update
         public const string TaskDetails_Update_SP = "TM_TaskDetails_Update";

    }
}