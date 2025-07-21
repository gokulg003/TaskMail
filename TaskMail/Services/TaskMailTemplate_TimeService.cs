using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskMailTemplateTime_Service : ITaskMailTemplateTime_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public TaskMailTemplateTime_Service(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<TaskMail_Template_Time_VM> Template_Time(TaskMail_Template_Time_VM templateTime_VM,TemplateTimeSupplements templateTimeSupplements)
        {
            var templatetime = new List<TaskMail_Template_Time_VM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add(Constant.Resource, templateTimeSupplements.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Type, templateTimeSupplements.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Month, templateTimeSupplements.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Date, templateTimeSupplements.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Year, templateTimeSupplements.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.In_Time, templateTimeSupplements.In_Time, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Out_Time, templateTimeSupplements.Out_Time, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Total_Duration, templateTimeSupplements.Total_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Break_Duration, templateTimeSupplements.Break_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Act_Work_Hours, templateTimeSupplements.Act_Work_Hours, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Comments, templateTimeSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    templatetime = con.Query<TaskMail_Template_Time_VM>(Constant.TemplateTime_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    string errmsg = parameters.Get<string>(Constant.errmsgTemplateTime);
                    if (!string.IsNullOrEmpty(errmsg))
                    {
                        templateTime_VM.Message = errmsg;
                    }
                    else
                    {
                        templateTime_VM.Message = "Inserted and fetched list successfully";
                    }

                    return templatetime;
                }
            }
            catch (Exception ex)
            {
                templateTime_VM.Message = "Login failed: " + ex.Message;
                return templatetime; 
            }
        }
    }
}