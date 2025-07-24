using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;
using System;
using System.Globalization;

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
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    TimeSpan inTime = TimeSpan.ParseExact(currentTime, @"HH\:mm\:ss", CultureInfo.InvariantCulture);
                    var parameters = new DynamicParameters();
                    parameters.Add(Constants.Resource, taskHeaderSupplements.Resource, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Type, taskHeaderSupplements.Type, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Month, taskHeaderSupplements.Month, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Date, taskHeaderSupplements.Date, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Year, taskHeaderSupplements.Year, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constants.In_Time, inTime, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Out_Time, taskHeaderSupplements.Out_Time, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Total_Duration, taskHeaderSupplements.Total_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Break_Duration, taskHeaderSupplements.Break_Duration, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Act_Work_Hours, taskHeaderSupplements.Act_Work_Hours, DbType.Time, ParameterDirection.Input, 18);
                    parameters.Add(Constants.Comments, taskHeaderSupplements.Comments, DbType.String, ParameterDirection.Input, 18);
                    parameters.Add(Constants.TM_InsertedBy, "Admin", DbType.String);  // Use correct spelling!
                    parameters.Add(Constants.TM_InsertDate, DateTime.Now, DbType.DateTime);
                    parameters.Add(Constants.TM_UpdatedBy, "Admin", DbType.String);
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