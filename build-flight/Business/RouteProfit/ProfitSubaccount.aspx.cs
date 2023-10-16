using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Linq;
using KTQTData;

public partial class Business_RouteProfit_ProfitSubaccount : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || this.RouteProfitsGrid.IsCallback || this.SubacountsGrid.IsCallback)
        {
            LoadProfitSubaccounts();
            if (!IsPostBack)
                this.RouteProfitsGrid.ExpandAll();
        }
        if (!IsPostBack || this.SubacountsGrid.IsCallback)
        {
            LoadSubaccounts();
            if (!IsPostBack)
                this.SubacountsGrid.ExpandAll();
        }
    }

    #region Load data

    private void LoadProfitSubaccounts()
    {
        var list = entities.RepRouteProfits.OrderBy(x => x.Seq).ToList();
        this.RouteProfitsGrid.DataSource = list;
        this.RouteProfitsGrid.DataBind();
    }

    private void LoadSubaccounts()
    {
        var list = entities.DecSubaccounts.OrderBy(x => x.Seq).ToList();
        this.SubacountsGrid.DataSource = list;
        this.SubacountsGrid.DataBind();
    }
    #endregion

    private void SetNodeSelectionSettings()
    {
        TreeListNodeIterator iterator = this.SubacountsGrid.CreateNodeIterator();
        TreeListNode node;
        while (true)
        {
            node = iterator.GetNext();
            if (node == null) break;
            node.AllowSelect = !node.HasChildren;
        }
    }

    private void RestoreSellection(int routeProfitID)
    {
        var keys = entities.DecSubaccounts.Where(x => x.RouteProfitID == routeProfitID).Select(x => x.SubaccountID).ToList();
        if (keys == null || keys.Count <= 0) return;

        var iterator = this.SubacountsGrid.CreateNodeIterator();
        iterator.Reset();

        while (iterator.Current != null)
        {
            if (!StringUtils.isEmpty(iterator.Current.Key))
                if (keys.Contains(Convert.ToInt32(iterator.Current.Key)))
                    iterator.Current.Selected = true;
            iterator.GetNext();
        }
    }

    protected void RouteProfitsGrid_HtmlRowPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void SubacountsGrid_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (Object.Equals(e.GetValue("Calculation"), "SUM"))
        {
            e.Row.Font.Bold = true;
        }
    }
    protected void SubacountsGrid_DataBound(object sender, EventArgs e)
    {
        SetNodeSelectionSettings();
    }
    protected void SubacountsGrid_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        ASPxTreeList s = sender as ASPxTreeList;
        string[] args = e.Argument.Split('|');
        int key;
        if (args[0] == "RestoreSellection")
        {
            if (!int.TryParse(args[1], out key))
                return;
            s.UnselectAll();
            RestoreSellection(key);
        }
        if (args[0] == "UpdateRouteProfitID")
        {
            if (!int.TryParse(args[1], out key))
                return;

            if (this.RouteProfitsGrid.FocusedNode == null)
                return;
            var routeProfitID = this.RouteProfitsGrid.FocusedNode.Key;

            var node = this.SubacountsGrid.FindNodeByKeyValue(key.ToString());
            if (node == null)
                return;

            var entity = entities.DecSubaccounts.SingleOrDefault(x => x.SubaccountID == key);
            if (entity == null)
                return;
            if (node.Selected)
                entity.RouteProfitID = Convert.ToInt32(routeProfitID);
            else
                entity.RouteProfitID = null;

            entities.SaveChanges();
        }

    }
    protected void ParentEditor_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.RepRouteProfits.OrderBy(x => x.Seq).ToList();
        s.DataSource = list;
        s.ValueField = "RouteProfitID";
        s.TextField = "Description";
        s.DataBind();
    }
}