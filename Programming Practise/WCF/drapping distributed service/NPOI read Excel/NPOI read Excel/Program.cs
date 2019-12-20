using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOI_read_Excel
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IWorkbook workbook;
            string excelFilePath = @"D:\FABRIC CODE_SRIKANTH P.xls";
            using (FileStream stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(stream);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            DataTable dt = new DataTable();
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }
            int ac = 1;
            for (int i = (sheet.FirstRowNum + 3); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                if (row == null)
                {
                    break;
                }
                for (int j = row.FirstCellNum; j < cellCount - 1; j++)
                {
                    dataRow[0] = ac;
                    if (row.GetCell(j) != null)
                        dataRow[j + 1] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
                ac++;
            }
            var dtt = dt;



        }

    }
}