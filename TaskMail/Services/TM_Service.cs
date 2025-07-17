using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using Microsoft.VisualBasic;
using TaskMail.Services.common;



namespace TaskMail.Services.Services
{
    public class TaskMail_Service : ITaskMail_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public TaskMail_Service(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }
        public IDbConnection GetConnection
        {
            get { return new SqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        public TaskMail_Login_VM Login(TaskMail_Login_VM loginVm, in string Username, in string Password)
        {
            try
            {
                using (IDbConnection conn = GetConnection)
                {
                    conn.Open();
                    var param = new DynamicParameters();
                    param.Add(Constant.UserName, dbType: DbType.String, size: 200, direction: ParameterDirection.Input);
                    param.Add(Constant.Password, dbType: DbType.String, size: 200, direction: ParameterDirection.Input);
                    param.Add(Constant.errmsglogin, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var model = conn.Query<TaskMail_Login_DM>(Constant.Login_SP, param, commandType: CommandType.StoredProcedure);
                    Username = param.Get<Int16>(Constants.UserName);
                    Password = param.Get<string>(Constants.Password);
                    return errmsglogin;
                   
                }
                
            }
            catch
            {

            }
        }
    }


}