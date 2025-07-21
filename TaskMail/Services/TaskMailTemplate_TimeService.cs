// using System.Data;
// using System.Data.SqlClient;
// using AutoMapper;
// using Dapper;
// using TaskMail.DataModels;
// using TaskMail.Services.common;
// using TaskMail.ViewModels;

// namespace TaskMailService.Services
// {
//     public class TaskMailTemplateTime_Service : ITaskMailTemplateTime_Service
//     {
//         private readonly IConfiguration _config;
//         private readonly IMapper _mapper;

//         public TaskMailTemplateTime_Service(IConfiguration config, IMapper mapper)
//         {
//             _config = config;
//             _mapper = mapper;
//         }

//         public IDbConnection Connection
//         {
//             get
//             {
//                 return new SqlConnection(_config.GetConnectionString(Constant.databaseName));
//             }
//         }

//         public List<TaskMail_Template_Time_DM> Template_Time()
//         {
//             var templatetimedm = new List<TaskMail_Template_Time_DM>();
//             try
//             {
//                 using (IDbConnection con = Connection)
//                 {
//                     con.Open();
//                     var parameters = new DynamicParameters();
//                     parameters.Add(Constant.Resource,TM_Template_Time_PK , DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Type, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Month, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Date, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Year, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.In_Time, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Out_Time, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Total_Duration, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Break_Duration, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     parameters.Add(Constant.Act_Work_Hours, policyId, DbType.Int64, ParameterDirection.Input, 18); 
//                     parameters.Add(Constant.Comments, policyId, DbType.Int64, ParameterDirection.Input, 18);
//                     templatetimedm = con.Query<TaskMail_Template_Time_DM>(Constant.TemplateTime_SP, parameters, commandType: CommandType.StoredProcedure).ToList();
//                 }
//             }
//             catch (Exception ex)
//             {
//                 loginVm.Message = "Login failed: " + ex.Message;
//                 return loginVm; 
//             }
//         }


//     }
// }