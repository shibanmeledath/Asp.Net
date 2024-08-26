using System.ComponentModel.DataAnnotations;

namespace backend.Dto;

public record class CreateEmployee
(
    [Required][StringLength(50)]string Name,
     [Required][Range(18,56)]int Age,
     [Required]string Email,
     [Required]int Salary,
     int JobId
);
