using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskDetailsService : ITaskDetailsService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskDetailsService(IConfiguration config, IMapper mapper, HttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor; ;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }

        public List<TaskHeaderVM> TaskDetails(TaskDetailsVM taskDetailsVM, TaskDetailsSupplements taskDetailsSupplements)
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
                    parameters.Add(ConstantDetails.Resource, taskDetailsSupplements.Project, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Sprint, taskDetailsSupplements.Sprint, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TaskName, taskDetailsSupplements.TaskName, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Type, taskDetailsSupplements.Type, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsSupplements.SOWIssueNo, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.IsBillable, taskDetailsSupplements.IsBillable, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BillingType, taskDetailsSupplements.BillingType, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ResName, taskDetailsSupplements.ResName, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Team, taskDetailsSupplements.Team, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstStDt, taskDetailsSupplements.EstStDt, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstEndDt, taskDetailsSupplements.EstEndDt, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstHours, taskDetailsSupplements.EstHours, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActStDt, taskDetailsSupplements.ActStDt, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActEndDt, taskDetailsSupplements.ActEndDt, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.StTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EndTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActHours, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Percentage,taskDetailsSupplements.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.CommentsDetails, taskDetailsSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InsertedBy, UserName, DbType.String);  
                    parameters.Add(ConstantDetails.InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.UpdatedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.UpdatedDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.Users_FK, UserId, DbType.String);

                    parameters.Add(ConstantDetails.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    taskHeader = con.Query<TaskHeaderVM>(ConstantDetails.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    string errmsg = parameters.Get<string>(ConstantDetails.errmsgTemplateTime);

                    parameters.Add(ConstantDetails.TM_InsertedBy, UserName, DbType.String);  
                    parameters.Add(ConstantDetails.TM_InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_UpdatedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.TM_UpdatedDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_Users_FK, UserId, DbType.String);

                }
            }
            catch
            {
                
            }
        }
    }
}