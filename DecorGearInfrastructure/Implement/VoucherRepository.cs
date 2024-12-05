using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.implement
{
    public class VoucherRepository : IVoucherRespository
    {
        private readonly AppDbContext _dbContext;
        public VoucherRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public Task<ErrorMessage> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteVoucher(DeleteVoucherRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VoucherDto>> GetAllVoucher(CancellationToken cancellationToken)
        {
            var voucher = await _dbContext.Vouchers.ToListAsync(cancellationToken);
            return voucher.Select(v => new VoucherDto
            {
                VoucherID = v.VoucherID,
                VoucherName = v.VoucherName,
                VoucherPercent = v.VoucherPercent,
                expiry = v.expiry.ToString("dd-MM-yyyy"),
            }).ToList();
        }

        public async Task<VoucherDto> GetKeyVoucherById(ViewVoucherRequest request, CancellationToken cancellationToken)
        {
            var voucher = await _dbContext.Vouchers.FirstOrDefaultAsync(v => v.VoucherID == request.VoucherID, cancellationToken);
            if (voucher == null)
            {
                return null;
            }
            else
            {
                return new VoucherDto
                {
                    VoucherID = voucher.VoucherID,
                    VoucherName = voucher.VoucherName,
                    VoucherPercent = voucher.VoucherPercent,
                    expiry = voucher.expiry.ToString("dd-MM-yyyy")
                };
            }
        }

        public async Task<ErrorMessage> UpdateVoucher(VoucherDto request, CancellationToken cancellationToken)
        {
            var udVoucher = await _dbContext.Vouchers.FirstOrDefaultAsync(v => v.VoucherID == request.VoucherID, cancellationToken);
            if (udVoucher == null)
            {
                return ErrorMessage.Failed;
            }
            else
            {
                udVoucher.VoucherName = request.VoucherName;
                udVoucher.VoucherPercent = request.VoucherPercent;
                udVoucher.expiry = DateTime.ParseExact(request.expiry, "dd-MM-yyyy", null);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
        }
    }
}
