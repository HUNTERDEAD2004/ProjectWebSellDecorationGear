using AutoMapper;
using DecorGearApplication.DataTransferObj.Member;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pipelines.Sockets.Unofficial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class MemberRepository : IMemberRespository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public MemberRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ResponseDto<ErrorMessage>> CreateMemberAsync(CreateMemberRequest request, CancellationToken cancellation)
        {
            var createmember = _mapper.Map<Member>(request);
            await _db.Members.AddAsync(createmember);         

            await _db.SaveChangesAsync(cancellation);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status201Created,"Tạo member thành công");
        }

        public async Task<ResponseDto<bool>> DeleteMemberAsync(DeleteMemberRequest request, CancellationToken cancellation)
        {
            var member = await _db.Members.FindAsync(request.MemberID, cancellation);
            if (member == null)
                return new ResponseDto<bool>(StatusCodes.Status404NotFound, "Member không tồn tại.");
            
            _db.Members.Remove(member);
            await _db.SaveChangesAsync(cancellation);

            return new ResponseDto<bool>(StatusCodes.Status200OK, "Xóa Member Thành Công");
        }

        public async Task<List<MemberDto>> GetAllMembersAsync(CancellationToken cancellation)
        {
            return await _db.Members
                .Include(m => m.User) 
                .Select(m => new MemberDto
                {
                    MemberID = m.MemberID,
                    UserID = m.UserID,
                    Points = m.Points,
                    ExpiryDate = m.ExpiryDate,                
                })
                .ToListAsync(cancellation);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellation)
        {
            var member = await _db.Members
               .Include(m => m.User) 
               .FirstOrDefaultAsync(m => m.MemberID == memberId, cancellation);

            if (member == null)
                return null;

            return new MemberDto
            {
                MemberID = member.MemberID,
                UserID = member.UserID,
                Points = member.Points,
                ExpiryDate = member.ExpiryDate,
            };
        }

        public async Task<ResponseDto<ErrorMessage>> UpdateMemberAsync(int id, UpdateMemberRequest request, CancellationToken cancellation)
        {
            var existingMember = await _db.Members.FirstOrDefaultAsync(m => m.MemberID == id, cancellation);

            if (existingMember == null)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status404NotFound, "Member không tồn tại");

            existingMember.Points = request.Points;
            existingMember.ExpiryDate = request.ExpiryDate;

            if (request.UserID.HasValue)
            {
                existingMember.UserID = request.UserID.Value;
            }

            _db.Members.Update(existingMember);
            await _db.SaveChangesAsync(cancellation);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK, "Cập nhật thành công");
        }

    }
}
