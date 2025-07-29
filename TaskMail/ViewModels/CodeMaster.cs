using System.Text.Json.Serialization;

namespace TaskMail.ViewModels;

public class CodeMasteVM
{
    public string CodeType { get; set; }
    public string CodeName { get; set; }
    public string ScreenName { get; set; }
    public string FullName { get; set; }

}