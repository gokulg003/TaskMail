using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TM_LoginService : ITM_LoginService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        // public DefaultParameters Header { get; set; }

        public TM_LoginService(IConfiguration config, IMapper mapper)
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

       public TM_LoginVM Login(TM_LoginVM loginVM)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var param = new DynamicParameters();
                    string encodedPassword = Base64Helper.Encode(loginVM.Passcode);
                    param.Add(Constants.UsersName, loginVM.UsersName, DbType.String, ParameterDirection.Input, 250);
                    param.Add(Constants.Password, encodedPassword, DbType.String, ParameterDirection.Input, 500);
                   
                    param.Add(Constants.Email, dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
                    param.Add(Constants.errmsglogin, dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var result = conn.Query<TM_LoginDM>(Constants.Login_SP, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    string errmsg = param.Get<string>(Constants.errmsglogin);
                    string email = param.Get<string>(Constants.Email);
                    if (!string.IsNullOrEmpty(errmsg) && errmsg != "Success")
                    {
                        loginVM.Message = errmsg;
                        return loginVM;
                    }

                    if (result != null)
                    {
                        loginVM.UsersName = result.UsersName;
                        loginVM.Email = result.Email;
                        loginVM.Message = errmsg;
                        return loginVM;
                    }

                    return loginVM;
                }
            }
            catch (Exception ex)
            {
                loginVM.Message = "Login failed: " + ex.Message;
                return loginVM;
            }
        }
    }
}
