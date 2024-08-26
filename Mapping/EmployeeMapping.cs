using System;
using backend.Dto;
using backend.Entities;
namespace backend.Mapping;

public static class EmployeeMapping
{
  public static EmpJob ToEntity(this CreateEmployee emp) {
     return new EmpJob(){
        Name=emp.Name,
        Age=emp.Age,
        Email=emp.Email,
        Salary=emp.Salary,
        JobId=emp.JobId
       } ;
  }

  
  public static EmpJob ToEntity(this UpdateEmployee emp,int id) {
     return new EmpJob(){
        Id = id,
        Name=emp.Name,
        Age=emp.Age,
        Email=emp.Email,
        Salary=emp.Salary,
        JobId=emp.JobId
       } ;
  }
    public static EmployeeSummary ToEmployeeSummaryDto(this EmpJob emp){
      return new (
        emp.Id,
        emp.Name,
        emp.Age,
        emp.Email,
        emp.Salary,
        emp.Job!.Name
       );
  }
   public static EmployeeDetails ToEmployeeDetailsDto(this EmpJob emp){
      return new (
        emp.Id,
        emp.Name,
        emp.Age,
        emp.Email,
        emp.Salary,
        emp.JobId
       );
  }

}
