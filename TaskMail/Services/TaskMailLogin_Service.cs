using System.Data;
using Microsoft.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskMailLogin_Service : ITaskMailLogin_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public DefaultParameters Header { get; set; }

        public TaskMailLogin_Service(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(Constant.databaseName));
            }
        }

       public TaskMail_Login_VM Login(TaskMail_Login_VM loginVm, in string Usersname, in string Password)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var param = new DynamicParameters(Header);
                    var encodedPassword = Base64Helper.Encode(loginVm.Password.ToString());
                    param.Add(Constant.UsersName, Usersname, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.Password, encodedPassword, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.Email, dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    param.Add(Constant.errmsglogin, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var result = conn.Query<TaskMail_Login_DM>(Constant.Login_SP, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    string errmsg = param.Get<string>(Constant.errmsglogin);
                    string email = param.Get<string>(Constant.Email);
                    if (!string.IsNullOrEmpty(errmsg) && errmsg != "Success")
                    {
                        loginVm.Message = errmsg;
                        return loginVm;
                    }

                    if (result != null)
                    {
                        loginVm.UserName = result.UserName;
                        loginVm.Email = result.Email;
                        loginVm.Message = "Success";
                    }

                    return loginVm;
                }
            }
            catch (Exception ex)
            {
                loginVm.Message = "Login failed: " + ex.Message;
                return loginVm;
            }
        }
    }
}
