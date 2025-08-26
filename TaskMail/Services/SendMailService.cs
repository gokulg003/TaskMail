using AutoMapper;
using Dapper;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using TaskMail.DataModels;
using TaskMail.ViewModels;
using TaskMail.common;

namespace TaskMailService.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public SendMailService(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }

        public void TaskMail(long taskHeaderPk,long UserFk, out int status, out string message, out long mailCount)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(ConstantDetails.TaskHeaderFK, taskHeaderPk, DbType.Int64);
                    parameters.Add(ConstantDetails.UserFK, UserFk, DbType.Int64, ParameterDirection.Input, 18);

                    parameters.Add(ConstantDetails.StatusDetails, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    parameters.Add(ConstantDetails.errmsgDetails, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);
                    parameters.Add(ConstantDetails.MailCount, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);

                    con.Execute(ConstantDetails.TaskMailSend_SP, parameters, commandType: CommandType.StoredProcedure);

                    status = parameters.Get<Int16>(ConstantDetails.StatusDetails);
                    message = parameters.Get<string>(ConstantDetails.errmsgDetails);
                    mailCount = parameters.Get<Int16>(ConstantDetails.MailCount);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = "Exception: " + ex.Message;
                mailCount = 0;
            }
        }

    }
}

