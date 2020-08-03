using System;

namespace @Model.NameSpace
{
    /// <summary>
    /// 实体类@(Model.Description)。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class @Model.ClassName
    {
@foreach(var item in Model.Columns)
{
		@:/// <summary>
		@:/// @(item.Description)
		@:/// </summary>
		@:public @item.TypeName @item.ColumnName { get; set; }
}
	}
}