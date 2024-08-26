using System;
using backend.Data;
using backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Endpoints;

public static class JobsEndpoints
{
    public static RouteGroupBuilder MapJobsEndpoints(this WebApplication app){
        var group=app.MapGroup("jobs");
        group.MapGet("/",async (EmployeeStoreContext dbContext)=>
        await dbContext.Jobs
                        .Select(job=>job.ToDto())
                        .AsNoTracking()
                        .ToListAsync()
        );
        return group;
    }
}
