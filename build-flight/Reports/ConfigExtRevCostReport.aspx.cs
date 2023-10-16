using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ConfigExtRevCostReport : BasePageNotCheckURL
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadExtRevCostReports();
        }
    }

    #region Load data
    private void LoadExtRevCostReports()
    {
        var list = entities.ExtRevCostReports.OrderBy(x => x.Sorting).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion

    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadExtRevCostReports();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.ExtRevCostReports where x.ExtRevCostRepID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.ExtRevCostReports.Remove(entity);
                entities.SaveChanges();
                LoadExtRevCostReports();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;

                        var entity = entities.ExtRevCostReports.Where(x => x.ExtRevCostRepID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Sorting = Convert.ToInt32(SortingEditor.Number);
                            entity.Seq = SeqEditor.Text.Trim();
                            entity.Description = DescriptionEditor.Text.Trim();
                            entity.FSubCode = CodeFASTEditor.Text.Trim();
                            entity.FCode = FeeCodeEditor.Text.Trim();
                            entity.VMSCode = CodeVMSEditor.Text.Trim();

                            entity.Calculation = CalculationEditor.Value.ToString();
                            entity.IsBold = chkIsBold.Checked;

                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new ExtRevCostReport();
                        entity.Sorting = Convert.ToInt32(SortingEditor.Number);
                        entity.Seq = SeqEditor.Text.Trim();
                        entity.Description = DescriptionEditor.Text.Trim();
                        entity.FSubCode = CodeFASTEditor.Text.Trim();
                        entity.FCode = FeeCodeEditor.Text.Trim();
                        entity.VMSCode = CodeVMSEditor.Text.Trim();

                        entity.Calculation = CalculationEditor.Value.ToString();
                        entity.IsBold = chkIsBold.Checked;

                        entities.ExtRevCostReports.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadExtRevCostReports();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            int key;
            if (!int.TryParse(args[2], out key))
                return;

            var entity = entities.ExtRevCostReports.SingleOrDefault(x => x.ExtRevCostRepID == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, string>();
            result["Sorting"] = entity.Sorting.ToString();
            result["Seq"] = entity.Seq;
            result["Description"] = entity.Description;
            result["FSubCode"] = entity.FSubCode;
            result["FCode"] = entity.FCode;
            result["VMSCode"] = entity.VMSCode;
            result["Calculation"] = entity.Calculation;
            result["IsBold"] = entity.IsBold.HasValue && entity.IsBold.Value ? "True" : "False";

            e.Result = result;
        }
    }
    protected void DataGrid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("IsBold"), true))
        {
            e.Row.Font.Bold = true;
        }
    }
}