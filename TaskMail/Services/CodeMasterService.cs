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
    public class CodeMasterService : ICodeMaster
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
public CodeMasterDM GetCodeMaster(out int status, out string message)
        {
            var userlogindetailsDM = new UserDetailsDM();
            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();
                    var param = new DynamicParameters();

                    param.Add("@CodeType",DbType.String, ParameterDirection.Input, 100);
                  
    }
}
