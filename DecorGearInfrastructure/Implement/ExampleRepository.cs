using AutoMapper;
using DecorGearApplication.DataTransferObj.Example;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Pagination;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class ExampleRepository : IExampleServices
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExampleRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper; 
        }

        public async Task<bool> Create(Example request, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.Examples.AddAsync(request, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Xử lý ngoại lệ liên quan đến cập nhật DB
                return false;
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                return false;
            }
        }

        public async Task<PaginationResponse<ExampleDTO>> GetAll(ViewExampleRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Examples.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => x.Name == request.Name);
            }

            var result = await query.PaginateAsync<Example, ExampleDTO>(request, _mapper, cancellationToken);

            return result;
        }
    }
}
