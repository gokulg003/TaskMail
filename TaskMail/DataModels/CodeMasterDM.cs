using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class CodeMasterDM
{
    public string CodeType { get; set; }
    public string CodeName { get; set; }
    public string ScreenName { get; set; }
    public string FullName { get; set; }
    public string DefaultFlag { get; set; }
    public long UserFk { get; set; }
    public long CodeId { get; set; }


}