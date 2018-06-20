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
using System.Collections.Generic;
using BerlinReligionClassData.Models;

namespace BerlinReligionClassData.DAL
{
    public class ExcelReader
    {

        public List<Participant> ReadParticipantSource()
        {
            List<Participant> parList = new List<Participant>();

            int id = 1;

            ISheet sheet;
            Stream templateStream = new MemoryStream();
            using (var file = new FileStream(@"DataSources/teilnehmerzahlen-religions-und-weltanschauungsunterricht.xls", FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(file);
                sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  

                IRow headerRow = sheet.GetRow(0); //Get Header Row
                int cellCount = headerRow.LastCellNum;


                for (int i = (4); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int l = 2; l < row.Cells.Count; l++)
                    {
                        int year = 0;
                        switch (l)
                        {
                            case 2:
                                year = 2011;
                                break;
                            case 3:
                                year = 2012;
                                break;
                            case 4:
                                year = 2013;
                                break;
                            case 5:
                                year = 2014;
                                break;
                            case 6:
                                year = 2015;
                                break;
                            case 7:
                                year = 2016;
                                break;
                            default:

                                break;
                        }
                            Participant p = new Participant(id, Convert.ToDouble(row.Cells[l].ToString()), year, row.Cells[1].ToString(), Convert.ToInt32(row.Cells[0].ToString()));
                        id++;
                        parList.Add(p);
                    }

                }



                return parList;
            }
        }

            public List<Subvention> ReadSubventionSource()
            {
                List<Subvention> subList = new List<Subvention>();
                int id = 1;

                ISheet sheet;
                Stream templateStream = new MemoryStream();
                using (var file = new FileStream(@"DataSources/zuschuesse-religions-und-weltanschauungsunterricht.xls", FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(file);
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  

                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;


                    for (int i = (2); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int l = 2; l < row.Cells.Count; l++)
                        {
                            int year = 0;
                            switch (l)
                            {
                                case 2:
                                    year = 2011;
                                    break;
                                case 3:
                                    year = 2012;
                                    break;
                                case 4:
                                    year = 2013;
                                    break;
                                case 5:
                                    year = 2014;
                                    break;
                                case 6:
                                    year = 2015;
                                    break;
                                case 7:
                                    year = 2016;
                                    break;
                                default:

                                    break;
                            }
                            Subvention s = new Subvention(id, Convert.ToDouble(row.Cells[l].ToString()), year, row.Cells[1].ToString(), Convert.ToInt32(row.Cells[0].ToString()));
                            id++;
                            subList.Add(s);
                        }

                    }



                    return subList;
                }
            }
        }
    }

