namespace Supermarket.Abstractions.Services
{
    using System;
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;

    public interface ICategoryService
    {
        Task<IEnumerable<ReadDto>> ListAsync();

        Task<ServiceResponse<InsertDto>> SaveAsync(InsertDto insertDto);

        Task<ServiceResponse<UpdateDto>> UpdateAsync(int id, UpdateDto updateDto);

        Task<ServiceResponse<int>> DeleteAsync(int id);
    }
}
