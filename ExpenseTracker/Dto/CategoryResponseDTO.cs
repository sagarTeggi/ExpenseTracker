namespace ExpenseTracker.Dto
{
    public class CategoryResponseDTO : CategoryRequestDTO
    {
        public string? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
