using AutoMapper;
using Azure.Core;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Extention;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class MemberRepository : IMemberService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public MemberRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> DeleteMember(int id, CancellationToken cancellationToken)
        {
            var member = await _dbContext.Members.FindAsync( id  , cancellationToken);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Member>> GetAllMembers(CancellationToken cancellationToken)
        {
            var members = await _dbContext.Members.ToListAsync(cancellationToken);

            return _mapper.Map<List<Member>>(members);

        }

        public async Task<Member> GetMembersByid(int id, CancellationToken cancellationToken)
        {
            var memberbyid = await _dbContext.Members.FindAsync(id, cancellationToken);
            return _mapper.Map< Member >(memberbyid);
        }
     
      
        public async Task<ErrorMessage> UpdateMember(MemberDto memberdto, CancellationToken cancellationToken)
        {
            // Tìm kiếm thành viên theo ID
            var member = await _dbContext.Members.FindAsync(new object[] { memberdto.MemberID }, cancellationToken);

            // Kiểm tra nếu không tìm thấy thành viên
            if (member == null)
            {
                return ErrorMessage.Faild;
            }

            // Sử dụng AutoMapper để ánh xạ các thay đổi từ DTO sang thực thể Member
            _mapper.Map(memberdto, member);

            // Cập nhật thành viên vào cơ sở dữ liệu
            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ErrorMessage.Successfull;
        }
        public bool EmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }
        public bool UserExists(string username)
        {
            return _dbContext.Users.Any(x => x.UserName == username);
        }

      

        public Task<ErrorMessage> Register(Member member, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
