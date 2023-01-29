namespace Supermarket.Services
{
    using AutoMapper;
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Abstractions.Services;
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;
    using Supermarket.Domain.Entities;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadDto>> ListAsync()
        {
            var categories = await _categoryRepository.ListAsync();
            var response = _mapper.Map<IEnumerable<Category>, IEnumerable<ReadDto>>(categories);
            return response;
        }

        public async Task<ServiceResponse<ReadDto>> SaveAsync(InsertDto insertDto)
        {
            try
            {
                var category = _mapper.Map<Category>(insertDto);
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                var response = _mapper.Map<Category, ReadDto>(category);
                return new ServiceResponse<ReadDto>(response);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ReadDto>($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<ReadDto>> UpdateAsync(int id, UpdateDto updateDto)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ServiceResponse<ReadDto>("Category not found");

            var category = _mapper.Map(updateDto, existingCategory);

            try
            {
                _categoryRepository.Update(category);
                await _unitOfWork.CompleteAsync();
                var response = _mapper.Map<Category, ReadDto>(category);
                return new ServiceResponse<ReadDto>(response);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ReadDto>($"An error occurred when updating the category {ex.Message}");
            }
        }

        public async Task<ServiceResponse<int>> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ServiceResponse<int>("Category not found");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ServiceResponse<int>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>($"An error occured when deleting the category: {ex.Message}");
            }
        }

    }
}

