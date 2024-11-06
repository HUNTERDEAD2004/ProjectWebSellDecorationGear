using AutoMapper;
using AutoMapper.QueryableExtensions;
using DecorGearApplication.DataTransferObj.Home;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{

    public class HomeRepository
    {
        private readonly AppDbContext _Context;
        private readonly IMapper _mapper;
        public HomeRepository(AppDbContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }
        public async Task<List<TopViewedProductDto>> GetTopViewedProductsAsync(int limit, CancellationToken cancellationToken)
        {
            return await _Context.Products
                .OrderByDescending(p => p.View)
                .Take(limit)
                .ProjectTo<TopViewedProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
        public async Task<List<TopHotProductDto>> GetTopHotProductsAsync(int limit, CancellationToken cancellationToken)
        {
            return await _Context.Products
                .OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
                .Take(limit)
                .ProjectTo<TopHotProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
