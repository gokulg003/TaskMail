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
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginService> _logger;


        public LoginService(IConfiguration config, IMapper mapper, ILogger<LoginService> logger)
        {
            _config = config;
            _mapper = mapper;
            _logger = logger; 
        }

       public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString(ConstantDetails.databaseName));
            }
        }

       public UserDetailsDM Login(Login login, out int status, out string message)
        {
            _logger.LogTrace("Login Validation Started");
            var userlogindetailsDM = new UserDetailsDM();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var param = new DynamicParameters();
                    string encodedPassword = Base64Helper.Encode(login.Passcode);

                    param.Add(ConstantDetails.dbparamUserName, login.UserName, DbType.String, ParameterDirection.Input, 250);
                    param.Add(ConstantDetails.dbparamPassword, encodedPassword, DbType.String, ParameterDirection.Input, 5000);

                    param.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    param.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    userlogindetailsDM = conn.Query<UserDetailsDM>(ConstantDetails.Login_SP, param, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    status = param.Get<Int16>(ConstantDetails.dbparamstatus);
                    message = param.Get<string>(ConstantDetails.dbparamerrmsg);
                    _logger.LogTrace("Login validation Successfull");
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                _logger.LogError(ex, "Error in Login");
            }
            return userlogindetailsDM;
        }
    }
}
