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

        public List<TaskDetailsVM> TaskDetails(TaskDetailsVM taskDetailsVM, out int status, out string message)
        {
            var taskDetails = new List<TaskDetailsVM>();
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
                    parameters.Add(ConstantDetails.Resource, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Type, taskDetailsVM.Type, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsVM.SOWIssueNo, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.IsBillable, taskDetailsVM.IsBillable, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BillingType, taskDetailsVM.BillingType, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ResName, taskDetailsVM.ResName, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Team, taskDetailsVM.Team, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstStDt, taskDetailsVM.EstStDt, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstEndDt, taskDetailsVM.EstEndDt, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EstHours, taskDetailsVM.EstHours, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActStDt, taskDetailsVM.ActStDt, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActEndDt, taskDetailsVM.ActEndDt, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.StTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.EndTime, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActHours, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Percentage, taskDetailsVM.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InsertedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.UpdatedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.UpdatedDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.Users_FK, UserId, DbType.String);

                    taskDetails = con.Query<TaskDetailsVM>(ConstantDetails.TaskDetails_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

                    status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                    message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return taskDetails;
        }
    }
}