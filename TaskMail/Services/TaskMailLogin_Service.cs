using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.Services.common;
using TaskMail.ViewModels;
using TaskMail.DataModels;
using System;
using System.Text;

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
        
        public string Base64Encode(string plainText)
        {
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainBytes);
        }

       public TaskMail_Login_VM Login(TaskMail_Login_VM loginVm, in string Username, in string Password)
        {
            try
            {
                using (IDbConnection conn = GetConnection)
                {
                    conn.Open();
                    string encodedUsername = Base64Encode(loginVm.UserName);
                    string encodedPassword = Base64Encode(loginVm.Password);
                    var param = new DynamicParameters();
                    param.Add(Constant.UserName, encodedUsername, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.Password, encodedPassword, DbType.String, ParameterDirection.Input, 200);
                    param.Add(Constant.errmsglogin, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var result = conn.Query<TaskMail_Login_DM>(Constant.Login_SP, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    string errmsg = param.Get<string>(Constant.errmsglogin);
                    if (!string.IsNullOrEmpty(errmsg))
                    {
                        loginVm.Message = errmsg;
                        return loginVm;
                    }
                    var viewModel = _mapper.Map<TaskMail_Login_VM>(result);
                    return viewModel;
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
