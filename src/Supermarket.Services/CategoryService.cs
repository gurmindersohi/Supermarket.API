namespace Supermarket.Services
{
    using System.Threading;
    using AutoMapper;
    using Supermarket.Abstractions.Repositories;
    using Supermarket.Abstractions.Services;
    using Supermarket.DataTransferModels.Categories;
    using Supermarket.DataTransferModels.Response;
    using Supermarket.Domain.Entities;
    using Constants;
    using System.Net;

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

        public async Task<ServiceResponse<PaginatedResult<SearchDto>>> GetCategoriesAsync(
            int limit = 10,
            int offset = 0,
            string name = "")
        {
            limit = Math.Min(limit, Constants.Constants.GetMaxLimit());

            var categories = await _categoryRepository.GetAsync(
                limit,
                offset,
                name).ConfigureAwait(false);

            var response = _mapper.Map<PaginatedResult<Category>, PaginatedResult<SearchDto>>(categories);
            return new ServiceResponse<PaginatedResult<SearchDto>>(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResponse<ReadDto>> GetCategoryAsync(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindByIdAsync(id).ConfigureAwait(false);
            if (category == null)
                return new ServiceResponse<ReadDto>("Category not found", HttpStatusCode.NotFound);

            var response = _mapper.Map<ReadDto>(category);
            return new ServiceResponse<ReadDto>(response, HttpStatusCode.OK);
        }

        public async Task<ServiceResponse<int>> AddCategoryAsync(InsertDto insertDto, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(insertDto);
                await _categoryRepository.AddAsync(category).ConfigureAwait(false);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return new CreatedResponse<int>(category.Id, $"api/category/{category.Id}");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public async Task<ServiceResponse<ReadDto>> UpdateCategoryAsync(int id, UpdateDto updateDto, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id).ConfigureAwait(false);

            if (existingCategory == null)
                return new ServiceResponse<ReadDto>("Category not found", HttpStatusCode.NotFound);

            var category = _mapper.Map(updateDto, existingCategory);

            try
            {
                _categoryRepository.Update(category);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);
                var response = _mapper.Map<Category, ReadDto>(category);
                return new ServiceResponse<ReadDto>(response, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ReadDto>($"An error occurred when updating the category {ex.Message}", HttpStatusCode.BadRequest);
            }
        }

        public async Task<ServiceResponse<int>> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id).ConfigureAwait(false);

            if (existingCategory == null)
                return new ServiceResponse<int>("Category not found", HttpStatusCode.NotFound);

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync().ConfigureAwait(false);

                return new ServiceResponse<int>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>($"An error occured when deleting the category: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
    }
}

