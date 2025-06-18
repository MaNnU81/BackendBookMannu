namespace BackendBookMannu.Models.Dto
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Img { get; set; }

        public string? Author { get; set; }

        public DateOnly PublishDate { get; set; }

        public bool IsAvailable { get; set; }

        public virtual CategoryDTO Category { get; set; }
    }
}
