using AutoMapper;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class SaleRepository : ISaleRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper map;
        public SaleRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            map = mapper;
        }

        public async Task<ResponseDto<ErrorMessage>> CreateSale(CreateSaleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest, "hãy điền đủ thông tin cần thiết");
            }
            try
            {
                var createSale = map.Map<Sale>(request);
                await _appDbContext.Sales.AddAsync(createSale, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<ErrorMessage>(StatusCodes.Status201Created, "Thêm thành công");
            }
            catch (Exception ex)
            {
                return new ResponseDto<ErrorMessage>(StatusCodes.Status500InternalServerError, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        public async Task<ResponseDto<bool>> DeleteSale(DeleteSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await _appDbContext.Sales.FindAsync(request.SaleID, cancellationToken);
            if (sale == null)
            {
                return new ResponseDto<bool>(StatusCodes.Status404NotFound, "sale không tồn tại");
            } 
            if (sale != null)
            {
                _appDbContext.Sales.Remove(sale);
                return new ResponseDto<bool>(StatusCodes.Status204NoContent, "Xóa thành công");
            }
            return new ResponseDto<bool>(StatusCodes.Status404NotFound, "Xóa thất bại");
        }
        
        public async Task<List<SaleDto>> GetAllSale(CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Sales.ToListAsync(cancellationToken);
            return map.Map<List<SaleDto>>(list);
        }

        public async Task<SaleDto> GetKeySaleById(int id, CancellationToken cancellationToken)
        {
            var idsale = await _appDbContext.Sales.FindAsync(id, cancellationToken);
            return idsale == null ? null : map.Map<SaleDto>(idsale);
        }

        public async Task<ResponseDto<ErrorMessage>> UpdateSale(int id, UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.SaleID == 0 )
            {
                return new ResponseDto<ErrorMessage>(StatusCodes.Status400BadRequest,"Sửa thất bại mất rồi");
            }
            try
            {
                var udsale = await _appDbContext.Sales.FindAsync(id, cancellationToken);
                udsale.SaleName = request.SaleName;
                udsale.SalePercent = request.SalePercent;
                _appDbContext.Sales.Update(udsale);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK,"Sửa thành công rồi :>");
            }
            catch (Exception ex)
            {
                return new ResponseDto<ErrorMessage>(StatusCodes.Status500InternalServerError, $"Lỗi ở đâu đó kìa {ex.Message}");
            }
        }
        public async Task<List<SaleDto>> Search(string salename, CancellationToken cancellationToken)
        {
            //var check = _appDbContext.Sales.AsQueryable();
            //if (!string.IsNullOrEmpty(salename)) // kiểm tra salename có null, "" hay không 
            //{
            //    check = check.Where(s => s.SaleName.Contains(salename));
            //}
            //else if(string.IsNullOrEmpty(salename))
            //{
            //    return await GetAllSale(cancellationToken);
            //}
            //var res = await check.ToListAsync(cancellationToken);
            //return map.Map<List<SaleDto>>(res);
            if (string.IsNullOrEmpty(salename))
            {
                return await GetAllSale(cancellationToken);
            }

            var check = _appDbContext.Sales.AsQueryable();
            check = check.Where(s => s.SaleName.Contains(salename));

            var res = await check.ToListAsync(cancellationToken);
            return map.Map<List<SaleDto>>(res);
        }
    }
}
