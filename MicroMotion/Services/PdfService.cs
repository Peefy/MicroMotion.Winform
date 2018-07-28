using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using iTextSharp.text;
using iTextSharp.text.pdf;

using MicroMotion.Helpers;
using MicroMotion.Models;

namespace MicroMotion.Services
{
    public class PdfService : IPdfService
    {

        const int RowNum = 7;
        const int ColumnNum = 2;

        public static int Index;

        string[] TableFirstColumn =
        {
            "设备位号  Tag No",
            "原料名称  Material Name",
            "加料量  Batch Quantity",
            "加料日期  Date",
            "加料开始时间  Start Time",
            "加料结束时间  End Time",
            "备注",
        };

        
        public bool ExportDeviceRepport(int index,string savePath)
        {
            Index = index;
            string[] TableSecondColumn = 
            {
                Device.All[Index].TypeName,
                Device.All[Index].MaterialName,
                Device.All[Index].Real.ToString() + " kg",
                DateTime.Now.ToString("yyyy/MM/dd"),
                Device.All[Index].StartTime.ToString("yyyy/MM/dd HH:mm:ss"),
                Device.All[Index].EndTime.ToString("yyyy/MM/dd HH:mm:ss"),
                "操作员：" + User.Now.Name,
            };

            BaseFont bfSun;        
            try
            {
                bfSun = BaseFont.createFont(@"c:\windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            }
            catch 
            {
                MessageBox.Show("生成pdf失败,可能原因：\r\n未找到字体文件 c:\\windows\\Fonts\\simsun.ttc");
                return false;
            }
             
            Font font = new Font(bfSun, 12,Font.NORMAL);
            Font fontSmall = new Font(bfSun, 9,Font.NORMAL);
            Font fontTable = new Font(bfSun, 11,Font.NORMAL);
            Paragraph paragraph;
            Document document = new Document(PageSize.A4);
            try
            {
                PdfWriter.getInstance(document, new FileStream(savePath, FileMode.Create));
                #region 打开PDF
                document.addTitle("ReportForm");
                document.addSubject("About DemarcateResults");
                document.addKeywords("Demarcate");
                document.addCreator("DuGu");
                document.addAuthor("DuGu");
                document.addHeader("Expires", "0");
                document.Open();
                #endregion
                #region 生成的内容
                //1
                paragraph = new Paragraph("埃克森美孚（太仓）石油有限公司\r\n原料加料报告", new Font(bfSun, 16f,Font.NORMAL));
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph); document.Add(new Phrase("\r\n"));
                //2

                Table aTable = new Table(ColumnNum, RowNum) { Cellpadding = 2};
                for (int i = 0; i < RowNum; ++i)
                {
                    aTable.addCell(new Paragraph(TableFirstColumn[i], fontTable));
                    aTable.addCell(new Paragraph(TableSecondColumn[i], fontTable));
                }
                document.Add(aTable);

                document.Add(new Phrase("\r\n"));
                paragraph = new Paragraph("                                                 Signature\r\n" , font);
                document.Add(paragraph);

                paragraph = new Paragraph("                                                 签字： \r\n", font);
                document.Add(paragraph);

                #endregion
            }
            catch (DocumentException de)
            {
                throw (de);
            }
            catch (IOException ioe)
            {
                throw (ioe);
            }
            document.Close();
            return true;
        }
    }
}
