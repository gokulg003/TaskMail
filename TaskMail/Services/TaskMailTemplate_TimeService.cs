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
                return new SqlConnection(_config.GetConnectionString(Constant.databaseName));
            }
        }

        public List<TaskMail_Template_Time_DM> Template_Time(TaskMail_Template_Time_VM TemplateTime_VM,TemplateTimeSupplements templateTimeSupplements)
        {
            var templatetimedm = new List<TaskMail_Template_Time_DM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add(Constant.Resource, templateTimeSupplements.TM_Template_Time_PK , DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Type, templateTimeSupplements.TM_Type, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Month, templateTimeSupplements.TM_Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Date, templateTimeSupplements.TM_Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Year, templateTimeSupplements.TM_Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.In_Time, templateTimeSupplements.TM_In_Time, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Out_Time, templateTimeSupplements.TM_Out_Time, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Total_Duration, templateTimeSupplements.TM_Total_Duration, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Break_Duration, templateTimeSupplements.TM_Break_Duration, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Act_Work_Hours, templateTimeSupplements.TM_Act_Work_Hours, DbType.Int64, ParameterDirection.Input, 18); 
                    parameters.Add(Constant.Comments, templateTimeSupplements.TM_Comments, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);

                    templatetimedm = con.Query<TaskMail_Template_Time_DM>(Constant.TemplateTime_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                TemplateTime_VM.Message = "Login failed: " + ex.Message;
                return templatetimedm; 
            }
        }


    }
}