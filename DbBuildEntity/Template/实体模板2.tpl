using System;

namespace @Model.NameSpace
{
	@if(@Model.Description!=null&&@Model.Description!="")
	{
	/// <summary>
    /// 实体类@(Model.Description)
    /// </summary>
	}
    public class @Model.ClassName
    {
		#region Model
	@foreach(var item in Model.Columns)
	{
		@:private @item.TypeName _@item.ColumnName;
	}

	@foreach(var item in Model.Columns)
	{
		@:
		if (@item.Description!=null&&@item.Description!="")
		{
		@:/// <summary>
		@:/// @(item.Description)
		@:/// </summary>
		}
		@:public @item.TypeName @item.ColumnName
		@:{
			@:get
			@:{ 
				@:return _@item.ColumnName; 
			@:}
			@:set
			@:{
				@:this._@item.ColumnName = value;
			@:}
		@:}
	}
		#endregion
	}
}