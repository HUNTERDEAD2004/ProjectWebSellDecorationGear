using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IMouseRespository
    {
        Task<List<MouseDetailsDto>> GetAllKeyBoarMouse(CancellationToken cancellationToken);
        Task<MouseDetailsDto> GetMouseById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateMouse(MouseDetailsDto request, CancellationToken cancellationToken);
        Task<bool> DeleteMouse(int id, CancellationToken cancellationToken);
    }
}
