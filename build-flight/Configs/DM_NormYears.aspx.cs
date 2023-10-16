using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_DM_NormYears : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback || this.DataGrid.IsCallback)
            LoadNormYears();

        if (!this.IsCallback || this.NormYearGrid.IsCallback)
        {
            var aNormYearID = this.GetCallbackIntKeyValue("NormYearID");
            if (aNormYearID != 0)
                LoadCopyNormYear(aNormYearID);
        }
    }

    #region Load Data
    private int GetCallbackIntKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }

    private void LoadCopyNormYear(int NormYearIDFrom)
    {
        var list = entities.DM_NormYears
            .Where(x => x.NormYearID != NormYearIDFrom && (x.DeleteFlag ?? false) == false)
            .ToList();

        this.NormYearGrid.DataSource = list;
        this.NormYearGrid.DataBind();
    }
    private void LoadNormYears()
    {
        var list = entities.DM_NormYears
            .Where(x => (x.DeleteFlag ?? false) == false)
            .ToList();

        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }


    #endregion
    protected void DataGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        try
        {
            foreach (ASPxDataInsertValues insValues in e.InsertValues)
            {
                var entity = new DM_NormYears();

                entity.CreateDate = DateTime.Now;
                entity.CreatedBy = (int)SessionUser.UserID;

                if (insValues.NewValues["ForYear"] != null)
                {
                    int aForYear = Convert.ToInt32(insValues.NewValues["ForYear"]);
                    entity.ForYear = aForYear;
                }

                if (insValues.NewValues["Description"] != null)
                {
                    string aDescription = insValues.NewValues["Description"].ToString();
                    entity.Description = aDescription;
                }

                if (insValues.NewValues["Status"] != null)
                {
                    string aStatus = insValues.NewValues["Status"].ToString();
                    entity.Status = aStatus;
                }

                if (insValues.NewValues["TotalSalary"] != null)
                {
                    decimal aTotalSalary = Convert.ToDecimal(insValues.NewValues["TotalSalary"]);
                    entity.TotalSalary = aTotalSalary;
                }

                entities.DM_NormYears.Add(entity);
            }

            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal aNormYearID = Convert.ToDecimal(updValues.Keys["NormYearID"]);
                var entity = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID);
                if (entity != null)
                {
                    entity.LastUpdateDate = DateTime.Now;
                    entity.LastUpdatedBy = (int)SessionUser.UserID;

                    if (updValues.NewValues["ForYear"] != null)
                    {
                        int aForYear = Convert.ToInt32(updValues.NewValues["ForYear"]);
                        entity.ForYear = aForYear;
                    }

                    if (updValues.NewValues["Description"] != null)
                    {
                        string aDescription = updValues.NewValues["Description"].ToString();
                        entity.Description = aDescription;
                    }

                    if (updValues.NewValues["Status"] != null)
                    {
                        string aStatus = updValues.NewValues["Status"].ToString();
                        entity.Status = aStatus;
                    }

                    if (updValues.NewValues["TotalSalary"] != null)
                    {
                        decimal aTotalSalary = Convert.ToDecimal(updValues.NewValues["TotalSalary"]);
                        entity.TotalSalary = aTotalSalary;
                    }

                }
            }
            entities.SaveChanges();

            LoadNormYears();
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aNormYearID;

        if (Object.Equals(args[0], "DELETE"))
        {
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            var entity = entities.DM_NormYears.SingleOrDefault(x => x.NormYearID == aNormYearID);
            if (entity != null)
            {
                entity.DeleteFlag = true;
                entities.SaveChanges();
            }
            LoadNormYears();
        }

        if (Object.Equals(args[0], "COPY_DATA"))
        {
            int keyFrom;
            int keyTo;

            if (!int.TryParse(args[1], out keyFrom))
                return;

            if (!int.TryParse(args[2], out keyTo))
                return;

            SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@pNormYearIDFrom", keyFrom),
                        new SqlParameter("@pNormYearIDTo", keyTo),                
                        new SqlParameter("@pUserID", SessionUser.UserID)
                };

            entities.Database.ExecuteSqlCommand(DbHelper.GenerateCommandText("[KTQT_Data].[dbo].[PrcCopyNormData]", parameters), parameters);

            //entities.PrcCopyNormData(keyFrom, keyTo, SessionUser.UserID);
        }

    }

    protected void NormYearGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');

        int aNormYearID;

        if (Object.Equals(args[0], "LOAD_DATA"))
        {
            if (!int.TryParse(args[1], out aNormYearID))
                return;

            //LoadCopyNormYear(aNormYearID);

        }
    }
}