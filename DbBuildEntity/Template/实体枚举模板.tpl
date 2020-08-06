using System;

namespace @Model.NameSpace
{
	public enum TableNames { @(string.Join(",",@Model.TableNames.ToArray())) }

    #region EnumModel 
	@foreach(var item in Model.Tables)
	{
	@:public enum @item.TableName{ @(string.Join(",",item.Columns.ToArray())) }
	}
    #endregion
}