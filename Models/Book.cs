using System;
using System.Collections.Generic;

namespace BackendBookMannu.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Img { get; set; }

    public string? Author { get; set; }

    public DateOnly PublishDate { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
