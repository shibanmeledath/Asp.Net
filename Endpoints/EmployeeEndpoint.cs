using backend.Data;
using backend.Dto;
using backend.Entities;
using backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Endpoints;

public static class EmployeeEndpoint
{
    const string GetEmployeeEndpoint ="GetEmployee";/* 
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
    ]; */
public static WebApplication MapEmployeesEndpoint(this WebApplication app){

var group=app.MapGroup("employees").WithParameterValidation();

group.MapGet("/", async ( EmployeeStoreContext dbContext) =>
await dbContext.Employees
        .Include(game=>game.Job)
        .Select(game=>game.ToEmployeeSummaryDto())
        .AsNoTracking()
        .ToListAsync());

group.MapGet("/{id}",async (int id,EmployeeStoreContext dbContext) =>{ 
     EmpJob? emp=await dbContext.Employees.FindAsync(id);
     return emp is null ? Results.NotFound():Results.Ok(emp.ToEmployeeDetailsDto());
}).WithName(GetEmployeeEndpoint);

group.MapPost("/",async (CreateEmployee newEmplopyee, EmployeeStoreContext dbContext) =>{
        EmpJob emp= newEmplopyee.ToEntity();
    
     
       dbContext.Employees.Add(emp);
       await dbContext.SaveChangesAsync();
  
       return Results.CreatedAtRoute(GetEmployeeEndpoint,new{id=emp.Id},emp.ToEmployeeDetailsDto());
 
});

group.MapPut("/{id}", async (int id,UpdateEmployee updateemployee,EmployeeStoreContext dbContext) =>{
    var existingEmployee = await dbContext.Employees.FindAsync(id);
    if(existingEmployee is null){
        return Results.NotFound();
    }
    dbContext.Entry(existingEmployee)
                    .CurrentValues
                    .SetValues(updateemployee.ToEntity(id));
   await dbContext.SaveChangesAsync();
  
    return Results.NoContent();
}); 

group.MapDelete("/{id}",async (int id,EmployeeStoreContext dbContext)=>{
   await dbContext.Employees.Where(game=>game.Id == id)
                        .ExecuteDeleteAsync();
    return Results.NoContent();
});


return app;
 }

}
