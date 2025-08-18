using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        // private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskDetailsService(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            // _httpContextAccessor = httpContextAccessor; ;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }

        public List<TaskDetailsDM> InsertTaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message)
        {
            var insertedTaskDetails = new List<TaskDetailsDM>();
            status = -1;
            message = null;
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();


                        parameters.Add(ConstantDetails.Project, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.String, ParameterDirection.Input, 200);
                        parameters.Add(ConstantDetails.Type, taskDetailsVM.Type, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsVM.SOWIssueNo, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.IsBillable, taskDetailsVM.IsBillable, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.BillingType, taskDetailsVM.BillingType, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ResName, taskDetailsVM.ResName, DbType.String, ParameterDirection.Input, 50);
                        parameters.Add(ConstantDetails.Team, taskDetailsVM.Team, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstStDt, taskDetailsVM.EstStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstEndDt, taskDetailsVM.EstEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstHours, taskDetailsVM.EstHours, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActStDt, taskDetailsVM.ActStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActEndDt, taskDetailsVM.ActEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.StTime, taskDetailsVM.StTime, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EndTime, taskDetailsVM.EndTime, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActHours, taskDetailsVM.ActHours, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Percentage, taskDetailsVM.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Status, taskDetailsVM.Status, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 4000);
                        parameters.Add(ConstantDetails.UserName, taskDetailsVM.UserName, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.DetailsResourceId, taskDetailsVM.DetailsResourceId, DbType.String, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.UsersFK, taskDetailsVM.UserId, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskHeaderFK, taskDetailsVM.HeaderId, DbType.Int64, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);
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

        public List<TaskDetailsDM> UpdateTaskDetails(List<TaskDetails> taskDetailsList, out int status, out string message)
        {
            var updatedTaskDetails = new List<TaskDetailsDM>();
            status = -1;
            message = null;

            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();

                    foreach (var taskDetailsVM in taskDetailsList)
                    {
                        var parameters = new DynamicParameters();

                        parameters.Add(ConstantDetails.TMDetailsID, taskDetailsVM.DetailsId, DbType.Int64);
                        parameters.Add(ConstantDetails.Project, taskDetailsVM.Project, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Sprint, taskDetailsVM.Sprint, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskName, taskDetailsVM.TaskName, DbType.String, ParameterDirection.Input, 200);
                        parameters.Add(ConstantDetails.Type, taskDetailsVM.Type, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.SOWIssueNo, taskDetailsVM.SOWIssueNo, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.IsBillable, taskDetailsVM.IsBillable, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.BillingType, taskDetailsVM.BillingType, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ResName, taskDetailsVM.ResName, DbType.String, ParameterDirection.Input, 50);
                        parameters.Add(ConstantDetails.Team, taskDetailsVM.Team, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstStDt, taskDetailsVM.EstStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstEndDt, taskDetailsVM.EstEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EstHours, taskDetailsVM.EstHours, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActStDt, taskDetailsVM.ActStDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActEndDt, taskDetailsVM.ActEndDt, DbType.Date, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.StTime, taskDetailsVM.StTime, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.EndTime, taskDetailsVM.EndTime, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.ActHours, taskDetailsVM.ActHours, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Percentage, taskDetailsVM.Percentage, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.Status, taskDetailsVM.Status, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.CommentsDetails, taskDetailsVM.Comments, DbType.String, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.UpdatedBy, taskDetailsVM.UserName, DbType.String);
                        parameters.Add(ConstantDetails.UsersFK, taskDetailsVM.UserId, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.TaskHeaderFK, taskDetailsVM.HeaderId, DbType.Int64, ParameterDirection.Input, 18);
                        parameters.Add(ConstantDetails.DetailsResourceId, taskDetailsVM.DetailsResourceId, DbType.String, ParameterDirection.Input, 18);

                        parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                        parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

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


        public void DeleteTaskDetails(long taskDetailPk, long taskHeader_FK, out int status, out string message)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(ConstantDetails.TMDetailsID, taskDetailPk, DbType.Int64);
                    parameters.Add(ConstantDetails.TaskHeaderFK, taskHeader_FK, DbType.Int64);

                    parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

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

        public List<TaskDetailsDM> GetTaskDetails(long taskHeader_FK, out int status, out string message)
        {
            var GetTaskDetails = new List<TaskDetailsDM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add(ConstantDetails.TaskHeaderFK, taskHeader_FK, DbType.Int64, ParameterDirection.Input, 18);

                    parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output);
                    parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, size: 4000, direction: ParameterDirection.Output);

                    GetTaskDetails = con.Query<TaskDetailsDM>(ConstantDetails.TaskDetails_Retrive_SP, parameters, commandType: CommandType.StoredProcedure).ToList();

                    status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                    message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = "Exception: " + ex.Message;
            }
            return GetTaskDetails;
        }
        

    }
}
