using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Business_KTQT_BCN_03 : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    const string KEY = "DA043407-6013-461C-9AEC-EA924C2261BA";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.QueryMonthEditor.Value = DateTime.Now.Month;
            this.QueryYearEditor.Value = DateTime.Now.Year;

        }
    }

    private void LoadData()
    {
        int month = Convert.ToInt32(QueryMonthEditor.Number);
        int year = Convert.ToInt32(QueryYearEditor.Number);
        //string areaCode = cboArea.Value.ToString();

        //entities.InitBCNTotal(year, month, areaCode, "BM5B", null);
        List<int> lstSub = entities.BCN_Report_Items.Where(x=>x.ItemGroup =="BM03").Select(x=>x.ItemID).ToList();
        var list = entities.BCN_Total.Where(x => x.Rpt_Yea == year && x.Rpt_Mon == month && lstSub.Contains((int)x.Sub_ID)).OrderByDescending(x => x.Note).ThenBy(x => x.Seq).ToList();
        DataGrid.DataSource = list;
        DataGrid.DataBind();
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        if (args[0] == "LoadData")
        {           
            LoadData();
        }
    }
    protected void cboArea_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Airports.Where(x => x.Code != "CTY").ToList();
        ListEditItem le = new ListEditItem();
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Value = item.Code;
            le.Text = item.NameE;
            s.Items.Add(le);
        }

        if (s.Items.Count > 0)
        {
            var curCompany = entities.DecCompanies.SingleOrDefault(x => x.CompanyID == SessionUser.CompanyID);
            if (curCompany != null)
                s.Value = curCompany.AreaCode;
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        LoadData();
        GridViewExporter.FileName = "BCN_03.xlsx";
        DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
        GridViewExporter.WriteXlsxToResponse(options);
    }
    protected void DataGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal? pla_thi_yea = null;
                decimal? pla_thi_mon = null;
                decimal? pla_acm_thi_mon = null;
                //decimal? acm_las_mon = null;
                decimal? est_thi_mon = null;
                //decimal? acm_thi_mon = null;
                //decimal? acm_las_mon_las_yea = null;
                //decimal? act_thi_mon_las_yea = null;
                //decimal? acm_thi_mon_las_yea = null;
                string note = null;
                decimal vID = Convert.ToDecimal(updValues.Keys["ID"]);
                var entity = entities.BCN_Total.SingleOrDefault(x => x.ID == vID);
                if (entity != null)
                {
                    if (updValues.NewValues["Pla_Thi_Yea"] != null)
                        pla_thi_yea = Convert.ToDecimal(updValues.NewValues["Pla_Thi_Yea"]);
                    if (updValues.NewValues["Pla_Thi_Mon"] != null)
                        pla_thi_mon = Convert.ToDecimal(updValues.NewValues["Pla_Thi_Mon"]);
                    if (updValues.NewValues["Pla_Acm_Thi_Mon"] != null)
                        pla_acm_thi_mon = Convert.ToDecimal(updValues.NewValues["Pla_Acm_Thi_Mon"]);
                    //if (updValues.NewValues["Acm_Las_Mon"] != null)
                    //    acm_las_mon = Convert.ToDecimal(updValues.NewValues["Acm_Las_Mon"]);
                    if (updValues.NewValues["Est_Thi_Mon"] != null)
                        est_thi_mon = Convert.ToDecimal(updValues.NewValues["Est_Thi_Mon"]);
                    //if (updValues.NewValues["Acm_Thi_Mon"] != null)
                    //    acm_thi_mon = Convert.ToDecimal(updValues.NewValues["Acm_Thi_Mon"]);
                    //if (updValues.NewValues["Acm_Las_Mon_Las_Yea"] != null)
                    //    acm_las_mon_las_yea = Convert.ToDecimal(updValues.NewValues["Acm_Las_Mon_Las_Yea"]);
                    //if (updValues.NewValues["Act_Thi_Mon_Las_Yea"] != null)
                    //    act_thi_mon_las_yea = Convert.ToDecimal(updValues.NewValues["Act_Thi_Mon_Las_Yea"]);
                    //if (updValues.NewValues["Acm_Thi_Mon_Las_Yea"] != null)
                    //    acm_thi_mon_las_yea = Convert.ToDecimal(updValues.NewValues["Acm_Thi_Mon_Las_Yea"]);
                    if (updValues.NewValues["Note"] != null)
                        note = Convert.ToString(updValues.NewValues["Note"]);
                      

                    entity.Pla_Thi_Yea = pla_thi_yea;
                    entity.Pla_Thi_Mon = pla_thi_mon;
                    entity.Pla_Acm_Thi_Mon = pla_acm_thi_mon;
                    //entity.Acm_Las_Mon = acm_las_mon;
                    entity.Est_Thi_Mon = est_thi_mon;
                    //entity.Acm_Thi_Mon = acm_thi_mon;
                    //entity.Acm_Las_Mon_Las_Yea = acm_las_mon_las_yea;
                    //entity.Act_Thi_Mon_Las_Yea = act_thi_mon_las_yea;
                    //entity.Acm_Thi_Mon_Las_Yea = acm_thi_mon_las_yea;
                    entity.Note = note;

                    entities.SaveChanges();

                    //Calculate BCN Total   
                    entities.BCN_Tot_Cal(entity.ID);
                    LoadData();
                }
            }
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        int month = Convert.ToInt32(QueryMonthEditor.Number);
        int year = Convert.ToInt32(QueryYearEditor.Number);
        entities.Gen_BCN_03(year, month);
        LoadData();
    }
}