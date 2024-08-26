namespace backend.Dto;

public record class EmployeeSummary(
    int Id,
    string Name,
    int Age,
    string Email,
    int Salary,
    string Job
);
