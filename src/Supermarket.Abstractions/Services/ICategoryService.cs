namespace Supermarket.Abstractions.Services
{
    using System;
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;

    public interface ICategoryService
    {
        Task<IEnumerable<ReadDto>> ListAsync();

        Task<ServiceResponse<ReadDto>> GetAsync(int id);

        Task<ServiceResponse<ReadDto>> SaveAsync(InsertDto insertDto);

        Task<ServiceResponse<ReadDto>> UpdateAsync(int id, UpdateDto updateDto);

        Task<ServiceResponse<int>> DeleteAsync(int id);
    }
}
