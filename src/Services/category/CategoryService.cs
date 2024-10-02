using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.src.Entity;
using ecommerce.src.Repository;
using ecommerce.src.Utils;
using static ecommerce.src.DTO.CategoryDTO;

namespace ecommerce.src.Services.category
{
    public class CategoryService : ICategoryService
    {
        protected readonly CategoryRepository _categoryRepo;
        protected readonly IMapper _mapper;

        // DI
        public CategoryService(CategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        public async Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto)
        {
            var category = _mapper.Map<CategoryCreateDto, Category>(createDto);

            var categoryCreated = await _categoryRepo.CreateOneAsync(category);

            return _mapper.Map<Category, CategoryReadDto>(categoryCreated);

        }

        // GetAllAsyncWithPagination
        public async Task<List<CategoryReadDto>> GetAllAsync(PaginationOptions paginationOptions)
        {
            var categoryList = await _categoryRepo.GetAllAsync(paginationOptions);
            return _mapper.Map<List<Category>, List<CategoryReadDto>>(categoryList);
        }


        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            // TO DO: handle error
            // throw
            if (foundCategory == null)
            {
                throw CustomException.NotFound($"category with {id} cant find");
            }
            return _mapper.Map<Category, CategoryReadDto>(foundCategory);

        }


        public async Task<bool> DeleteOneAsync(Guid id)
        {

            // find the category id id
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            bool isDeleted = await _categoryRepo.DeleteOneAsync(foundCategory);

            if (isDeleted)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);

            if (foundCategory == null)
            {
                return false;
            }

            // found category
            // updateDto
            // foundCategory
            // keep old one - update a part of it
            _mapper.Map(updateDto, foundCategory);
            return await _categoryRepo.UpdateOneAsync(foundCategory);

        }
    }
}