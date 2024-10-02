using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class MouseRespository : IMouseRespository
    {
        public Task<ErrorMessage> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMouse(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<MouseDetailsDto>> GetAllKeyBoarMouse(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MouseDetailsDto> GetMouseById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateMouse(MouseDetailsDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
