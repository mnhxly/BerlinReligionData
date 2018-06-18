using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO.Packaging;
using System.IO;
using System.Linq;

namespace BerlinReligionClassData.DAL
{
    public class ExcelReader
    {
        public bool ReadDataSource()
        {


            string fileName = @"/DataSources/final_od-teilnehmerzahlen-religions-und-weltanschauungsunterricht-3.xls";

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;

                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    Worksheet sheet = worksheetPart.Worksheet;

                    var cells = sheet.Descendants<Cell>();
                    var rows = sheet.Descendants<Row>();

                    Console.WriteLine("Row count = {0}", rows.LongCount());
                    Console.WriteLine("Cell count = {0}", cells.LongCount());

                    // One way: go through each cell in the sheet
                    foreach (Cell cell in cells)
                    {
                        if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                        {
                            int ssid = int.Parse(cell.CellValue.Text);
                            string str = sst.ChildElements[ssid].InnerText;
                            Console.WriteLine("Shared string {0}: {1}", ssid, str);
                        }
                        else if (cell.CellValue != null)
                        {
                            Console.WriteLine("Cell contents: {0}", cell.CellValue.Text);
                        }
                    }

                    // Or... via each row
                    foreach (Row row in rows)
                    {
                        foreach (Cell c in row.Elements<Cell>())
                        {
                            if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                            {
                                int ssid = int.Parse(c.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine("Shared string {0}: {1}", ssid, str);
                            }
                            else if (c.CellValue != null)
                            {
                                Console.WriteLine("Cell contents: {0}", c.CellValue.Text);
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
