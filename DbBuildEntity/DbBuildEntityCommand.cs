//------------------------------------------------------------------------------
// <copyright file="DbBuildEntityCommand.cs" company="Company">
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
using System.IO;
using DbBuildEntity.Help;

namespace DbBuildEntity
{
    /// <summary>
    /// Command 项目按钮
    /// </summary>
    internal sealed class DbBuildEntityCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("39416edf-cdbb-43d9-9708-cc2cceb17bcf");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbBuildEntityCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private DbBuildEntityCommand(Package package)
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
        public static DbBuildEntityCommand Instance
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
            Instance = new DbBuildEntityCommand(package);
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
           var tuplePath= GetPath(ServiceProvider);
            //new FrmMain(tuplePath.Item2).ShowDialog();
            AdminstratorHelp.AdminstratorRun(new FrmMain(tuplePath.Item2));
        }

        private static Tuple<string, string, string> GetPath(IServiceProvider serviceProvider)
        {
            var dte = serviceProvider.GetService(typeof(DTE)) as DTE2;
            var projects = (UIHierarchyItem[])dte?.ToolWindows.SolutionExplorer.SelectedItems;
            if (projects == null)
            {
                //ShowMessage("未选中任何项目!", serviceProvider);
                return null;

            }
            var project = projects[0];
            var item = project.Object as Project;
            var path = item?.FullName;
            if (string.IsNullOrWhiteSpace(path))
            {
                //ShowMessage("项目路径为空!", serviceProvider);
                return null;

            }
            if (!File.Exists(path))
            {
                //ShowMessage(path + "文件不存在!", serviceProvider);
                return null;

            }

            var srcPath = item?.Properties.Item("FullPath").Value?.ToString();
            if (string.IsNullOrWhiteSpace(srcPath))
            {
                //ShowMessage("FullPath路径为空!", serviceProvider);
                return null;

            }
            //path:.csproj全路径
            //srcPath:.csproj所在的目录
            //item.Name:项目名称
            return Tuple.Create(path, srcPath, item.Name);
        }


    }
}
