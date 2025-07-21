namespace TaskMail.Services.common
{
    public class Constant
    {
        //DB
        public const string databaseName = "SITraining";


        //constants 

        //Login
        public const string errmsglogin = "@ErrorMsg";
        public const string UserName = "@UserName";
        public const string Password = "@Password";
        public const string Email = "@Email";

        //TemplateTime
        public const string errmsgTemplateTime = "@ErrorMsgGrid";
        public const string Resource = "@TM_Template_Time_PK";
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

        //Stored Procedure

        //Login
        public const string Login_SP = "Task_Mail_Login_SP";

        //Template Time
        public const string TemplateTime_SP = "TM_Template_Time_SP";



    }
}