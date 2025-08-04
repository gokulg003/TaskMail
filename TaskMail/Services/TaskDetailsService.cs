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

        public List<TaskDetailsDM> TaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message)
        {
            var insertedTaskDetails = new List<TaskDetailsDM>();
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
                    // int HeaderId = 226;

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();


                        parameters.Add(ConstantDetails.Project, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.String, ParameterDirection.Input, 2000);
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
                        parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 4000);
                        parameters.Add(ConstantDetails.UserName, UserName, DbType.String, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.UsersFK, UserId, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskHeaderFK, taskDetailsVM.TaskHeader_FK, DbType.Int64, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
                        insertedTaskDetails = con.Query<TaskDetailsDM>(ConstantDetails.TaskDetails_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

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

        public List<TaskDetailsDM> TaskDetailsUpdate(List<TaskDetails> taskDetailsList, out int status, out string message)
        {
            var updatedTaskDetails = new List<TaskDetailsDM>();
            status = -1;
            message = null;

            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    // string UserId = _httpContextAccessor.HttpContext.Request.Headers["X-UserId"];
                    // string UpdatedByName = _httpContextAccessor.HttpContext.Request.Headers["X-UpdatedByName"];
                    // string HeaderId = _httpContextAccessor.HttpContext.Request.Headers["X-HeaderId"];

                    int UserId = 22;
                    // int HeaderId = 222;
                    string UpdatedByName = "gokul";

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();

                        parameters.Add(ConstantDetails.TMDetailsID, taskDetailsVM.TaskDetailPk, DbType.Int64);
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
                        parameters.Add(ConstantDetails.UsersFK, UserId, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskHeaderFK, taskDetailsVM.TaskHeader_FK, DbType.Int64, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
                        updatedTaskDetails = con.Query<TaskDetailsDM>(ConstantDetails.TaskDetails_Update_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

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

            return updatedTaskDetails;
        }

        // public bool DeleteTaskDetail(long taskDetailPK, long taskHeaderFK,out int status, out string message)
        // {
        //     status = -1;
        //     message = null;
        //     try
        //     {
        //         using (IDbConnection con = Connection)
        //         {
        //             con.Open();
        //             var parameters = new DynamicParameters();
        //             parameters.Add(ConstantDetails.TMDetailsID, taskDetailPK, DbType.Int64);
        //             parameters.Add(ConstantDetails.TaskHeaderFK, taskHeaderFK, DbType.Int64);
        //             parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
        //             parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
        //             con.Execute(ConstantDetails.TaskDetails_Delete_SP, parameters, commandType: CommandType.StoredProcedure);
        //             status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
        //             message = parameters.Get<string>(ConstantDetails.errmsgDetails);
        //             return status == 1;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         status = -1;
        //         message = ex.Message;
        //         return false;
        //     }
        // }


        public void DeleteTaskDetail(long taskDetailPk, long taskHeader_FK, out int status, out string message)
        {
            status = -1;
            message = "Unknown error";

            try
            {
                using (IDbConnection con = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(ConstantDetails.TMDetailsID, taskDetailPk, DbType.Int64);
                    parameters.Add(ConstantDetails.TaskHeaderFK, taskHeader_FK, DbType.Int64);
                    parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                    parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);
                    con.Execute(ConstantDetails.TaskDetails_Delete_SP, parameters, commandType: CommandType.StoredProcedure);
                    status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                    message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = "Exception: " + ex.Message;
            }
        }


    }
}
