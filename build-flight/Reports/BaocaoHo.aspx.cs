using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using KTQTData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_BaocaoHo : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

            this.cboArea.Value = 3;
            this.seYear.Value = DateTime.Now.Year;
        }
       
      
    }


    protected MemoryStream CreateXlsxFileReport()
    {
        XtraReport report = null;
        if (rdReport.Value.ToString() == "CT")
        {
            report = new BaoCaoHo();
        }
        else if (rdReport.Value.ToString() == "TH")
        {
            report = new BaoCaoTongHo();
        }

        int companyID = Convert.ToInt32(this.cboArea.Value);
        int year = Convert.ToInt32(this.seYear.Value);
        report.Parameters["pCompanyID"].Value = companyID;
        report.Parameters["pYear"].Value = year;

        MemoryStream stream = new MemoryStream();

        XlsxExportOptions options = new XlsxExportOptions();
        options.ExportMode = XlsxExportMode.SingleFile;
        options.SheetName = rdReport.Value.ToString();
        report.ExportToXlsx(stream, options);

        stream.Position = 0;
        return stream;
    }

    string fileExtension(string format)
    {
        switch (format)
        {
            case "XLSX": return ".xlsx";
            case "PDF": return ".pdf";
            case "RTF": return ".rtf";
            case "HTML": return ".html";
            default: break;
        }
        return "XLSX";
    }
    protected void cboCompany_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        string areaCode = e.Parameter;
        LoadCompany(cbo, areaCode);


    }

    private void LoadCompany(ASPxComboBox cbo, string areaCode)
    {
        cbo.Items.Clear();
        if (areaCode.Equals("ALL"))
        {
            var list = entities.DecCompanies
                .Where(x => x.CompanyType == "D" && x.Active == true)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.AreaCode + "-" + x.NameV })
                .ToList();

            ListEditItem le = new ListEditItem();
            le.Value = 0;
            le.Text = "--All--";
            cbo.Items.Add(le);
            foreach (var item in list)
            {
                le = new ListEditItem();
                le.Value = item.CompanyID;
                le.Text = item.NameV;
                cbo.Items.Add(le);
            }
            //cbo.DataSource = list;
            //cbo.ValueField = "CompanyID";
            //cbo.TextField = "NameV";
            //cbo.DataBind();
        }
        else
        {
            var list = entities.DecCompanies
                .Where(x => x.CompanyType == "D" && x.AreaCode == areaCode && x.Active == true)
                .Select(x => new { CompanyID = x.CompanyID, NameV = x.AreaCode + "-" + x.NameV })
                .ToList();
            ListEditItem le = new ListEditItem();
            le.Value = 0;
            le.Text = "--All--";
            cbo.Items.Add(le);
            foreach (var item in list)
            {
                le = new ListEditItem();
                le.Value = item.CompanyID;
                le.Text = item.NameV;
                cbo.Items.Add(le);
            }
            //cbo.DataSource = list;
            //cbo.ValueField = "CompanyID";
            //cbo.TextField = "NameV";
            //cbo.DataBind();
        }
    }
    protected void cboVersion_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var versions = entities.Versions.ToList();
        cbo.DataSource = versions;
        cbo.ValueField = "VersionID";
        cbo.TextField = "Description";
        cbo.DataBind();
    }
    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxSpreadsheet1.Open(Guid.NewGuid().ToString(), DevExpress.Spreadsheet.DocumentFormat.Xlsx, () => { return CreateXlsxFileReport(); });
    }
}