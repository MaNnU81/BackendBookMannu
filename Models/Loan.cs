using System;
using System.Collections.Generic;

namespace BackendBookMannu.Models;

public partial class Loan
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateOnly? LoanDate { get; set; }

    public DateOnly ReturnDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
