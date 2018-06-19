using System;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using ExcelDataReader;
using System.Data;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace BerlinReligionClassData.DAL
{
    public class ExcelReader
    {
        public bool ReadDataSource()
        {

            ISheet sheet;
            Stream templateStream = new MemoryStream();
            using (var file = new FileStream(@"DataSources/teilnehmerzahlen-religions-und-weltanschauungsunterricht.xls", FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(file);
                sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  

                IRow headerRow = sheet.GetRow(0); //Get Header Row
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        //if (row.GetCell(j) != null)
                        string st = row.GetCell(j).ToString();
                            //sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                    }
                    //sb.AppendLine("</tr>");
                }



                return true;
            }
        }
    }
}
