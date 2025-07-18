using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;
using TaskMail.DataModels;

namespace TaskMailService.Services
{
    public class TaskMailLogin_Service : ITaskMailLogin_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public TaskMailLogin_Service(IConfiguration config, IMapper mapper)
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
                    var encodedUsername = Base64Helper.Encode(loginVm.UserName);
                    var encodedPassword = Base64Helper.Encode(loginVm.Password);
                    var param = new DynamicParameters();
                    param.Add(Constant.UserName, encodedUsername, DbType.String, ParameterDirection.Input, 200);
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
