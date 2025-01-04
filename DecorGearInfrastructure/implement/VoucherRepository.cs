using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.DataTransferObj.Voucher;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
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
        public async Task<ResponseDto<Voucher>> CreateVoucher(CreateVoucherRequest request, CancellationToken cancellationToken)
        {
            var checkNameVoucher = await _dbContext.Vouchers.AnyAsync(x => x.VoucherName == request.VoucherName, cancellationToken);
            if (request == null)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Request is null"
                };
            }
            if (checkNameVoucher)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Voucher name already exists"
                };
            }
            if (request.expiry < DateTime.Now)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Expiry date must be greater than current date"
                };
            }
            if (request.expiry > DateTime.Now.AddMonths(3))
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Expiry date must be less than 3 months"
                };
            }
            return new ResponseDto<Voucher>
            {
                Data = new Voucher
                {
                    VoucherName = request.VoucherName,
                    VoucherPercent = (request.VoucherPercent / 100),
                    Status = request.Status,
                    expiry = request.expiry,
                    CreatedTime = DateTime.Now
                },
                Status = StatusCodes.Status200OK,
                Message = "Success"
            };
        }

        public async Task<ResponseDto<Voucher>> DeleteVoucher(DeleteVoucherRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Request is null"
                };
            }
            var delVoucher = await _dbContext.Vouchers.FirstOrDefaultAsync(v => v.VoucherID == request.VoucherID, cancellationToken);
            if (delVoucher == null)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Voucher not found"
                };
            }
            if (delVoucher.Status == EntityStatus.Active)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Voucher is being active"
                };
            }
            var checkVoucher = await _dbContext.Orders.AnyAsync(v => v.VoucherID == request.VoucherID);
            if (checkVoucher)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Voucher is being used"
                };
            }
            _dbContext.Vouchers.Remove(delVoucher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ResponseDto<Voucher>
            {
                Data = delVoucher,
                Status = StatusCodes.Status200OK,
                Message = "Success"
            };
        }

        public async Task<List<VoucherDto>> GetAllVoucher(VoucherSearch? voucherSearch, CancellationToken cancellationToken)
        {
            var voucher = _dbContext.Vouchers.Select(x => new VoucherDto
            {
                VoucherID = x.VoucherID,
                VoucherName = x.VoucherName,
                VoucherPercent = x.VoucherPercent,
                expiry = x.expiry,
                CreatedTime = x.CreatedTime,
                Status = x.Status
            }).AsQueryable();
            if (voucherSearch != null)
            {
                if (!string.IsNullOrEmpty(voucherSearch.VoucherName))
                {
                    voucher = voucher.Where(v => v.VoucherName.Contains(voucherSearch.VoucherName));
                }
                if (voucherSearch.Status.HasValue)
                {
                    voucher = voucher.Where(v => v.Status == voucherSearch.Status);
                }
                if (voucherSearch.VoucherPercent.HasValue)
                {
                    voucher = voucher.Where(v => v.VoucherPercent == voucherSearch.VoucherPercent);
                }
            }
            return await voucher.ToListAsync(cancellationToken);
        }

        public async Task<ResponseDto<VoucherDto>> GetKeyVoucherById(ViewVoucherRequest request, CancellationToken cancellationToken)
        {
            var voucher = await _dbContext.Vouchers.FirstOrDefaultAsync(v => v.VoucherID == request.VoucherID, cancellationToken);
            if (voucher == null)
            {
                return new ResponseDto<VoucherDto>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Voucher not found"
                };
            }
            else
            {
                return new ResponseDto<VoucherDto>
                {
                    Data = new VoucherDto
                    {
                        VoucherID = voucher.VoucherID,
                        VoucherName = voucher.VoucherName,
                        VoucherPercent = voucher.VoucherPercent,
                        Status = voucher.Status,
                        expiry = voucher.expiry,
                        CreatedTime = voucher.CreatedTime
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
        }

        public async Task<ResponseDto<Voucher>> UpdateVoucher(int Id, UpdateVoucherRequest request, CancellationToken cancellationToken)
        {
            var udVoucher = await _dbContext.Vouchers.FirstOrDefaultAsync(v => v.VoucherID == Id, cancellationToken);
            if (udVoucher == null)
            {
                return new ResponseDto<Voucher>
                {
                    Data = null,
                    Status = StatusCodes.Status404NotFound,
                    Message = "Voucher not found"
                };
            }
            else
            {
                if (request.expiry < udVoucher.CreatedTime)
                {
                    return new ResponseDto<Voucher>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Expiry date must be greater than created date"
                    };
                }
                if (request.expiry > DateTime.Now.AddMonths(3))
                {
                    return new ResponseDto<Voucher>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Expiry date must be less than 3 months"
                    };
                }
                var voucherNameCheck = await _dbContext.Vouchers.AnyAsync(x => x.VoucherName == request.VoucherName && x.VoucherID != Id);
                if (voucherNameCheck)
                {
                    return new ResponseDto<Voucher>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Voucher name already exists"
                    };

                }
                udVoucher.VoucherName = request.VoucherName;
                udVoucher.VoucherPercent = (request.VoucherPercent / 100);
                udVoucher.expiry = request.expiry;
                udVoucher.Status = request.Status;
                udVoucher.ModifiedTime = DateTimeOffset.Now;
                _dbContext.Vouchers.Update(udVoucher);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new ResponseDto<Voucher>
                {
                    Data = udVoucher,
                    Status = StatusCodes.Status200OK,
                    Message = "Success"
                };

            }
        }
    }
}