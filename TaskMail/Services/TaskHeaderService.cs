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

        public TaskHeaderService(IConfiguration config, IMapper mapper, IHttpContextAccessor httpContextAccessor)
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

        public TaskHeaderVM TaskHeader(TaskHeaderVM taskHeaderVM, out int status, out string message)
        {
            var result = new TaskHeaderVM();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    string UserId = _httpContextAccessor.HttpContext.Request.Headers["X-UserId"];
                    string UserName = _httpContextAccessor.HttpContext.Request.Headers["X-UserName"];

                    // string UserName = "Gokul";
                    // int UserId = 2;

                    parameters.Add(ConstantDetails.Resource, taskHeaderVM.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Type, taskHeaderVM.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Month, taskHeaderVM.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Date, taskHeaderVM.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Year, taskHeaderVM.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.InTime, taskHeaderVM.InTime, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.OutTime, taskHeaderVM.OutTime, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TotalDuration, taskHeaderVM.TotalDuration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.BreakDuration, taskHeaderVM.BreakDuration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.ActWorkHours,taskHeaderVM.ActWorkHours, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.Comments, taskHeaderVM.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(ConstantDetails.TM_InsertedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.TM_InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_UpdatedBy, UserName, DbType.String);
                    parameters.Add(ConstantDetails.TM_UpdatedDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(ConstantDetails.TM_User_FK, UserId, DbType.Int64);

                    parameters.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    result = con.Query<TaskHeaderVM>(ConstantDetails.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    status = parameters.Get<Int16>(ConstantDetails.status);
                    message = parameters.Get<string>(ConstantDetails.errMsg);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return result;
        }
    }
}