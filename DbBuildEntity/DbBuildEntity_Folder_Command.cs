//------------------------------------------------------------------------------
// <copyright file="DbBuildEntity_Folder_Command.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using DbBuildEntity.UI;
using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.IO;

namespace DbBuildEntity
{
    /// <summary>
    /// Command 项目文件按钮
    /// </summary>
    internal sealed class DbBuildEntity_Folder_Command
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4129;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("49FD28ED-B8D2-4511-B461-E561D9B0127D");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbBuildEntity_Folder_Command"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private DbBuildEntity_Folder_Command(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static DbBuildEntity_Folder_Command Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new DbBuildEntity_Folder_Command(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var tuplePath=GetFolderPath(ServiceProvider);
            new FrmMain(tuplePath.Item2).ShowDialog();
            //string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            //string title = "DbBuildEntity_Folder_Command";

            //// Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this.ServiceProvider,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }


        /// <summary>
        /// 获取当前选中的文件夹路径
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static Tuple<string, string, string> GetFolderPath(IServiceProvider serviceProvider)
        {
            var dte = serviceProvider.GetService(typeof(DTE)) as DTE2;
            var projects = (UIHierarchyItem[])dte?.ToolWindows.SolutionExplorer.SelectedItems;
            if (projects == null)
            {
                //ShowMessage("未选中任何项目!", serviceProvider);
                return null;
            }
            var project = projects[0];
            var item = project.Object as dynamic;

            var parentProject = item.ContainingProject as Project;


            var path = parentProject?.Properties.Item("FullPath").Value?.ToString();
            if (string.IsNullOrWhiteSpace(path))
            {
                //ShowMessage("项目路径为空!", serviceProvider);
                return null;
            }
            var projectFullPath = parentProject?.FullName;
            if (!File.Exists(projectFullPath))
            {
                //ShowMessage(path + "文件不存在!", serviceProvider);
                return null;
            }
            Stack<string> filderPathStack = new Stack<string>();
            filderPathStack = FolderRecursion(project, filderPathStack);
            string filderPath = string.Empty;
            foreach (var stack in filderPathStack)
            {
                filderPath += stack;
            }

            var srcPath = parentProject?.Properties.Item("FullPath").Value?.ToString() + filderPath;
            if (string.IsNullOrWhiteSpace(srcPath))
            {
                //ShowMessage("FullPath路径为空!", serviceProvider);
                return null;
            }
            //path:.当前项目根目录
            //srcPath:当前选择文件夹所在的路径
            //item.Name:当前选择文件夹名称
            return Tuple.Create(path, srcPath, item.Name);
        }

        /// <summary>
        /// 递归路径
        /// </summary>
        /// <param name="project"></param>
        /// <param name="stack">堆</param>
        /// <returns></returns>
        private static Stack<string> FolderRecursion(UIHierarchyItem project, Stack<string> stack)
        {
            if (project.Object is Project)
            {
                return stack;
            }
            else
            {
                var parent = project.Collection.Parent as UIHierarchyItem;
                stack.Push(project.Name + "\\");
                FolderRecursion(parent, stack);
            }
            return stack;
        }

    }
}
