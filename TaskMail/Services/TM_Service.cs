using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;

namespace TASKMAIL.Services.Services
{
    public class TM_Service : ITM_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public TM_Service(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }
        public IDbConnection GetConnection
        {
            get { return new SqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        public LoginVM Login(LoginVM loginVm)
        {
            try
            {
                using (IDbConnection conn = GetConnection)
                {
                    conn.Open();
                    var param = new DynamicParameters();
                    param.Add("@UserName", loginVm.UserName);
                    param.Add("@Password", loginVm.Password);
                    param.Add("@ErrorMsg", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                    var model = conn.QueryFirst<TM_Login_DM>(
                        "Task_Mail_Login_SP",
                        param,
                        commandType: CommandType.StoredProcedure
                    );
                    var result = param.Get<string>("@ErrorMsg");
                    return new LoginVM { Message = result };
                }
                
            }
            catch
            {

            }
        }
    }


}