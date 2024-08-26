namespace backend.Dto;

public record class Employee(
    int Id,
    string Name,
    int Age,
    string Email,
    int Salary,
    string Job
);
