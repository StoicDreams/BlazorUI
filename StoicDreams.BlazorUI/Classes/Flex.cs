namespace StoicDreams.BlazorUI.Classes;


/// <summary>
/// Const groupings of classes expected to be used on components that accomplish specific behaviors.
/// Naming conventions use a [Flex-Type][Horizonatal-Alignment][Vertical-Alignment] syntax.
/// </summary>
public static class Flex
{
	#region Flex Columns
	/// <summary>
	/// d-flex flex-column justify-start align-start mr-auto mb-auto
	/// </summary>
	public const string ColumnLeftTop = "d-flex flex-column justify-start align-start mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-column justify-center align-start mt-auto mr-auto mb-auto
	/// </summary>
	public const string ColumnLeftCenter = "d-flex flex-column justify-center align-start mt-auto mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-column justify-end align-start mt-auto mr-auto
	/// </summary>
	public const string ColumnLeftBottom = "d-flex flex-column justify-end align-start mt-auto mr-auto";

	/// <summary>
	/// d-flex flex-column justify-start align-center ml-auto mb-auto mr-auto
	/// </summary>
	public const string ColumnCenterTop = "d-flex flex-column justify-start align-center ml-auto mb-auto mr-auto";

	/// <summary>
	/// d-flex flex-column justify-center align-center ma-auto
	/// </summary>
	public const string ColumnCenterCenter = "d-flex flex-column justify-center align-center ma-auto";

	/// <summary>
	/// d-flex flex-column justify-end align-center ml-auto mt-auto mr-auto
	/// </summary>
	public const string ColumnCenterBottom = "d-flex flex-column justify-end align-center ml-auto mt-auto mr-auto";

	/// <summary>
	/// d-flex flex-column justify-start align-end mr-auto mb-auto
	/// </summary>
	public const string ColumnRightTop = "d-flex flex-column justify-start align-end mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-column justify-center align-end ml-auto mt-auto mb-auto
	/// </summary>
	public const string ColumnRightCenter = "d-flex flex-column justify-center align-end ml-auto mt-auto mb-auto";

	/// <summary>
	/// d-flex flex-column justify-end align-end ml-auto mt-auto
	/// </summary>
	public const string ColumnRightBottom = "d-flex flex-column justify-end align-end ml-auto mt-auto";
	#endregion

	#region Flex Rows
	/// <summary>
	/// d-flex flex-row justify-start align-start mr-auto mb-auto
	/// </summary>
	public const string RowLeftTop = "d-flex flex-row justify-start align-start mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-row justify-center align-start mt-auto mr-auto mb-auto
	/// </summary>
	public const string RowLeftCenter = "d-flex flex-row justify-center align-start mt-auto mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-row justify-end align-start mt-auto mr-auto
	/// </summary>
	public const string RowLeftBottom = "d-flex flex-row justify-end align-start mt-auto mr-auto";

	/// <summary>
	/// d-flex flex-row justify-start align-center ml-auto mb-auto mr-auto
	/// </summary>
	public const string RowCenterTop = "d-flex flex-row justify-start align-center ml-auto mb-auto mr-auto";

	/// <summary>
	/// d-flex flex-row justify-center align-center ma-auto
	/// </summary>
	public const string RowCenterCenter = "d-flex flex-row justify-center align-center ma-auto";

	/// <summary>
	/// d-flex flex-row justify-end align-center ml-auto mt-auto mr-auto
	/// </summary>
	public const string RowCenterBottom = "d-flex flex-row justify-end align-center ml-auto mt-auto mr-auto";

	/// <summary>
	/// d-flex flex-row justify-start align-end mr-auto mb-auto
	/// </summary>
	public const string RowRightTop = "d-flex flex-row justify-start align-end mr-auto mb-auto";

	/// <summary>
	/// d-flex flex-row justify-center align-end ml-auto mt-auto mb-auto
	/// </summary>
	public const string RowRightCenter = "d-flex flex-row justify-center align-end ml-auto mt-auto mb-auto";

	/// <summary>
	/// d-flex flex-row justify-end align-end ml-auto mt-auto
	/// </summary>
	public const string RowRightBottom = "d-flex flex-row justify-end align-end ml-auto mt-auto";
	#endregion
}
