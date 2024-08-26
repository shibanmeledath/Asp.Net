using System.Data.Common;
using backend.Data;
using backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var ConnString =builder.Configuration.GetConnectionString("EmployeeStore");
builder.Services.AddSqlite<EmployeeStoreContext>(ConnString);

var app = builder.Build();

app.MapEmployeesEndpoint();
app.MigrateDb();
app.Run();
