using System.Data;
using Microsoft.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskMail_TaskHeader_Service : ITaskMail_TaskHeader_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public TaskMail_TaskHeader_Service(IConfiguration config, IMapper mapper)
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

        public List<TaskMail_TaskHeader_VM> TaskHeader(TaskMail_TaskHeader_VM taskHeader_VM,TaskHeaderSupplements taskHeaderSupplements)
        {
            var taskHeader = new List<TaskMail_TaskHeader_VM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add(Constant.Resource, taskHeaderSupplements.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Type, taskHeaderSupplements.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Month, taskHeaderSupplements.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Date, taskHeaderSupplements.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Year, taskHeaderSupplements.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.In_Time, taskHeaderSupplements.In_Time, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Out_Time, taskHeaderSupplements.Out_Time, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Total_Duration, taskHeaderSupplements.Total_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Break_Duration, taskHeaderSupplements.Break_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Act_Work_Hours, taskHeaderSupplements.Act_Work_Hours, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constant.Comments, taskHeaderSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constant.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    taskHeader = con.Query<TaskMail_TaskHeader_VM>(Constant.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    string errmsg = parameters.Get<string>(Constant.errmsgTemplateTime);
                    if (!string.IsNullOrEmpty(errmsg))
                    {
                        taskHeader_VM.Message = errmsg;
                    }
                    else
                    {
                        taskHeader_VM.Message = "Inserted and fetched list successfully";
                    }

                    return taskHeader;
                }
            }
            catch (Exception ex)
            {
                taskHeader_VM.Message = "Login failed: " + ex.Message;
                return taskHeader; 
            }
        }
    }
}