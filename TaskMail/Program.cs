using TaskMailService.Services;
 
 
var builder = WebApplication.CreateBuilder(args);
 
var configuration = builder.Configuration;
 
builder.Services.AddHttpContextAccessor();
 
builder.Services.AddSingleton<IConfiguration>(configuration);
 
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITaskHeaderService, TaskHeaderService>();
builder.Services.AddScoped<ICodeMasterService, CodeMasterService>();
builder.Services.AddScoped<ITaskDetailsService, TaskDetailsService>();
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
 
 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
 
var app = builder.Build();
 
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
 
// CORS
app.UseCors(MyAllowSpecificOrigins);
 
// Handle OPTIONS requests for CORS
app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 204;
        return;
    }
    await next();
});
app.UseAuthorization();
 
app.MapControllers();
 
app.Run();