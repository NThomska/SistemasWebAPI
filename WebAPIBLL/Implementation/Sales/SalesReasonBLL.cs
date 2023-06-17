using Entities.Sales;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBLL.Interfaces.Sales;
using WebAPIDAL.Sales;

namespace WebAPIBLL.Implementation.Sales
{
    public class SalesReasonBLL : ISalesReasonBLL
    {
        private readonly IConfiguration _configuration;
        private readonly SalesReasonDAL dbSalesReason;

        public SalesReasonBLL(IConfiguration configuration)
        {
            this._configuration = configuration;
            string connectionString = this._configuration.GetConnectionString(name: "DefaultConnectionString");
            this.dbSalesReason = new SalesReasonDAL(connectionString);
        }

        public List<SalesReason> GetAllSalesReasons()
        {
            return this.dbSalesReason.GetAllSalesReasons();
        }
        public async Task<SalesReason> GetSalesReasonById(int SalesReasonID)
        {
            return await this.dbSalesReason.GetSalesReasonById(SalesReasonID);
        }
        public async Task<int> CreateSalesReason(string name, string reasonType, DateTime modifiedDate)
        {
            return await this.dbSalesReason.CreateSalesReason(name, reasonType, modifiedDate);
        }
        public async Task<int> UpdateSalesReason(int salesReasonId, string name, string reasonType, DateTime modifiedDate)
        {
            return await this.dbSalesReason.UpdateSalesReason(salesReasonId, name, reasonType, modifiedDate);
        }
        public async Task<int> DeleteSalesReason(int salesReasonId)
        {
            return await this.dbSalesReason.DeleteSalesReason(salesReasonId);
        }
    }
}
