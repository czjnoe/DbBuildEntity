﻿/*
*┌──────────────────────────────────────────┐
*│  描述：AdminstratorHelp                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/8 23:11:09                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbBuildEntity.Help
{
    public class AdminstratorHelp
    {
        public static void AdminstratorRun(Form form)
        {
            /**
            * 当前用户是管理员的时候，直接启动应用程序
            * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
            */
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //创建Windows用户主题
            Application.EnableVisualStyles();

            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行

                Application.EnableVisualStyles();
                Application.Run(form);
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //设置运行文件
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //设置启动参数
                //startInfo.Arguments = String.Join(" ", Args);
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    //如果不是管理员，则启动UAC
                    System.Diagnostics.Process.Start(startInfo);
                    //退出
                    System.Windows.Forms.Application.Exit();
                }
                catch
                {
                }
            }
        }
    }
}
