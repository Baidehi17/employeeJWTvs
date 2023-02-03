using System;
using System.Collections.Generic;

namespace employeeJWTvs.Models;

public partial class EmployeedetailJwt
{
    public string? FristName { get; set; }

    public string? LastName { get; set; }

    public string? PreferredName { get; set; }

    public string Email { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string? Office { get; set; }

    public string? Department { get; set; }

    public string? PhoneNumber { get; set; }

    public int SkypeId { get; set; }

    public string? Password { get; set; }
}
