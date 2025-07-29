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
        public const string In_Time = "@InTime";
        public const string Out_Time = "@OutTime";
        public const string Total_Duration = "@TotalDuration";
        public const string Break_Duration = "@BreakDuration";
        public const string Act_Work_Hours = "@ActWorkHours";
        public const string Comments = "@Comments";
        public const string TM_InsertedBy = "@InsertedBy";
        public const string TM_InsertDate = "@InsertDate";
        public const string TM_UpdatedBy = "@UpdatedBy";
        public const string TM_UpdatedDate = "@UpdatedDate";
        public const string  TM_Users_FK = "@UsersFK";

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