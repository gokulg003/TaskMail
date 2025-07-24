using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TM_TaskHeaderService : ITM_TaskHeaderService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public TM_TaskHeaderService(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(Constants.databaseName));
            }
        }

        public List<TM_TaskHeaderVM> TaskHeader(TM_TaskHeaderVM taskHeaderVM,TaskHeaderSupplements taskHeaderSupplements)
        {
            var taskHeader = new List<TM_TaskHeaderVM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    DateTime manualDate = new DateTime(2025, 07, 24, 14, 30, 0); // year, month, day, hour, minute, second
                    string timeOnly = manualDate.ToString("HH:mm:ss");

                    var parameters = new DynamicParameters();
                    parameters.Add(Constants.Resource, taskHeaderSupplements.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Type, taskHeaderSupplements.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Month, taskHeaderSupplements.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Date, taskHeaderSupplements.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Year, taskHeaderSupplements.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.In_Time, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Out_Time, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Total_Duration, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Break_Duration, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Act_Work_Hours, timeOnly, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Comments, taskHeaderSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.TM_InsertedBy, " ", DbType.String);  
                    parameters.Add(Constants.TM_InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(Constants.TM_UpdatedBy, " ", DbType.String);
                    parameters.Add(Constants.TM_UpdatedDate, DateTime.Now, DbType.DateTime);

                    parameters.Add(Constants.errmsgTemplateTime, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    taskHeader = con.Query<TM_TaskHeaderVM>(Constants.TaskHeader_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    string errmsg = parameters.Get<string>(Constants.errmsgTemplateTime);
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