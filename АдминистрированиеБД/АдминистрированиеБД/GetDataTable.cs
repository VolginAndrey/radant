using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace АдминистрированиеБД
{
    class GetDataTable
    {
        public static DataTable getTable(string sql)
        {
                using (SqlConnection sqlConnection = new SqlConnection(DataSourseString.getString()))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
        }
    }
}
