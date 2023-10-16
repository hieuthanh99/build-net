using KTQTData;
using System;
using System.Data;

public partial class Admin_RunSQLScript : BasePage
{
    const string sessionSQL = "69e73033-b35d-47fc-b55a-cebdb0b89c75";

    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Remove(sessionSQL);

        if (DataGrid.IsCallback && Session[sessionSQL] != null)
        {
            if (this.GetGridCallbackType() != ASPxGridViewCallbackType.Custom)
            {
                string sql = Session[sessionSQL].ToString();
                if (!string.IsNullOrEmpty(sql))
                    RunSQLSript(sql);
            }
        }
    }

    #region Callback Type
    enum ASPxGridViewCallbackType
    {
        None, Custom, Sorting, ApplyFilter, FilterEditing, StartEdit, UpdateEdit,
        CancelEdit, AddNewRow, DeleteRow, FocusRow, GotoPage, ColumnMoved, ExpandGroup, CollapseGroup, Unknown
    };
    ASPxGridViewCallbackType GetGridCallbackType()
    {
        const string GridCallbackSuffix = "GB|";
        const string ActionSorting = "SORT";
        const string ActionEdit = "STARTEDIT";
        const string ActionUpdate = "UPDATEEDIT";
        const string ActionCancel = "CANCELEDIT";
        const string ActionAddNewRow = "ADDNEWROW";
        const string ActionDeleteRow = "DELETEROW";
        const string ActionFocusRow = "FOCUSEDROW";
        const string ActionGotoPage = "PAGERONCLICK";
        const string ActionCustom = "CUSTOMCALLBACK";
        const string ActionFilterShowMenu = "FILTERROWMENU";
        const string ActionFilterPopup = "FILTERPOPUP";
        const string ActionShowFilterControl = "SHOWFILTERCONTROL";
        const string ActionCloseFilterControl = "CLOSEFILTERCONTROL";
        const string ActionApplyFilter = "APPLYFILTER";
        const string ActionApplyColumnFilter = "APPLYHEADERCOLUMNFILTER";
        const string ActionColumnMoved = "COLUMNMOVE";
        const string ActionExpandGroup = "EXPANDROW";
        const string ActionCollapseGroup = "COLLAPSEROW";

        string callbackParam = Request.Params["__CALLBACKPARAM"];
        if (string.IsNullOrEmpty(callbackParam)) return ASPxGridViewCallbackType.None;
        if (!callbackParam.Contains(GridCallbackSuffix)) return ASPxGridViewCallbackType.None;
        string action = callbackParam.Substring(callbackParam.IndexOf(GridCallbackSuffix));
        if (action.Contains(ActionCustom)) return ASPxGridViewCallbackType.Custom;
        if (action.Contains(ActionSorting)) return ASPxGridViewCallbackType.Sorting;
        if (action.Contains(ActionEdit)) return ASPxGridViewCallbackType.StartEdit;
        if (action.Contains(ActionUpdate)) return ASPxGridViewCallbackType.UpdateEdit;
        if (action.Contains(ActionCancel)) return ASPxGridViewCallbackType.CancelEdit;
        if (action.Contains(ActionAddNewRow)) return ASPxGridViewCallbackType.AddNewRow;
        if (action.Contains(ActionDeleteRow)) return ASPxGridViewCallbackType.DeleteRow;
        if (action.Contains(ActionFocusRow)) return ASPxGridViewCallbackType.FocusRow;
        if (action.Contains(ActionGotoPage)) return ASPxGridViewCallbackType.GotoPage;
        if (action.Contains(ActionFilterShowMenu) || action.Contains(ActionFilterPopup) || action.Contains(ActionShowFilterControl)
        || action.Contains(ActionCloseFilterControl)) return ASPxGridViewCallbackType.FilterEditing;
        if (action.Contains(ActionApplyFilter) || action.Contains(ActionApplyColumnFilter)) return ASPxGridViewCallbackType.ApplyFilter;
        if (action.Contains(ActionColumnMoved)) return ASPxGridViewCallbackType.ColumnMoved;
        if (action.Contains(ActionExpandGroup)) return ASPxGridViewCallbackType.ExpandGroup;
        if (action.Contains(ActionCollapseGroup)) return ASPxGridViewCallbackType.CollapseGroup;
        return ASPxGridViewCallbackType.Unknown;
    }

    #endregion

    private void RunSQLSript(string sql)
    {
        if (string.IsNullOrEmpty(sql))
            return;

        if (!sql.Trim().ToUpper().StartsWith("SELECT"))
            return;

        if (sql.ToUpper().Contains("DROP"))
        {
            new UserFriendlyMessage("Statement is not valid and cannot execute.", SessionUser.UserName, UserFriendlyMessage.MessageType.WARN);
            return;
        }

        try
        {
            DataTable dt = entities.DataTable(sql);
            DataGrid.DataSource = dt;
            DataGrid.DataBind();


        }
        catch (Exception ex)
        {
            new UserFriendlyMessage(ex.Message, SessionUser.UserName, UserFriendlyMessage.MessageType.WARN);
        }
    }


    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "Exec")
        {
            var sql = args[1];
            Session[sessionSQL] = sql;

            RunSQLSript(sql);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string sql = Session[sessionSQL].ToString();
        if (!string.IsNullOrEmpty(sql))
        {
            RunSQLSript(sql);

            GridViewExporter.FileName = "DataResult.xlsx";
            DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
            options.SheetName = "Data";
            GridViewExporter.WriteXlsxToResponse(options);
        }
    }
}


