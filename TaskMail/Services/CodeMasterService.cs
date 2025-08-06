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
    public class CodeMasterService : ICodeMasterService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public CodeMasterService(IConfiguration config, IMapper mapper)
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

        public List<CodeMasterDM> GetCodeMaster(long userId,string codeType, out int status, out string message)

        {
             List<CodeMasterDM> result = new List<CodeMasterDM>();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var param = new DynamicParameters();

                    param.Add(ConstantDetails.CodeType, codeType, DbType.String, ParameterDirection.Input, 100);
                    param.Add(ConstantDetails.UserFK, userId, DbType.Int64, ParameterDirection.Input, 18);

                    param.Add(ConstantDetails.dbparamstatus, dbType: DbType.Int16, direction: ParameterDirection.Output, size: 1);
                    param.Add(ConstantDetails.dbparamerrmsg, dbType: DbType.String, direction: ParameterDirection.Output, size: 5000);

                    result = conn.Query<CodeMasterDM>(ConstantDetails.CodeMasterSP, param, commandType: CommandType.StoredProcedure).ToList();
                    
                    status = param.Get<Int16>(ConstantDetails.status);
                    message = param.Get<string>(ConstantDetails.errMsg);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return result;
        }
    }
}

