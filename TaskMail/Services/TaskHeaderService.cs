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
        // private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TaskDetailsService> _logger;

        public TaskHeaderService(IConfiguration config, IMapper mapper, ILogger<TaskDetailsService> logger)
        {
            _config = config;
            _mapper = mapper;
            _logger = logger;
            // _httpContextAccessor = httpContextAccessor; 
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }


        public List<TaskHeaderDM> GetTaskHeader(string userName, string fromDate, string toDate, out int status, out string message)
        {
            var result = new List<TaskHeaderDM>();

            try
            {
                using (IDbConnection con = Connection)
                {
                    _logger.LogTrace("Start Retrive TaskHeader");
                    con.Open();
                    var parameters = new DynamicParameters();

                    parameters.Add(ConstantDetails.Fromdate, fromDate, DbType.String, ParameterDirection.Input, 15);
                    parameters.Add(ConstantDetails.Todate, toDate, DbType.String, ParameterDirection.Input, 15);
                    parameters.Add(ConstantDetails.UserName, userName, DbType.String, ParameterDirection.Input, 250);

                    parameters.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output);
                    parameters.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    result = con.Query<TaskHeaderDM>(ConstantDetails.TaskHeader_RetrieveSP, parameters, commandType: CommandType.StoredProcedure).ToList();

                    status = parameters.Get<Int16>(ConstantDetails.status);
                    message = parameters.Get<string>(ConstantDetails.errMsg);
                    _logger.LogTrace("Successfully Retrive Task Header");
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                 _logger.LogError(ex, "Error while Retrive the Header");
            }
            return result;
        }
        public TaskHeaderDM InsertTaskHeader(TaskHeader taskHeaderVM, out int status, out string message)
        {
            var result = new TaskHeaderDM();
            try
            {
                using (IDbConnection con = Connection)
                {
                    _logger.LogTrace("Start Insert TaskHeader", taskHeaderVM.UserName);
                    con.Open();
                    var parameters = new DynamicParameters();

                    parameters.Add(ConstantDetails.Resource, taskHeaderVM.ResourceCode, DbType.String, ParameterDirection.Input, 250);
                    parameters.Add(ConstantDetails.Type, taskHeaderVM.TypeCode, DbType.String, ParameterDirection.Input, 15);
                    parameters.Add(ConstantDetails.Month, taskHeaderVM.Month, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Date, taskHeaderVM.Date, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Year, taskHeaderVM.Year, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InTime, taskHeaderVM.InTime, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.OutTime, taskHeaderVM.OutTime, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TotalDuration, taskHeaderVM.TotalDuration, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BreakDuration, taskHeaderVM.BreakDuration, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActWorkHours, taskHeaderVM.ActWorkHours, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Comments, taskHeaderVM.Comments, DbType.String, ParameterDirection.Input, 5000);

                    parameters.Add(ConstantDetails.InsertedBy, taskHeaderVM.UserName, DbType.String, ParameterDirection.Input, 250);
                    parameters.Add(ConstantDetails.UserFK, taskHeaderVM.UserId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.HeaderResourceFk, taskHeaderVM.HeaderResourceId, DbType.Int64, ParameterDirection.Input, 18);

                    parameters.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    result = con.Query<TaskHeaderDM>(ConstantDetails.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    status = parameters.Get<Int16>(ConstantDetails.status);
                    message = parameters.Get<string>(ConstantDetails.errMsg);
                    _logger.LogTrace("Successfully added Header", taskHeaderVM.UserName);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                _logger.LogError(ex, "An error occurred while inserting the header", taskHeaderVM);
            }
            return result;
        }

        public TaskHeaderDM UpdateTaskHeader(TaskHeader taskHeaderVM, out int status, out string message)
        {
           
            var result = new TaskHeaderDM();
            try
            {
                using (IDbConnection con = Connection)
                {
                    _logger.LogTrace("Start Update TaskHeader", taskHeaderVM.UserName);
                    con.Open();
                    var parameters = new DynamicParameters();

                    parameters.Add(ConstantDetails.Resource, taskHeaderVM.ResourceCode, DbType.String, ParameterDirection.Input, 250);
                    parameters.Add(ConstantDetails.Type, taskHeaderVM.TypeCode, DbType.String, ParameterDirection.Input, 15);
                    parameters.Add(ConstantDetails.Month, taskHeaderVM.Month, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Date, taskHeaderVM.Date, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Year, taskHeaderVM.Year, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InTime, taskHeaderVM.InTime, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.OutTime, taskHeaderVM.OutTime, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TotalDuration, taskHeaderVM.TotalDuration, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BreakDuration, taskHeaderVM.BreakDuration, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActWorkHours, taskHeaderVM.ActWorkHours, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Comments, taskHeaderVM.Comments, DbType.String, ParameterDirection.Input, 5000);

                    parameters.Add(ConstantDetails.UpdatedBy, taskHeaderVM.UserName, DbType.String, ParameterDirection.Input, 250);
                    parameters.Add(ConstantDetails.UserFK, taskHeaderVM.UserId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.HeaderId, taskHeaderVM.HeaderId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.HeaderResourceFk, taskHeaderVM.HeaderResourceId, DbType.Int64, ParameterDirection.Input, 18);

                    parameters.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    result = con.Query<TaskHeaderDM>(ConstantDetails.TaskHeaderUpdate_SP, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    status = parameters.Get<Int16>(ConstantDetails.status);
                    message = parameters.Get<string>(ConstantDetails.errMsg);
                    _logger.LogTrace("Successfully Updated Header", taskHeaderVM.UserName);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                _logger.LogError(ex, "An error occurred while Updating the header", taskHeaderVM);
            }
            return result;
        }
        
        public void DeleteTaskHeader(long taskHeader_PK, out int status, out string message)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    _logger.LogTrace("Start Delete TaskHeader");
                    var parameters = new DynamicParameters();
                    parameters.Add(ConstantDetails.HeaderId, taskHeader_PK, DbType.Int64);

                    parameters.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    con.Execute(ConstantDetails.TaskHeader_Delete_SP, parameters, commandType: CommandType.StoredProcedure);

                    status = parameters.Get<Int16>(ConstantDetails.status);
                    message = parameters.Get<string>(ConstantDetails.errMsg);
                    _logger.LogTrace("Successfully Delete Header");
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                _logger.LogError(ex, "An error occurred while Deleting the header");
            }
        }
    }

}
