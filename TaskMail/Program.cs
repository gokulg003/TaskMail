using TaskMailService.Services;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITaskHeaderService, TaskHeaderService>();
builder.Services.AddScoped<ICodeMasterService, CodeMasterService>();
builder.Services.AddScoped<ITaskDetailsService, TaskDetailsService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.Run();


