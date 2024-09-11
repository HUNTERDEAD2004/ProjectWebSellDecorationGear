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
    internal interface IMemberRespository
    {
        Task<ErrorMessage> Register(Member member, CancellationToken cancellationToken);

        Task<List<Member>> GetAllMembers(CancellationToken cancellationToken);

        Task<Member> GetMembersByid(int id, CancellationToken cancellationToken);

        Task<ErrorMessage> UpdateMember(MemberDto memberdto, CancellationToken cancellationToken);

        Task<bool> DeleteMember(int id, CancellationToken cancellationToken);
    }
}
