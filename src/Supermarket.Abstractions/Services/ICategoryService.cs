namespace Supermarket.Abstractions.Services
{
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;

    public interface ICategoryService
    {
        Task<ServiceResponse<PaginatedResult<SearchDto>>> GetCategoriesAsync(
            int limit = 10,
            int offset = 0,
            string name = "");

        Task<ServiceResponse<ReadDto>> GetCategoryAsync(int id, CancellationToken cancellationToken);

        Task<ServiceResponse<int>> AddCategoryAsync(InsertDto insertDto, CancellationToken cancellationToken);

        Task<ServiceResponse<ReadDto>> UpdateCategoryAsync(int id, UpdateDto updateDto, CancellationToken cancellationToken);

        Task<ServiceResponse<int>> DeleteCategoryAsync(int id, CancellationToken cancellationToken);
    }
}
