using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ReadExcellApp.Services
{
    public class ReadExcellAppService : IReadExcellAppService
    {
        public List<FromExcel> GetDataToDataGridView()
        {
            using (IDbConnection db = new SqlConnection(SqlConnectionClass.ConnectionString()))
            {
                db.Open();

                List<FromExcel> dataGridViews = db.Query<FromExcel>("Part_GetDataToDGV", commandType: CommandType.StoredProcedure).ToList();

                return dataGridViews;
            }
        }

        public void SaveToDBPriceList(DataTable dataTable)
        {
            using (IDbConnection db = new SqlConnection(SqlConnectionClass.ConnectionString()))
            {
                db.Open();

                DynamicParameters para = new DynamicParameters();
                para.AddDynamicParams
                    (
                        new
                        {
                            Table = dataTable
                        }
                    );

                db.Query("Price_List_InsertFromExcel", para, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
