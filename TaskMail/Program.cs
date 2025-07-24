using TaskMailcommon.Mappings;
using TaskMailService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITM_LoginService, TM_LoginService>();
builder.Services.AddScoped<ITM_TaskHeaderService, TM_TaskHeaderService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile),typeof(TM_TaskHeaderMapping));
// builder.Services.AddAutoMapper(typeof(TM_TaskHeaderMapping));



var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

// app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();
app.Run();
