using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MicroMotion
{
    public partial class FormIntroduction : Form
    {
        public FormIntroduction()
        {
            InitializeComponent();
            webBrowser1.DocumentText = GetIntroductionString();
            //labelIntrodution.Text =
            //    "    1.打开软件后先完成串口的配置（注意两个串口的COM号必须不同），\r\n点击连接按钮，连接" +
            //    "成功且接线没有问题后便可开始点击六个设备名称打\r\n开操作界面并开始操作\r\n" +
            //    "    2.菜单栏的功能：\r\n" +
            //        "    连接：进行仪表连接\r\n" +
            //         "    断开连接：断开仪表连接\r\n" +
            //          "    通信参数：串口配置\r\n" +
            //           "    仪表位号：设置各个仪表的通信地址\r\n" +
            //            "    保存路径：设置PDF报告的生成路径\r\n" +
            //             "    历史数据：以表格的形式按检索条件查询历史数据\r\n" +
            //              "    报告管理：打开存储报告文件的路径\r\n" +
            //              "    用户管理：设置用户名、登录密码及分配权限\r\n" +
            //              "    版本：软件的开发版本号\r\n";
               
        }

        private const string HtmlBegin = "" +
            "<!DOCTYPE html>\n" +
            "<html>\n";
        private const string HeadBegin = "" +
            "<head>\n" +
            "<meta charset=\"UTF-8\">\n" +
            "<meta name=\"viewport\" content=\"width=device-width,initial-scale=1,maximum-scale=1\">\n";
        private const string HeadEnd = "" +
                "</head>\n" +
                "<body>\n";
        private const string HtmlEnd = "" +
                "</body>\n" +
                "</html>";

        string GetIntroductionString()
        {          
            var str = "<h2>操作说明</h2>" + "\r\n";
            str += "<p>" + "    1.打开软件后先完成串口的配置（注意两个串口的COM号必须不同），点击连接按钮，连接" +
                "成功且接线没有问题后便可开始点击六个设备名称打开操作界面并开始操作" + "</p>" + "\r\n";
            str += "<p>" + "    2.菜单栏的功能：" + "</p>" + "\r\n";
            str += "<p>" + "     - 连接：进行仪表连接" + "</p>" + "\r\n";
            str += "<p>" + "     - 断开连接：断开仪表连接" + "</p>" + "\r\n";
            str += "<p>" + "     - 通信参数：串口配置" + "</p>" + "\r\n";
            str += "<p>" + "     - 仪表位号：设置各个仪表的通信地址" + "</p>" + "\r\n";
            str += "<p>" + "     - 保存路径：设置PDF报告的生成路径" + "</p>" + "\r\n";
            str += "<p>" + "     - 报告管理：打开存储报告文件的路径" + "</p>" + "\r\n";
            str += "<p>" + "     - 用户管理：设置用户名、登录密码及分配权限" + "</p>" + "\r\n";
            str += "<p>" + "     - 版本：软件的开发版本号" + "</p>" + "\r\n";
            return HtmlBegin + HeadBegin + HeadEnd + str + HtmlEnd;
        }

    }
}
