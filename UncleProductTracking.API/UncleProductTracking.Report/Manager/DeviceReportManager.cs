using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using UncleProductTracking.Common.Helpers.Text;
using UncleProductTracking.Entities.Models;
using UncleProductTracking.Report.Interfaces;

namespace UncleProductTracking.Report.Manager
{
    public class DeviceReportManager : IDeviceReport
    {
        public MemoryStream ExportExcel(Device model)
        {
            try
            {
                string fileName = @"CihazDetay.xlsx";


                IWorkbook tempWorkBook;
                using (FileStream fs = new FileStream($"Reports/{fileName}", FileMode.Open, FileAccess.Read))
                {
                    tempWorkBook = new XSSFWorkbook(fs);
                }

                //bir sayfayı her sayfalamada kullanmak için templete olarak bıraktık ve görünürlüğünü kapattık.
                //Oluşan her sayfa bu temp sayfadan clone edilecek.
                tempWorkBook.SetSheetHidden(0, 2);

                ISheet excelSheet = tempWorkBook.CloneSheet(0);

                IRow row1 = excelSheet.GetRow(1);
                row1.GetCell(3).SetCellValue(model.CreatedDate.ToString("dd.MM.yyyy"));

                IRow row2 = excelSheet.GetRow(2);
                row2.GetCell(1).SetCellValue(model.SerialNumber);
                row2.GetCell(3).SetCellValue(model.DeviceType.Title);

                IRow row3 = excelSheet.GetRow(3);
                row3.GetCell(1).SetCellValue(model.ReaderSerialNumber);
                row3.GetCell(3).SetCellValue(model.IpNumber);

                IRow row4 = excelSheet.GetRow(4);
                row4.GetCell(1).SetCellValue((int)model.Fram == 1 ? "Var" : "Yok");
                row4.GetCell(3).SetCellValue((int)model.Confirmation == 1 ? "Evet" : "Hayır");

                IRow row5 = excelSheet.GetRow(5);
                row5.GetCell(1).SetCellValue(model.Fault);
                row5.GetCell(3).SetCellValue(model.Unit.Title);

                if (!string.IsNullOrEmpty(model.Descreption))
                {
                    IRow row6 = excelSheet.GetRow(7); ;
                    row6.GetCell(0).SetCellValue(TextHelper.StripHTML(model.Descreption));
                }

                var memoryStream = new MemoryStream();
                tempWorkBook.Write(memoryStream);
                memoryStream.Position = 0;

                return memoryStream;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MemoryStream ExportListExcel(List<Device> list)
        {
            try
            {
                string fileName = @"CihazListesi.xlsx";


                IWorkbook tempWorkBook;
                using (FileStream fs = new FileStream($"Reports/{fileName}", FileMode.Open, FileAccess.Read))
                {
                    tempWorkBook = new XSSFWorkbook(fs);
                }

                //bir sayfayı her sayfalamada kullanmak için templete olarak bıraktık ve görünürlüğünü kapattık.
                //Oluşan her sayfa bu temp sayfadan clone edilecek.
                tempWorkBook.SetSheetHidden(0, 2);

                ISheet excelSheet = tempWorkBook.CloneSheet(0);

                excelSheet.GetRow(1).GetCell(9).SetCellValue(DateTime.Now.ToString("dd.MM.yyyy"));

                int sira = 1;
                int rowNumber = 3;

                foreach (Device item in list)
                {
                    IRow row = excelSheet.GetRow(rowNumber);
                    row.GetCell(0).SetCellValue(sira);
                    row.GetCell(1).SetCellValue(item.SerialNumber);
                    row.GetCell(2).SetCellValue(item.DeviceType.Title);
                    row.GetCell(3).SetCellValue(item.ReaderSerialNumber);
                    row.GetCell(4).SetCellValue(item.IpNumber);
                    row.GetCell(5).SetCellValue((int)item.Fram == 1 ? "Var" : "Yok");
                    row.GetCell(6).SetCellValue(item.Fault);
                    row.GetCell(7).SetCellValue((int)item.Confirmation == 1 ? "Evet" : "Hayır");
                    row.GetCell(8).SetCellValue(item.Unit.Title);
                    row.GetCell(9).SetCellValue(item.CreatedDate.ToString("dd.MM.yyyy"));

                    sira++;
                    rowNumber++;

                    if (rowNumber == 30)
                    {
                        rowNumber = 3;
                        excelSheet = tempWorkBook.CloneSheet(0);
                        excelSheet.GetRow(1).GetCell(9).SetCellValue(DateTime.Now.ToString("dd.MM.yyyy"));
                    }
                }

                var memoryStream = new MemoryStream();
                tempWorkBook.Write(memoryStream);
                memoryStream.Position = 0;

                return memoryStream;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
