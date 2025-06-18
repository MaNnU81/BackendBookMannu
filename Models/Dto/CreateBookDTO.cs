namespace BackendBookMannu.Models.Dto
{
    public class CreateBookDTO
    {
        public string Title { get; set; }

        public string? Img { get; set; }

        public string? Author { get; set; }

        public DateOnly PublishDate { get; set; }

        public int CategoryId { get; set; }
    }
}
