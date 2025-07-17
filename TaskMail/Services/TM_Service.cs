using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
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

        public TaskMail_Login_VM Login(TaskMail_Login_VM loginVm)
        {
            try
            {
                using (IDbConnection conn = GetConnection)
                {
                    conn.Open();

                    var param = new DynamicParameters();
                    param.Add(Constant.UserName, loginVm.Username, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.Password, loginVm.Password, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.errmsglogin, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var result = conn.Query<TaskMail_Login_DM>(Constant.Login_SP, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    string errmsg = param.Get<string>(Constant.errmsglogin);

                    if (!string.IsNullOrEmpty(errmsg))
                    {
                        throw new Exception(errmsg); 
                    }

                    var viewModel = _mapper.Map<TaskMail_Login_VM>(result);
                    return viewModel;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed: " + ex.Message);
            }
        }
    }
}
