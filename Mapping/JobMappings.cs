using System;
using backend.Dto;
using backend.Entities;

namespace backend.Mapping;

public static class JobMappings
{
    public static JobDto ToDto(this JobType jobType){
        return new JobDto(jobType.Id, jobType.Name);
    }
}
