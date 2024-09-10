using DecorGearApplication.DataTransferObj.Example;
using DecorGearApplication.ValueObj.Pagination;
using DecorGearDomain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IExampleServices   
    {
        Task<PaginationResponse<ExampleDTO>> GetAll(ViewExampleRequest request, CancellationToken cancellationToken);
        Task<bool> Create(Example request, CancellationToken cancellationToken);
    }
}
