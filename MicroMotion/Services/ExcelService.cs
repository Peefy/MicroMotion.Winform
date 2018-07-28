using System;
using System.IO;
using System.Windows.Forms;

using NPOI.HPSF;
using NPOI.HSSF.UserModel;

using MicroMotion.Helpers;
using MicroMotion.Utils;

namespace MicroMotion.Services
{
    public class ExcelService : IExcelService
    {
        const string ExcelSaveFilter = "生成excel（*.xls）|*.xls";

        public int ColumnCount = 7;

        public string[] HeadRowText = 
        {
            "设备位号",
            "原料名称",
            "加料量（kg）",
            "加料日期",
            "加料开始时间",
            "加料结束时间",
            "操作员",
        };

        public bool IsFindData { get; set; }

        public void Export(SaveFileDialog saveFileDialog)
        {
            try
            {
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.Filter = ExcelSaveFilter;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var savePath = saveFileDialog.FileName;
                    using (MemoryStream ms = Export(true))
                    {
                        using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] data = ms.ToArray();
                            fs.Write(data, 0, data.Length);
                            fs.Flush();
                        }
                    }
             
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ExportPath(string fileName)
        {
            var fullFileName = fileName + ".xls";
            var startPath = Application.StartupPath;
            var savePath = startPath + "\\ExcelData\\";
            if (Directory.Exists(savePath) == false) Directory.CreateDirectory(savePath);
            using (MemoryStream ms = Export(true))
            {
                using (FileStream fs = new FileStream(savePath + fullFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        MemoryStream Export(bool isPrivate)
        {
            HSSFWorkbook workBook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workBook.CreateSheet();

            #region 右击文件属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();

                dsi.Company = "DuGu";
                workBook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "DuGu";
                si.ApplicationName = "DuGu_NPOI_" + AppHelper.ApplicationName;
                si.LastAuthor = "DuGu";
                si.Comments = "DuGu";
                si.Title = "DuGu";
                si.Subject = "DemarcateResults";
                si.CreateDateTime = DateTime.Now;
                workBook.SummaryInformation = si;

            }
            #endregion

            HSSFCellStyle dateStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workBook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            int[] arrColWidth = { 20, 20, 20, 20, 20, 20, 20,};
            #region 表头样式
            HSSFRow headerRow;
            HSSFCellStyle headStyle = (HSSFCellStyle)workBook.CreateCellStyle();
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            HSSFFont font = (HSSFFont)workBook.CreateFont();
            #endregion

            headerRow = (HSSFRow)sheet.CreateRow(0);
            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            font.FontHeightInPoints = 15;
            font.Boldweight = 400;
            headStyle.SetFont(font);

            for (int i = 0; i < HeadRowText.Length; ++i)
            {
                headerRow.CreateCell(i).SetCellValue(HeadRowText[i]);
                headerRow.GetCell(i).CellStyle = headStyle;
            }
            var datas = SqliteUtil.Instance.Datas;
            for (int i = 0; i < datas.Count; ++i)
            {
                headerRow = (HSSFRow)sheet.CreateRow(i + 1);
                headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                font.FontHeightInPoints = 15;
                font.Boldweight = 400;
                headStyle.SetFont(font);

                headerRow.CreateCell(0).SetCellValue(datas[i].TypeName);
                headerRow.GetCell(0).CellStyle = headStyle;

                headerRow.CreateCell(1).SetCellValue(datas[i].MaterialName);
                headerRow.GetCell(1).CellStyle = headStyle;

                headerRow.CreateCell(2).SetCellValue(double.Parse(datas[i].Real));
                headerRow.GetCell(2).SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                headerRow.GetCell(2).CellStyle = headStyle;

                headerRow.CreateCell(3).SetCellValue(datas[i].Date);
                headerRow.GetCell(3).CellStyle = headStyle;

                headerRow.CreateCell(4).SetCellValue(datas[i].StartTime);
                headerRow.GetCell(4).CellStyle = headStyle;

                headerRow.CreateCell(5).SetCellValue(datas[i].EndTime);
                headerRow.GetCell(5).CellStyle = headStyle;

                headerRow.CreateCell(6).SetCellValue(datas[i].UserName);
                headerRow.GetCell(6).CellStyle = headStyle;

            }

            sheet.SetColumnWidth(0, 20 * 256);
            sheet.SetColumnWidth(1, 30 * 256);
            sheet.SetColumnWidth(2, 20 * 256);
            sheet.SetColumnWidth(3, 30 * 256);
            sheet.SetColumnWidth(4, 30 * 256);
            sheet.SetColumnWidth(5, 30 * 256);
            sheet.SetColumnWidth(6, 25 * 256);

            using (MemoryStream ms = new MemoryStream())
            {
                workBook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }


        public void Export(string path)
        {
            using (MemoryStream ms = Export(true))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }

        }
    }
}
