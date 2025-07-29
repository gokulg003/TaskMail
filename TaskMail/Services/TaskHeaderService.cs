using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskHeaderService : ITaskHeaderService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskHeaderService(IConfiguration config, IMapper mapper, HttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }

        public List<TaskHeaderVM> TaskHeader(TaskHeaderVM taskHeaderVM,TaskHeaderSupplements taskHeaderSupplements)
        {
            var taskHeader = new List<TaskHeaderVM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    DateTime manualDate = new DateTime(2025, 07, 24, 14, 30, 0); 
                    string timeOnly = manualDate.ToString("HH:mm:ss");

                    var parameters = new DynamicParameters();
                    string UserId = _httpContextAccessor.HttpContext.Request.Headers["X-UserId"];
                    string UserName = _httpContextAccessor.HttpContext.Request.Headers["X-UserName"];

                    parameters.Add(ConstantDetails.Resource, taskHeaderSupplements.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Type, taskHeaderSupplements.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Month, taskHeaderSupplements.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Date, taskHeaderSupplements.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Year, taskHeaderSupplements.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.OutTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TotalDuration, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BreakDuration, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActWorkHours, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Comments, taskHeaderSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TM_InsertedBy, UserName, DbType.String);  
                    parameters.Add(ConstantDetails.TM_InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_UpdatedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.TM_UpdatedDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_Users_FK, UserId, DbType.String);

                    parameters.Add(ConstantDetails.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    taskHeader = con.Query<TaskHeaderVM>(ConstantDetails.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    string errmsg = parameters.Get<string>(ConstantDetails.errmsgTemplateTime);
                    if (!string.IsNullOrEmpty(errmsg))
                    {
                        taskHeaderVM.Message = errmsg;
                    }
                    else
                    {
                        taskHeaderVM.Message = "Inserted and fetched list successfully";
                    }

                    return taskHeader;
                }
            }
            catch (Exception ex)
            {
                taskHeaderVM.Message = "Login failed: " + ex.Message;
                return taskHeader; 
            }
        }
    }
}