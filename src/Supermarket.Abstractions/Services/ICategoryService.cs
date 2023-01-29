namespace Supermarket.Abstractions.Services
{
    using System;
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;

    public interface ICategoryService
    {
        Task<ServiceResponse<IEnumerable<ReadDto>>> ListAsync();

        Task<ServiceResponse<ReadDto>> GetAsync(int id, CancellationToken cancellationToken);

        Task<ServiceResponse<int>> SaveAsync(InsertDto insertDto, CancellationToken cancellationToken);

        Task<ServiceResponse<ReadDto>> UpdateAsync(int id, UpdateDto updateDto, CancellationToken cancellationToken);

        Task<ServiceResponse<int>> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
