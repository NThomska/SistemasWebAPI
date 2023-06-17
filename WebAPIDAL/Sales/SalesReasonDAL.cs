using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDAL.Common;
using Entities.Sales;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace WebAPIDAL.Sales
{
    public class SalesReasonDAL : WebAPIBaseDAL
    {
        public SalesReasonDAL(string connectionString) : base(connectionString)
        {

        }

        public List<SalesReason> GetAllSalesReasons()
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            SqlCommand command = new()
            {
                Connection = connection,
                CommandText = "GetAllSalesReason",
                CommandType = CommandType.StoredProcedure
            };

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);

            var query = dt.AsEnumerable().Select(item => new SalesReason
            {
                SalesReasonID = Convert.ToInt32(item["SalesReasonID"]),
                Name = Convert.ToString(item["Name"]),
                ReasonType = Convert.ToString(item["ReasonType"]),
                ModifiedDate = Convert.ToDateTime(item["ModifiedDate"])
            });

            return query.ToList();
        }

        public async Task<SalesReason> GetSalesReasonById(int SalesReasonID)
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "GetSalesReasonById",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", SalesReasonID);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            SalesReason salesreason = new SalesReason();  

            if (reader.Read())
            {
                salesreason.SalesReasonID = Convert.ToInt32(reader["SalesReasonID"]);
                salesreason.Name = Convert.ToString(reader["Name"]);
                salesreason.ReasonType = Convert.ToString(reader["ReasonType"]);
                salesreason.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
            }
            
            return salesreason;
        }

        public async Task<int> CreateSalesReason(string name, string reasonType, DateTime modifiedDate)
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "CreateSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pReasonType", reasonType);
            command.Parameters.AddWithValue("@pModifiedDate", modifiedDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> UpdateSalesReason(int salesReasonId, string name, string reasonType, DateTime modifiedDate)
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "UpdateSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", salesReasonId);
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pReasonType", reasonType);
            command.Parameters.AddWithValue("@pModifiedDate", modifiedDate);

            return await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteSalesReason(int salesReasonId)
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            SqlCommand command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "DeleteSalesReason",
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@pSalesReasonId", salesReasonId);

            return await command.ExecuteNonQueryAsync();
        }

    }
}
