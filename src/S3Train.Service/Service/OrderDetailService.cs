using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.DTOs;
namespace S3Train.Service
{
    public class OrderDetailService: GenenicServiceBase<CT_HoaDon>, IOrderDetailService
    {
        public OrderDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void InsertOrderDetail(CT_HoaDon orderDetail)
        {
                orderDetail.Id = Guid.NewGuid();
                DbContext.CT_HoaDons.Add(orderDetail);
                DbContext.SaveChanges();

        }
    }
}
