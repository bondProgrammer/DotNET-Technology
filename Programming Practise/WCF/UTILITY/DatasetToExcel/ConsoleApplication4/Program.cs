using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            DataSet ds = new DataSet();


            p.ExportToExcel(ds);

            
        }
        public void ExportToExcel(DataSet ds)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(@"D:\test.xls");
            foreach (DataTable dt in ds.Tables)
            {
                Excel.Worksheet excelWorksheet = excelWorkbook.Sheets.Add();
                excelWorksheet.Name = dt.TableName;
                for (int i = 1; i < dt.Columns.Count + 1; i++)
                {
                    excelWorksheet.Cells[1, i] = dt.Columns[i - 1].ColumnName; 
                }
                for (int j = 0; j < dt.Rows.Count ; j++)
                {
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        excelWorksheet.Cells[j + 2, k + 1] = dt.Rows[j].ItemArray[k].ToString();
                    }
                }
                excelWorkbook.Save();
                excelWorkbook.Close();
                excelApp.Quit();
            }
        }

        public void ExcelToData(string source)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook =excelApp.Workbooks.Open(Filename: source);
            DataSet ds = new DataSet();
            foreach (Excel.Worksheet sheet in excelWorkbook.Sheets)
            {
                Excel.Worksheet excelWorksheet = excelWorkbook.Sheets.Add();

                DataTable dt = new DataTable(sheet.Name);
                ds.Tables.Add(dt);
                //??? Fill dt from sheet 
            }         
        }
    }
}
