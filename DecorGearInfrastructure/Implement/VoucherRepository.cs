using AutoMapper;
using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearApplication.Interface;   
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class VoucherRepository : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;

        public VoucherRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _db = appDbContext;
            _map = mapper;
        }
        public async Task<ErrorMessage> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var createVoucher = _map.Map<Voucher>(request);

                await _db.Vouchers.AddAsync(createVoucher, cancellationToken);

                await _db.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteVoucher(int id, DeleteVoucherRequest request, CancellationToken cancellationToken)
        {
            var keyResult = await _db.Vouchers.FindAsync(id);
            if (keyResult != null)
            {
                _db.Vouchers.Remove(keyResult);
                _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<VoucherDto>> GetAllVoucher(CancellationToken cancellationToken)
        {
            var result = await _db.Vouchers.ToListAsync(cancellationToken);
            return _map.Map<List<VoucherDto>>(result);
        }

        public async Task<VoucherDto> GetKeyVoucherById(int id, ViewVoucherRequest request, CancellationToken cancellationToken)
        {
            var voucherId = request.VoucherID; 
            var voucher = await _db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return null;
            }
            return _map.Map<VoucherDto>(voucher);
        }

        public async Task<ErrorMessage> UpdateVoucher(int id, UpdateVoucherRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.VoucherID == 0)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var existingVoucher = await _db.Vouchers.FindAsync(id);
                existingVoucher.VoucherName = request.VoucherName;

                _map.Map(request, existingVoucher);

                _db.Vouchers.Update(existingVoucher);
                await _db.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}


