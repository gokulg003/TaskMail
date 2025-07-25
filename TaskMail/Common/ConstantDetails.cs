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
        public const string errMsg = "ErrorMessage";


        public const string TM_Users_PK = "TM_Users_PK";
        // public const string UserName = "UsersName";
        // public const string Email = "Email";
        public const string TM_Type = "TM_Type";

        //Login
       
        public const string dbparamUsersName = "@UsersName";
        public const string dbparamPassword = "@Password";
        public const string Email = "@Email";

        //TemplateTime
        public const string errmsgTemplateTime = "@ErrorMsgGrid";
        public const string Resource = "@TM_UsersName";
        public const string Type = "@TM_Type";
        public const string Month = "@TM_Month";
        public const string Date = "@TM_Date";
        public const string Year = "@TM_Year";
        public const string In_Time = "@TM_In_Time";
        public const string Out_Time = "@TM_Out_Time";
        public const string Total_Duration = "@TM_Total_Duration";
        public const string Break_Duration = "@TM_Break_Duration";
        public const string Act_Work_Hours = "@TM_Act_Work_Hours";
        public const string Comments = "@TM_Comments";
        public const string TM_InsertedBy = "@TM_InsertedBy";
        public const string TM_InsertDate = "@TM_InsertDate";
        public const string TM_UpdatedBy = "@TM_UpdatedBy";
        public const string TM_UpdatedDate = "@TM_UpdatedDate";


        //Stored Procedure

        //Login
        public const string Login_SP = "TM_LoginValidation";

        //TaskHeader
        public const string TaskHeader_SP = "TM_TaskHeader‌put";





    }
}