using backend.Data;
using backend.Dto;
using backend.Entities;
using backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Endpoints;

public static class EmployeeEndpoint
{
    const string GetEmployeeEndpoint ="GetEmployee";
    private static readonly List<EmployeeSummary> employees=[
        new (
            1,
            "Shiban",
            23,
            "2000.shiban@gmail.com",
            4000,
            "Developer"

            ),
         new(
            2,
            "Shiban",
            23,
            "2000.shiban@gmail.com",
            4000,
            "Developer"

        )
    ];
public static WebApplication MapEmployeesEndpoint(this WebApplication app){

var group=app.MapGroup("employees").WithParameterValidation();

group.MapGet("/", ( EmployeeStoreContext dbContext) =>
dbContext.Employees
        .Include(game=>game.Job)
        .Select(game=>game.ToEmployeeSummaryDto())
        .AsNoTracking());

group.MapGet("/{id}", (int id,EmployeeStoreContext dbContext) =>{ 
     EmpJob? emp=dbContext.Employees.Find(id);
     return emp is null ? Results.NotFound():Results.Ok(emp.ToEmployeeDetailsDto());
}).WithName(GetEmployeeEndpoint);

group.MapPost("/", (CreateEmployee newEmplopyee, EmployeeStoreContext dbContext) =>{
        EmpJob emp= newEmplopyee.ToEntity();
    
     
       dbContext.Employees.Add(emp);
       dbContext.SaveChanges();
  
       return Results.CreatedAtRoute(GetEmployeeEndpoint,new{id=emp.Id},emp.ToEmployeeDetailsDto());
 
});

group.MapPut("/{id}",(int id,UpdateEmployee updateemployee,EmployeeStoreContext dbContext) =>{
    var existingEmployee =dbContext.Employees.Find(id);
    if(existingEmployee is null){
        return Results.NotFound();
    }
    dbContext.Entry(existingEmployee)
                    .CurrentValues
                    .SetValues(updateemployee.ToEntity(id));
    dbContext.SaveChanges();
  
    return Results.NoContent();
}); 

group.MapDelete("/{id}",(int id,EmployeeStoreContext dbContext)=>{
    dbContext.Employees.Where(game=>game.Id == id)
                        .ExecuteDelete();
    return Results.NoContent();
});


return app;
 }

}
