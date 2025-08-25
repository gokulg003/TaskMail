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
        public const string Resource = "@ResourceCode";
        public const string Type = "@TypeCode";
        public const string Month = "@Month";
        public const string Date = "@Date";
        public const string Year = "@Year";
        public const string InTime = "@InTime";
        public const string OutTime = "@OutTime";
        public const string TotalDuration = "@TotalDuration";
        public const string BreakDuration = "@BreakDuration";
        public const string ActWorkHours = "@ActWorkHours";
        public const string Comments = "@Comments";
        public const string InsertedBy = "@UserName";
        public const string UserFK = "@UserFk";
        public const string HeaderResourceFk = "@HeaderResourceFk";
        //update
        public const string HeaderId = "@HeaderPk";

        //get
        public const string Fromdate = "@Fromdate";
        public const string Todate = "@Todate";

        //TaskDetails
        public const string errmsgDetails = "@Errormsg";
        public const string StatusDetails = "@Status";
        public const string Project = "@ProjectCode";
        public const string Sprint = "@Sprint";
        public const string TaskName = "@TaskName";
        public const string Types = "@TypeCode";
        public const string SOWIssueNo = "@SOWIssueNo";
        public const string IsBillable = "@IsBillable";
        public const string BillingType = "@BillingTypeCode";
        public const string ResName = "@ResName";
        public const string Team = "@TeamCode";
        public const string EstStDt = "@EstStDt";
        public const string EstEndDt = "EstEndDt";
        public const string EstHours = "@EstHours";
        public const string ActStDt = "@ActStDt";
        public const string ActEndDt = "@ActEndDt";
        public const string StTime = "@StTime";
        public const string EndTime = "@EndTime";
        public const string ActHours = "@ActHours";
        public const string Percentage = "@Percentage";
        public const string Status = "@StatusCode";
        public const string CommentsDetails = "@Comments";
        public const string TaskHeaderFK = "@HeaderPk";
        public const string UsersFK = "@UsersFK";
        public const string UserName = "@UserName";
        public const string DetailsResourceId = "@DetailsResourceId";
        // public const string InsertDate = "@InsertDate";
        public const string UpdatedBy = "@UserName";
        // public const string UpdatedDate = "@UpdatedDate";
        public const string TMDetailsID = "@TaskDetailPk";

        //  public const string DetailsID = "TaskDetailsID";


        //CodeMaster
        public const string CodeType = "@CodeType";



        //Stored Procedure
        //Login
        public const string Login_SP = "TM_LoginValidation";
        //TaskHeaderInsert
        public const string TaskHeader_SP = "TM_TaskHeaderInsert";

        //TaskHeaderUpdate
        public const string TaskHeaderUpdate_SP = "TM_TaskHeaderUpdate";

        //TaskDetails
        public const string TaskDetails_SP = "TM_TaskDetails_Insert";

        //Code_MasterSP
        public const string CodeMasterSP = "TM_Code_Master_Retrieve";

        // TaskDetails Update
        public const string TaskDetails_Update_SP = "TM_TaskDetails_Update";
        //  TaskDetails Delete
        public const string TaskDetails_Delete_SP = "TM_TaskDetails_Delete";
        //TaskDetails Retrive

        public const string TaskDetails_Retrive_SP = "TM_RetriveTaskDetails";

        //TaskHeader Retrieve
        public const string TaskHeader_RetrieveSP = "TM_RetriveViewPageTaskHeader";


        // TaskMailSend
        public const string TaskMailSend_SP = "TM_MailSend";


    }
}