using ExpenseTracker.Dto;

namespace ExpenseTracker.Interface
{
    public interface ICategory
    {
        public void AddCategory(CategoryRequestDTO requestDTO);
    }
}
