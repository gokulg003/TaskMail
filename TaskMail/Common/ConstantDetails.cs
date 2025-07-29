namespace TaskMail.common
{
    public class ConstantDetails
    {
        //DB
        public const string databaseName = "SimpleInspireDB";


        //constants 
        public const string dbparamstatus = "@Status";
        public const string dbparamerrmsglogin = "@ErrorMsg";
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
        public const string errmsgTemplateTime = "@ErrorMsgGrid";
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



        //Stored Procedure
        //Login
        public const string Login_SP = "TM_LoginValidation";
        //TaskHeader
        public const string TaskHeader_SP = "TM_TaskHeader‌put";
        //TaskDetails
         public const string TaskDetails_SP = "TM_TaskDetails_Insert";

    }
}