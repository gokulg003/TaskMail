using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using Dapper;
using TaskMail.DataModels;
using TaskMail.Services.common;
using TaskMail.ViewModels;

namespace TaskMailService.Services
{
    public class TaskMailTemplateTime_Service : ITaskMailTemplateTime_Service
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public TaskMailTemplateTime_Service(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IDbConnection GetConnection
        {
            get { return new SqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        public List<TaskMail_TemplateTime_DM> Template_Time()
        {
            var templatetimedm = new List<TaskMail_TemplateTime_DM>();
            try
            {
                using (IDbConnection con = Connection)
                {
                    con.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18); 
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    parameters.Add(Constant.policyPkDbParam, policyId, DbType.Int64, ParameterDirection.Input, 18);
                    templatetimedm = con.Query<TaskMail_TemplateTime_DM>(Constant.TemplateTime_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
                    status = parameters.Get<Int16>(Constants.status);
                    message = parameters.Get<string>(Constants.errMsg);
                }
            }
            catch (Exception ex)
            {
                TraceLog.LogError(Convert.ToString(Header.UserPK), Header.UserID, "AdditionalAddressServices-GetAdditionalAddress", ex, "policyId:" + policyId.ToString());
                status = -1;
                message = ex.Message;
            }
        }


    }
}