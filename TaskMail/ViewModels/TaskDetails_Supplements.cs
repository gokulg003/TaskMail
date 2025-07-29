// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;

// namespace TaskMail.ViewModels;

// public class TaskDetailsSupplements
// {
//     public string Project { get; set; }
//     public string Sprint { get; set; }
//     public string TaskName { get; set; }
//     public string Type { get; set; }
//     public string SOWIssueNo { get; set; }
//     public string IsBillable { get; set; }
//     public string BillingType { get; set; }
//     public string ResName { get; set; }
//     public string Team { get; set; }
//     public string EstStDt { get; set; }
//     public string EstEndDt { get; set; }
//     public DateTime EstStartDate() => DateTime.ParseExact(EstStDt, "M/d/yyyy", null);
//     public DateTime EstEndDate() => DateTime.ParseExact(EstEndDt, "M/d/yyyy", null);
//     public string EstHours { get; set; }
//     public string ActStDt { get; set; }
//     public string ActEndDt { get; set; }
//     public DateTime ActStartDate() => DateTime.ParseExact(ActStDt, "M/d/yyyy", null);
//     public DateTime ActEndDate() => DateTime.ParseExact(ActEndDt, "M/d/yyyy", null);
//     public string StTime { get; set; }
//     public string EndTime { get; set; }
//     public string ActHours { get; set; }
//     public int Percentage { get; set; }
//     public string Status { get; set; }
//     public string Comments { get; set; }
// }