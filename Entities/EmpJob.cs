using System;

namespace backend.Entities;

public class EmpJob
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Email { get; set; }
    public required int  Salary { get; set; }
    public int JobId { get; set; }
    public JobType? Job{ get; set; }

}
