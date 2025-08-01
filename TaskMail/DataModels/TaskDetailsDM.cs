using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class TaskDetailsDM
{
    public long TaskDetailPk { get; set; }
    public string Project { get; set; }
    public string Sprint { get; set; }
    public string TaskName { get; set; }
    public string TM_Type { get; set; }
    public string SOWIssueNo { get; set; }
    public string IsBillable { get; set; }
    public string BillingType { get; set; }
    public string ResName { get; set; }
    public string Team { get; set; }
    public DateTime EstStDt { get; set; }
    public DateTime EstEndDt { get; set; }
    public TimeSpan EstHours { get; set; }
    public DateTime ActStDt { get; set; }
    public DateTime ActEndDt { get; set; }
    public TimeSpan StTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public TimeSpan ActHours { get; set; }
    public int Percentage { get; set; }
    public string TM_Status { get; set; }
    public string? Comments { get; set; }
    public int TaskHeader_FK{ get; set; }
    public string InsertedBy { get; set; }
    // public string InsertDate { get; set; }
    // public string UpdatedBy { get; set; }
    // public string UpdatedDate{ get; set; }    
}
