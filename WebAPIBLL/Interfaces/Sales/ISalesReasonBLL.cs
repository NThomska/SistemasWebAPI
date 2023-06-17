using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Sales;

namespace WebAPIBLL.Interfaces.Sales
{
    public interface ISalesReasonBLL
    {
        List<SalesReason> GetAllSalesReasons();
        Task<SalesReason> GetSalesReasonById(int SalesReasonID);
        Task<int> CreateSalesReason(string name, string reasonType, DateTime modifiedDate);
        Task<int> UpdateSalesReason(int salesReasonId, string name, string reasonType, DateTime modifiedDate);
        Task<int> DeleteSalesReason(int salesReasonId);
    }
}
