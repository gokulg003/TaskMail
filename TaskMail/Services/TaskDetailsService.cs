

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

        public TaskDetailsService(IConfiguration config, IMapper mapper, IHttpContextAccessor httpContextAccessor)
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

        public List<TaskDetailsVM> TaskDetails(List<TaskDetailsVM> taskDetailsList, out int status, out string message)
        {
            var insertedTaskDetails = new List<TaskDetailsVM>();
            status = -1;
            message = null;
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();

                    // string UserId = _httpContextAccessor.HttpContext.Request.Headers["X-UserId"];
                    // string UserName = _httpContextAccessor.HttpContext.Request.Headers["X-UserName"];
                    // string HeaderId = _httpContextAccessor.HttpContext.Request.Headers["X-HeaderId"];
                    int UserId = 22;
                    string UserName = "Devi";
                    int HeaderId = 222;

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();


                        parameters.Add(ConstantDetails.Project, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Type, taskDetailsVM.Type, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsVM.SOWIssueNo, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.IsBillable, taskDetailsVM.IsBillable, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.BillingType, taskDetailsVM.BillingType, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ResName, taskDetailsVM.ResName, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Team, taskDetailsVM.Team, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstStDt, taskDetailsVM.EstStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstEndDt, taskDetailsVM.EstEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstHours, taskDetailsVM.EstHours, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActStDt, taskDetailsVM.ActStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActEndDt, taskDetailsVM.ActEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.StTime, taskDetailsVM.StTime, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EndTime, taskDetailsVM.EndTime, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActHours, taskDetailsVM.ActHours, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Percentage, taskDetailsVM.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Status, taskDetailsVM.Status, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.UserID, UserId, DbType.String);
                        // parameters.Add(ConstantDetails.InsertDate, DateTime.Now, DbType.DateTime);
                        // parameters.Add(ConstantDetails.UpdatedBy, DateTime.Now UserName, DbType.String);
                        // parameters.Add(ConstantDetails.UpdatedDate, DateTime.Now, DbType.DateTime);
                        parameters.Add(ConstantDetails.UsersFK, UserId, DbType.String);
                        parameters.Add(ConstantDetails.TaskHeaderFK, HeaderId, DbType.Int64);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
                        insertedTaskDetails = con.Query<TaskDetailsVM>(ConstantDetails.TaskDetails_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

                        // if (insertedTask != null)
                        //     insertedTaskDetails.Add(insertedTask);

                        status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                        message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return insertedTaskDetails;
        }

       public bool TaskDetailsUpdate(List<TaskDetailsVM> taskDetailsList, out int status, out string message)
       {
            status = -1;
            message = null;
            bool isUpdated = false;

            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();

                    // string UserId = _httpContextAccessor.HttpContext.Request.Headers["X-UserId"];
                    // string HeaderId = _httpContextAccessor.HttpContext.Request.Headers["X-HeaderId"];
                    // string DetailsId = _httpContextAccessor.HttpContext.Request.Headers["X-DetailsId"];
                    // string UpdatedByName = _httpContextAccessor.HttpContext.Request.Headers["X-UpdatedByName"];
                    int UserId = 22;
                    int HeaderId = 222;
                    int DetailsId = 22222;
                    string UpdatedByName = "gokul";

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();

                        parameters.Add(ConstantDetails.TM_Details_ID, DetailsId, DbType.Int64);
                        parameters.Add(ConstantDetails.Project, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Type, taskDetailsVM.Type, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsVM.SOWIssueNo, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.IsBillable, taskDetailsVM.IsBillable, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.BillingType, taskDetailsVM.BillingType, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ResName, taskDetailsVM.ResName, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Team, taskDetailsVM.Team, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstStDt, taskDetailsVM.EstStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstEndDt, taskDetailsVM.EstEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstHours, taskDetailsVM.EstHours, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActStDt, taskDetailsVM.ActStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActEndDt, taskDetailsVM.ActEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.StTime, taskDetailsVM.StTime, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EndTime, taskDetailsVM.EndTime, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActHours, taskDetailsVM.ActHours, DbType.Time, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Percentage, taskDetailsVM.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Status, taskDetailsVM.Status, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.UpdatedBy, UpdatedByName, DbType.String);
                        parameters.Add(ConstantDetails.UsersFK, UserId, DbType.String);
                        parameters.Add(ConstantDetails.TaskHeaderFK, HeaderId, DbType.Int64);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
                        con.Query<TaskDetailsVM>(ConstantDetails.TaskDetails_Update_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

                        status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                        message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                        isUpdated = status == 2;
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                isUpdated = false;
            }

            return isUpdated;

        }

    }
}
