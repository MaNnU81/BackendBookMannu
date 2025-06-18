using System;
using System.Collections.Generic;

namespace BackendBookMannu.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Yob { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
