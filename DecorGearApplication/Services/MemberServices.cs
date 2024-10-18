using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Services
{
    public class MemberServices : IMemberServices
    {
        private readonly IMemberRespository _repo;

        public MemberServices(IMemberRespository repo)
        {
            _repo = repo;
        }
        public async Task<ResponseDto<ErrorMessage>> CreateMemberAsync(CreateMemberRequest request, CancellationToken cancellation)
        {
            return await _repo.CreateMemberAsync(request, cancellation);
        }

        public async Task<ResponseDto<bool>> DeleteMemberAsync(DeleteMemberRequest request, CancellationToken cancellation)
        {
            return  await _repo.DeleteMemberAsync(request, cancellation);
        }

        public async Task<List<MemberDto>> GetAllMembersAsync(CancellationToken cancellation)
        {
            return await _repo.GetAllMembersAsync(cancellation);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellation)
        {
            return await _repo.GetMemberByIdAsync(memberId, cancellation);
        }

        public async Task<ResponseDto<ErrorMessage>> UpdateMemberAsync(int id, UpdateMemberRequest request, CancellationToken cancellation)
        {
            return await _repo.UpdateMemberAsync(id, request,cancellation);
        }
    }
}
