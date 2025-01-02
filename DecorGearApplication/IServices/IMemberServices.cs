using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.User;
using DecorGearDomain.Enum;

namespace DecorGearApplication.IServices
{
    public interface IMemberServices
    {
        Task<List<MemberDto>> GetAllMembersAsync(CancellationToken cancellation);
        Task<MemberDto> GetMemberByIdAsync(int id, CancellationToken cancellation);
        Task<ResponseDto<ErrorMessage>> CreateMemberAsync(CreateMemberRequest request, CancellationToken cancellation);
        Task<ResponseDto<ErrorMessage>> UpdateMemberAsync(int id, UpdateMemberRequest request, CancellationToken cancellation);
        Task<ResponseDto<bool>> DeleteMemberAsync(int id, CancellationToken cancellation);
    }
}
