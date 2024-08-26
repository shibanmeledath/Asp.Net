namespace backend.Dto;

public record class EmployeeDetails(
    int Id,
    string Name,
    int Age,
    string Email,
    int Salary,
    int JobId
);
