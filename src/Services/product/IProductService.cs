using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ecommerce.src.DTO.ProductDTO;

namespace ecommerce.src.Services.product
{
    public interface IProductService
    {
        Task<ProductReadDto> CreateOneAsync(ProductCreateDto createDto);
        Task<List<ProductReadDto>> GetAllAsync();

        Task<ProductReadDto> GetByIdAsync(Guid id);

    }
}