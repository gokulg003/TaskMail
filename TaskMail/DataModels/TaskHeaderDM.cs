using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskHeaderDM
{
    public string TM_UsersName { get; set; }
    public string TM_Type { get; set; }
    public long TM_Month { get; set; }
    public long TM_Date { get; set; }
    public long TM_Year { get; set; }
    public string TM_In_Time { get; set; }
    public string TM_Out_Time { get; set; }
    public string TM_Total_Duration { get; set; }
    public string TM_Break_Duration { get; set; }
    public string TM_Act_Work_Hours { get; set; }
    public string TM_Comments { get; set; }
    public string TM_InsertededBy { get; set; }
    public string TM_InsertDate { get; set; }
    public string TM_UpdatedBy { get; set; }
    public string TM_UpdatedDate{ get; set; }    
}

