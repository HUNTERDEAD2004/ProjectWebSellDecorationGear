using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.User;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.IServices
{
    public interface IMemberServices 
    {
        Task<List<MemberDto>> GetAllMembersAsync(CancellationToken cancellation);
        Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellation);
        Task<ResponseDto<ErrorMessage>> CreateMemberAsync(CreateMemberRequest request, CancellationToken cancellation);
        Task<ResponseDto<ErrorMessage>> UpdateMemberAsync(int id, UpdateMemberRequest request, CancellationToken cancellation);
        Task<ResponseDto<bool>> DeleteMemberAsync(DeleteMemberRequest request, CancellationToken cancellation);
    }
}
