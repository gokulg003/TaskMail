using TaskMailcommon.Mappings;
using TaskMailService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskMail_Login_Service, TaskMail_Login_Service>();
builder.Services.AddScoped<ITaskMail_TaskHeader_Service, TaskMail_TaskHeader_Service>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(TaskMail_Template_Time_Mapping));



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
