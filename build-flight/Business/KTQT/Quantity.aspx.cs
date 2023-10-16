using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_Quantity : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        SetPermistion();
        if (!IsPostBack)
        {
            this.FromDateEditor.Date = DateUtils.FirstDayOfMonth(true);
            this.ToDateEditor.Date = DateUtils.LastDayOfMonth(true);

            this.SyncFromDateEditor.Date = DateUtils.FirstDayOfMonth(true);
            this.SyncToDateEditor.Date = DateUtils.LastDayOfMonth(true);

            //this.MonthEditor.Value = DateTime.Now.Month;
            //this.YearEditor.Value = DateTime.Now.Year;

            this.dtpFromDateEditor.Value = DateUtils.FirstDayOfMonth(true);
            this.dtpToDateEditor.Value = DateUtils.LastDayOfMonth(true);
            //this.SyncDataListBox.SelectAll();
        }
        //if (!IsPostBack || this.FltOpsGrid.IsCallback)
        //{
        LoadFltOps();
        //}

        if (!IsPostBack)
            ASPxLabel1.Text = LoadMissingAC();
    }

    private string LoadMissingAC()
    {
        var fromDate = this.FromDateEditor.Date;
        var toDate = this.ToDateEditor.Date;
        var airport = this.AirportsEditor.Value != null ? this.AirportsEditor.Value.ToString() : SessionUser.AreaCode;
        var listAC = entities.V_FLT_OPS_ALL
            .Where(x => x.FltDate >= fromDate && x.FltDate <= toDate && x.AcID != "XXX" && !entities.AcGroupConverts.Select(t => t.AcIataCode).Contains(x.AcID.Trim()))
            .Select(x => x.AcID.Trim())
            .Distinct().ToList();
        if (listAC != null && listAC.Count() > 0)
            return "Danh sách các tàu bay chưa khai báo nhóm tàu bay: " + String.Join(", ", listAC.ToArray());

        return string.Empty;
    }

    private void SetPermistion()
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            btnSyncVMS.Visible = (SessionUser.IsInRole(PermissionConstant.SYNC_VMS_DATA));
        }
        else
            btnSyncVMS.Visible = true;
    }

    #region Load data

    private void LoadFltOps()
    {
        var fromDate = this.FromDateEditor.Date;
        var toDate = this.ToDateEditor.Date;
        var airport = this.AirportsEditor.Value != null ? this.AirportsEditor.Value.ToString() : SessionUser.AreaCode;

        var list = entities.V_FLT_OPS_ALL.Where(x => x.FltDate >= fromDate && x.FltDate <= toDate ).OrderBy(x => x.FltDate).ToList();
        this.FltOpsGrid.DataSource = list;
        this.FltOpsGrid.DataBind();
    }

    #endregion
    protected void FltOpsGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadData")
        {
            LoadFltOps();

            FltOpsGrid.JSProperties["cpMissAircraft"] = LoadMissingAC();
        }

        if (args[0] == "SyncVMS")
        {
            //var month = 1; // Convert.ToInt32(this.MonthEditor.Number);
            //var year = 2019; // Convert.ToInt32(this.YearEditor.Number);

            var fromDate = this.SyncFromDateEditor.Date;  // DateTimeUtils.getFirstDayOfMonth(year, month);
            var toDate = this.SyncToDateEditor.Date; //DateTimeUtils.getLastDayOfMonth(year, month);

            //var aFromDate = new SqlParameter("@pFromDate", System.Data.SqlDbType.Date);
            //aFromDate.Value = fromDate;

            //var aToDate = new SqlParameter("@pToDate", System.Data.SqlDbType.Date);
            //aToDate.Value = toDate;

            var values = this.SyncDataListBox.SelectedValues;

            if (values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    string value = (string)values[i];
                    switch (value)
                    {
                        case "CGH":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$Code_GroundHandling", new object[] { });
                            break;
                        case "SER":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Services", new object[] { });
                            break;
                        case "INV":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Invoice_Header @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Invoice_Detail @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            break;
                        case "VOU":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Contract_TurnArround", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Customer_Detail", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Voucher_Header @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Voucher_Detail @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DT_Voucher_Ex @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            break;
                        case "FLI":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$Code_TyGia", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DM_Aircraft", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$DecAircraft", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$Code_Airlines", new object[] { });
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$VOC_Flight_Departure @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            //entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$VOC_Flight_PaxCgo @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            //entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$VOC_Flight_Arrival @pFromDate, @pToDate", new SqlParameter("@pFromDate", fromDate), new SqlParameter("@pToDate", toDate));
                            break;
                        case "XRA":
                            entities.Database.ExecuteSqlCommand("EXEC STG_KTQT.dbo.Sync$Code_TyGia", new object[] { });
                            break;
                    }
                }
            }
        }

        if (args[0] == "RunAllocateOthRev")
        {
            var airport = this.AirportsEditor.Value != null ? this.AirportsEditor.Value.ToString() : SessionUser.AreaCode;
            var fromDate = this.dtpFromDateEditor.Date;
            var toDate = this.dtpToDateEditor.Date;
            entities.Pr_Allocate_OthRev(fromDate, toDate, airport);
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExporter.FileName = "Quantity.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        options.SheetName = "Quantity";
        GridViewExporter.WriteXlsxToResponse(options);
    }
    protected void AirportsEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => (x.IsCity ?? false) == true).ToList();

        ListEditItem le = new ListEditItem();
        le.Value = "ALL";
        le.Text = "--ALL--";
        s.Items.Add(le);
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
            s.Value = SessionUser.AreaCode != "KCQ" ? SessionUser.AreaCode : "ALL";
    }

    protected void FltOpsGrid_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
    {
        if (e.DataColumn.FieldName == "AC_ID")
        {
            if (e.CellValue != null)
            {
                if (e.CellValue.ToString().Trim().Equals("XXX")) return;
                var isExists = entities.AcGroupConverts.Where(x => x.AcIataCode == e.CellValue.ToString().Trim()).Any();
                if (!isExists)
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;
                    e.Cell.ToolTip = "Mã loại tàu bay chưa được khai báo trên KTQT";
                }
            }
            else
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Cell.ToolTip = "Mã loại tàu bay chưa được khai báo trên KTQT";
            }
        }
    }
    protected void GridViewExporter_RenderBrick(object sender, ASPxGridViewExportRenderingEventArgs e)
    {
        if (e.RowType != GridViewRowType.Data)
            return;

        if ((e.Column as GridViewDataColumn).FieldName == "AC_ID" && e.RowType != GridViewRowType.Header)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString().Trim().Equals("XXX")) return;
                var isExists = entities.AcGroupConverts.Where(x => x.AcIataCode == e.Value.ToString().Trim()).Any();
                if (!isExists)
                {
                    e.BrickStyle.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                e.BrickStyle.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}