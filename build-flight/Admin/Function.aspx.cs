using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APPData;

public partial class Admin_Function : BasePage
{
    QLKHAppEntities entities = new QLKHAppEntities();

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    Utils.ApplyTheme(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR))
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) && IsCorrectURL(Request.QueryString["ReturnUrl"]))
                Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnUrl"]));
            else
                Response.Redirect("~/Default.aspx");
        }

        LoadData();
        if (!IsPostBack)
        {
            treeListMenu.ExpandAll();
        }
    }

    private bool IsCorrectURL(string ReturnURL)
    {
        var menus = entities.Menus.Where(x => x.FileName != null && x.FileName != "").ToList();
        foreach (var menu in menus)
        {
            string fileName = menu.FileName.Replace("~/", "");
            if (ReturnURL.Contains(fileName))
                return true;
        }
        return false;
    }

    private void LoadData()
    {
        var menus = (from x in entities.Menus
                     orderby new { x.AppCode, x.Seq }
                     where x.IsDeleted == false
                     select x).ToList();
        treeListMenu.DataSource = menus;
        treeListMenu.DataBind();
    }
    protected void Menu_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    {
        string strParams = string.Empty;
        string url = string.Empty;
        switch (e.Item.Name.ToUpper())
        {
            case "PDF":
                TreeListExporter.WritePdfToResponse();
                break;
            case "XLS":
                TreeListExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                TreeListExporter.WriteXlsxToResponse();
                break;
            case "RTF":
                TreeListExporter.WriteRtfToResponse();
                break;
        }
    }


    protected void treeListMenu_NodeDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        try
        {
            var objMenu = entities.Menus.Find(e.Keys[0]);
            if (objMenu != null)
            {
                objMenu.IsDeleted = true;
                entities.SaveChanges();
                LoadData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
            // ghi log
        }
        finally
        {
            e.Cancel = true;
        }
    }
    protected void treeListMenu_NodeUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        try
        {
            var objMenu = entities.Menus.Find(Convert.ToInt32(e.Keys[0]));
            if (objMenu != null)
            {
                objMenu.NameEN = Convert.ToString(e.NewValues["NameEN"]);
                objMenu.NameVN = Convert.ToString(e.NewValues["NameVN"]);
                objMenu.AppCode = Convert.ToString(e.NewValues["AppCode"]);
                objMenu.FileName = Convert.ToString(e.NewValues["FileName"]);
                objMenu.MenuType = Convert.ToString(e.NewValues["MenuType"]);
                objMenu.ActionRight = Convert.ToString(e.NewValues["ActionRight"]);
                objMenu.Active = (Convert.ToInt32(e.NewValues["Active"]) == 0 ? false : true);
                objMenu.ParentMenuID = Convert.ToInt16(e.NewValues["ParentMenuID"]);
                objMenu.Seq = Convert.ToInt32(e.NewValues["Seq"]);
                objMenu.LastModifiedByUserID = SessionUser.UserID;
                objMenu.LastModifiedOnDate = DateTime.Now;
            }
            entities.SaveChanges();
            LoadData();
        }
        catch (Exception ex)
        {
            throw ex;
            // ghi log
        }
        finally
        {
            e.Cancel = true;

        }
    }
    protected void treeListMenu_NodeInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        try
        {

            APPData.Menu objMenu = new APPData.Menu();
            //add new values for objMenu
            objMenu.NameEN = Convert.ToString(e.NewValues["NameEN"]);
            objMenu.NameVN = Convert.ToString(e.NewValues["NameVN"]);
            objMenu.AppCode = Convert.ToString(e.NewValues["AppCode"]);
            objMenu.FileName = Convert.ToString(e.NewValues["FileName"]);
            objMenu.MenuType = Convert.ToString(e.NewValues["MenuType"]);
            objMenu.ActionRight = Convert.ToString(e.NewValues["ActionRight"]);
            objMenu.Active = (Convert.ToInt32(e.NewValues["Active"]) == 0 ? false : true);
            var maxSeq = entities.Menus.Max(o => o.Seq);
            objMenu.Seq = maxSeq + 1;
            int parentMenu = Convert.ToInt16(e.NewValues["ParentMenuID"]);
            if (parentMenu == 0) { objMenu.ParentMenuID = null; }
            else
            {
                objMenu.ParentMenuID = parentMenu;
            }
            objMenu.CreateOnDate = DateTime.Now;

            objMenu.CreatedByUserID = (int)SessionUser.UserID;
            objMenu.CssClass = "Sprite_Folder";
            objMenu.Active = true;
            objMenu.IsDeleted = false;

            entities.Menus.Add(objMenu);
            entities.SaveChanges();
            LoadData();
        }
        catch (Exception ex)
        {
            //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
            // ghi log
            throw ex;
        }
        finally
        {
            e.Cancel = true;

        }
    }
    public void FillMenuCombo(ASPxComboBox cmb)
    {
        var lstMenu = entities.Menus.Where(o => o.IsDeleted == false).ToList();
        cmb.Items.Clear();
        cmb.DataSource = lstMenu;
        cmb.ValueField = "MenuID";
        cmb.TextField = "NameVn";
        cmb.ValueType = typeof(System.Int32);
        cmb.DataBindItems();
        cmb.Items.Insert(0, new ListEditItem("Please choses Parent", null));

    }

    protected void treeListMenu_CellEditorInitialize(object sender, TreeListColumnEditorEventArgs e)
    {
        //int countNodos = treeListMenu.Nodes.Count; So luong nut
        try
        {
            int intMenuID = Convert.ToInt32(e.NodeKey);

            var objMenu = entities.Menus.Where(m => m.MenuID == intMenuID).First();
            if (intMenuID == 0)
            {
                if (e.Column.FieldName == "ParentMenuID")
                {
                    ASPxComboBox combo = e.Editor as ASPxComboBox;
                    FillMenuCombo(combo);
                }
            }
            else
            {
                if (e.Column.FieldName == "ParentMenuID")
                {
                    // initialize ASPxComboBox here 
                    ASPxComboBox comboBox = (ASPxComboBox)e.Editor;
                    FillMenuCombo(comboBox);
                    int intIndexValue = comboBox.Items.IndexOfValue(objMenu.ParentMenuID);
                    comboBox.SelectedIndex = (objMenu.ParentMenuID == null ? 0 : intIndexValue);
                }
            }
        }
        catch (Exception)
        {
            if (e.Column.FieldName == "ParentMenuID")
            {
                ASPxComboBox combo = e.Editor as ASPxComboBox;
                FillMenuCombo(combo);
                combo.SelectedIndex = 0;
            }
        }
    }

    protected void treeListMenu_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        var args = e.Argument.Split('|');
        if (args[0] == "BASEACTION")
        {
            int menuId;
            if (!int.TryParse(args[1], out menuId))
                return;

            var menu = entities.Menus.Where(x => x.MenuID == menuId).FirstOrDefault();
            if (menu != null && !string.IsNullOrEmpty(menu.ActionRight))
            {
                var i = 0;
                var baseActions = new string[] { "Create", "Edit", "Delete" };
                var baseActionNameVNs = new string[] { "Thêm", "Sửa", "Xóa" };
                var baseActionNameENs = new string[] { "New", "Edit", "Delete" };
                foreach (var action in baseActions)
                {
                    entities.Menus.Add(new APPData.Menu
                    {
                        AppCode = menu.AppCode,
                        MenuType = "ACTION",
                        NameEN = baseActionNameENs[i],
                        NameVN = baseActionNameVNs[i],
                        ActionRight = menu.ActionRight + "." + action,
                        ParentMenuID = menu.MenuID,
                        Active = true,
                        CreateOnDate = DateTime.Now,
                        CreatedByUserID = SessionUser.UserID.Value,
                        Seq = i + 1,
                        IsDeleted = false
                    });

                    i += 1;
                }
                entities.SaveChanges();
            }

            LoadData();
        }
        if (args[0] == "ADDACTION")
        {
            int menuId;
            if (!int.TryParse(args[1], out menuId))
                return;

            var menu = entities.Menus.Where(x => x.MenuID == menuId).FirstOrDefault();
            if (menu != null && !string.IsNullOrEmpty(menu.ActionRight))
            {
                var i = 0;
                var baseActions = new string[] { "NewAction" };
                var baseActionNameVNs = new string[] { "Thêm quyền" };
                var baseActionNameENs = new string[] { "New action right" };
                foreach (var action in baseActions)
                {
                    entities.Menus.Add(new APPData.Menu
                    {
                        AppCode = menu.AppCode,
                        MenuType = "ACTION",
                        NameEN = baseActionNameENs[i],
                        NameVN = baseActionNameVNs[i],
                        ActionRight = menu.ActionRight + "." + action,
                        ParentMenuID = menu.MenuID,
                        Active = true,
                        CreateOnDate = DateTime.Now,
                        CreatedByUserID = SessionUser.UserID.Value,
                        Seq = 4,
                        IsDeleted = false
                    });

                    i += 1;
                }
                entities.SaveChanges();
            }

            LoadData();
        }
    }
}