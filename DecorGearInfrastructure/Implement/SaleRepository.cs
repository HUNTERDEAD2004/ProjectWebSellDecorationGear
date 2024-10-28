﻿using AutoMapper;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
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

        public async Task<ErrorMessage> CreateSale(CreateSaleRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var createSale = map.Map<Sale>(request);
                await _appDbContext.Sales.AddAsync(createSale, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteSale(int id, CancellationToken cancellationToken)
        {
            var sale = await _appDbContext.Sales.FindAsync(id, cancellationToken);
            if (sale != null)
            {
                _appDbContext.Sales.Remove(sale);
                _appDbContext.SaveChangesAsync();
                return true;    
            }
            return false;
        }

        public async Task<List<SaleDto>> GetAllSale(CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Sales.ToListAsync(cancellationToken);
            return map.Map<List<SaleDto>>(list);
        }

        public async Task<SaleDto> GetKeySaleById(int id, CancellationToken cancellationToken)
        {
            var idsale = await _appDbContext.Sales.FindAsync(id, cancellationToken);
            if (idsale == null)
            {
                return null;
            }
            return map.Map<SaleDto>(idsale);    
        }

        public async Task<ErrorMessage> UpdateSale(int id, UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.SaleID == 0 )
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var udsale = await _appDbContext.Sales.FindAsync(id, cancellationToken);
                udsale.SaleName = request.SaleName;
                udsale.SalePercent = request.SalePercent;
                _appDbContext.Sales.Update(udsale);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
        public async Task<List<SaleDto>> Search(string salename, CancellationToken cancellationToken)
        {
            var check = _appDbContext.Sales.AsQueryable();
            if (!string.IsNullOrEmpty(salename)) // kiểm tra salename có null, "" hay không 
            {
                check = check.Where(s => s.SaleName.Contains(salename));
            }
            var res = await check.ToListAsync(cancellationToken);
            return map.Map<List<SaleDto>>(res);
        }
    }
}
