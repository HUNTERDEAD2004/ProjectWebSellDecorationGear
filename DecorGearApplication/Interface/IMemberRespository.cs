using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IMemberRespository
    {
        Task<ErrorMessage> Register(Member member, CancellationToken cancellationToken);

        Task<List<Member>> GetAllMembers(CancellationToken cancellationToken);

        Task<Member> GetMembersByid(Guid id, CancellationToken cancellationToken);

        Task<ErrorMessage> UpdateMember(MemberDto memberdto, CancellationToken cancellationToken);

        Task<bool> DeleteMember(Guid id, CancellationToken cancellationToken);
    }
}
