using ExcelDataReader;
using ReadExcellApp.Services;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ReadExcellApp
{
    public partial class Form1 : Form
    {
        DataTableCollection tableCollection;
        DataTable dataTableSelected;
        readonly IReadExcellAppService _readExcellAppService;
        public Form1()
        {
            InitializeComponent();
            _readExcellAppService = new ReadExcellAppService();
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTableSelected = tableCollection[cboSheet.SelectedItem.ToString()];
        }
  
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel|*.xls; *.xlsx" })
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using(var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();

                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dataTableSelected != null)
                try
                {
                    _readExcellAppService.SaveToDBPriceList(dataTableSelected);
                    var dataGridViews = _readExcellAppService.GetDataToDataGridView();
                    dataGridView1.DataSource = dataGridViews;
                    
                    MessageBox.Show("Complete !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

    }
}
