using System.Collections.Generic;
using System.Data;

namespace ReadExcellApp.Services
{
    public interface IReadExcellAppService
    {
        List<FromExcel> GetDataToDataGridView();
        void SaveToDBPriceList(DataTable dataTable);
    }
}
