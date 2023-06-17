using Entities.Sales;
using Microsoft.AspNetCore.Mvc;
using WebAPIBLL.Interfaces.Sales;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReasonController : Controller
    {
        private readonly ISalesReasonBLL _bll;

        public SalesReasonController(ISalesReasonBLL bll)
        {
            this._bll = bll;
        }


        /// <summary>
        /// Retorna una lista de los Sales Reason.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SalesReason> GetAllSalesReason()
        {
            return this._bll.GetAllSalesReasons();
        }

        /// <summary>
        /// Obtener un sales reason por un id
        /// </summary>
        /// <param name="saleReasonId"></param>
        /// <returns><see cref="SalesReason"></returns>
        [HttpGet("{saleReasonId}")]
        public async Task<SalesReason> GetSalesReasonById(int saleReasonId)
        {
            return await this._bll.GetSalesReasonById(saleReasonId);
        }

        /// <summary>
        /// Crea un nuevo Sales Reason
        /// </summary>
        /// <param name="salesReason"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateSalesReason(SalesReason salesReason)
        {
            return await this._bll.CreateSalesReason(salesReason.Name, salesReason.ReasonType, salesReason.ModifiedDate);
        }

        /// <summary>
        /// Modifica un Sales Reason
        /// </summary>
        /// <param name="salesReason"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateSalesReson(SalesReason salesReason)
        {
            return await this._bll.UpdateSalesReason(salesReason.SalesReasonID, salesReason.Name, salesReason.ReasonType, salesReason.ModifiedDate);
        }

        /// <summary>
        /// Elimina un Sales Reason
        /// </summary>
        /// <param name="salesReasonId"></param>
        /// <returns></returns>
        [HttpDelete("{salesReasonId}")]
        public async Task<int> DeleteSalesReason(int salesReasonId)
        {
            return await this._bll.DeleteSalesReason(salesReasonId);
        }
    }
}
