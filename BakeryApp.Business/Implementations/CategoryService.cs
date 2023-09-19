using AutoMapper;
using BakeryApp.Business.Constants.Category;
using BakeryApp.Business.Interfaces;
using BakeryApp.Business.Validations.Category;
using BakeryApp.DataAccess.Interfaces;
using BakeryApp.Model.DTOs.Category.Get;
using BakeryApp.Model.DTOs.Category.Post;
using BakeryApp.Model.DTOs.Category.Put;
using BakeryApp.Model.Entities;
using Infrastructure.Aspects.Caching;
using Infrastructure.Aspects.IdParameter;
using Infrastructure.Aspects.Logging;
using Infrastructure.Aspects.Performance;
using Infrastructure.Aspects.Validation;
using Infrastructure.CrossCuttingConcerns.Exceptions;
using Infrastructure.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace BakeryApp.Business.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        private async Task CheckIfCategoryNameExists(string categoryName)
        {
            var categoryToCheck = await _categoryRepository.AnyAsync(p => p.Name.ToLower() == categoryName.ToLower());
            if (categoryToCheck)
            {
                throw new BusinessRuleException(CategoryErrorMessages.NameExists);
            }
        }

        [ValidationAspect(typeof(CategoryPostDtoValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]
        public async Task<CustomResponse<CategoryGetDto>> AddCategoryAsync(CategoryPostDto categoryPostDto)
        {
            await CheckIfCategoryNameExists(categoryPostDto.Name);
            var category = _mapper.Map<Category>(categoryPostDto);
            var inserted = await _categoryRepository.AddAsync(category);
            var insertedCategory = await _categoryRepository.GetByIdAsync(inserted.Id);
            var dto = _mapper.Map<CategoryGetDto>(insertedCategory);
            return CustomResponse<CategoryGetDto>.Success(StatusCodes.Status201Created, dto);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public Task<bool> AnyAsync(int id)
        {
            return _categoryRepository.AnyIdAsync(id, false);
        }

        [IdCheckAspect]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]
        public async Task<CustomResponse<NoData>> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
            return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        [CacheAddAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]
        public async Task<CustomResponse<List<CategoryGetDto>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetListAsync();
            if (categories != null && categories.Count > 0)
            {
                var dtoList = _mapper.Map<List<CategoryGetDto>>(categories);
                return CustomResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, dtoList);
            }
            throw new NotFoundException(CategoryErrorMessages.NotFoundCategories);
        }

        [IdCheckAspect]
        [PerformanceAspect(5)]
        public async Task<CustomResponse<CategoryGetDto>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id, false);
            var dto = _mapper.Map<CategoryGetDto>(category);
            return CustomResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        [ValidationAspect(typeof(CategoryPutDtoValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
        [LogAspect(typeof(FileLogger))]
        public async Task<CustomResponse<NoData>> UpdateCategoryAsync(CategoryPutDto categoryPutDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryPutDto.Id, false);
            if (category != null)
            {
                var updatedCategory = _mapper.Map<Category>(categoryPutDto);
                updatedCategory.CreatedDate = category.CreatedDate;
                await _categoryRepository.UpdateAsync(updatedCategory);
                return CustomResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(CategoryErrorMessages.NotFoundById);
        }
    }
}
