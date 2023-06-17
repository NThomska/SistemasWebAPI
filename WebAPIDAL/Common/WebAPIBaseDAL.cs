using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDAL.Common
{
    public class WebAPIBaseDAL
    {
        public string ConnectionString { get; set; }

        public WebAPIBaseDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetSqlConnection ()
        {
            return  new SqlConnection(this.ConnectionString);
        }
    }
}
