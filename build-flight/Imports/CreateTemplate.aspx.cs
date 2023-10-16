using DevExpress.Web;
using DevExpress.Web.Data;
using KTQTData;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Imports_CreateTemplate : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region
    private void LoadTemplate(string ETcode)
    {
        var list = entities.ETColumns.Where(x => x.ETCode == ETcode).OrderBy(x => x.Seq).ToList();
        this.TemplateGrid.DataSource = list;
        this.TemplateGrid.DataBind();
    }

    #endregion
    protected void cboTableName_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.ETParameters
            .Select(x => new
            {
                ETCode = x.ETCode,
                Name = x.Name,
                ToTableName = x.ToTableName,
                FileType = x.FileType,
                CreateDate = x.CreateDate
            }).OrderBy(x => x.CreateDate)
            .ToList();
        cbo.DataSource = list;
        cbo.ValueField = "ETCode";
        cbo.DataBind();
    }

    private void ReorderSeq(string etCode)
    {
        var list = entities.ETColumns.Where(x => x.ETCode == etCode).OrderBy(x => x.Seq).ToList();
        int i = 0;
        foreach (ETColumn col in list)
        {
            i += 1;
            col.Seq = i;
        }
        entities.SaveChangesWithAuditLogs();
    }

    protected void TemplateGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        var args = e.Parameters.Split('|');

        if (args[0] == "LoadData")
        {
            var ETCode = args[1];
            LoadTemplate(ETCode);
        }

        if (args[0] == "CreateTemplate")
        {
            var ETCode = args[1];

            var para = entities.ETParameters.SingleOrDefault(x => x.ETCode == ETCode);
            if (para != null)
            {
                entities.CreateTemplate(ETCode, para.ToTableName, SessionUser.UserID);

                entities.SaveChangesWithAuditLogs();
            }
            LoadTemplate(ETCode);
        }

        if (args[0] == "ReCreate")
        {
            var ETCode = args[1];

            var para = entities.ETParameters.SingleOrDefault(x => x.ETCode == ETCode);
            if (para != null)
            {
                entities.CreateTemplate(ETCode, para.ToTableName, SessionUser.UserID);
                entities.SaveChangesWithAuditLogs();
            }
            LoadTemplate(ETCode);
        }

        if (args[0] == "ReorderSeq")
        {
            var ETCode = args[1];
            ReorderSeq(ETCode);

            LoadTemplate(ETCode);
        }

        if (args[0] == "Delete")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var template = entities.ETColumns.SingleOrDefault(x => x.HeaderID == key);
            if (template != null)
            {
                var etCode = template.ETCode;
                entities.ETColumns.Remove(template);

                entities.SaveChangesWithAuditLogs();

                ReorderSeq(etCode);

                LoadTemplate(etCode);
            }
        }

        if (args[0] == "Up")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var up = entities.ETColumns.SingleOrDefault(x => x.HeaderID == key);
            if (up == null)
                return;

            var tempSeq = up.Seq;
            var etCode = up.ETCode;

            var down = entities.ETColumns.SingleOrDefault(x => x.ETCode == etCode && x.Seq == (tempSeq - 1));
            if (down == null)
                return;

            up.Seq = tempSeq - 1;
            down.Seq = tempSeq;

            entities.SaveChangesWithAuditLogs();

            grid.FocusedRowIndex = ((int)tempSeq - 1);

            LoadTemplate(etCode);
        }

        if (args[0] == "Down")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var down = entities.ETColumns.SingleOrDefault(x => x.HeaderID == key);
            if (down == null)
                return;

            var tempSeq = down.Seq;
            var etCode = down.ETCode;

            var up = entities.ETColumns.SingleOrDefault(x => x.ETCode == etCode && x.Seq == (tempSeq + 1));
            if (up == null)
                return;

            up.Seq = tempSeq;
            down.Seq = tempSeq + 1;

            entities.SaveChangesWithAuditLogs();

            grid.FocusedRowIndex = ((int)tempSeq + 1);

            LoadTemplate(etCode);
        }
    }
    protected void TemplateGrid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        if (e.Column.FieldName == "Seq"
            || e.Column.FieldName == "ColumnName"
            || e.Column.FieldName == "DataType"
            || e.Column.FieldName == "DataLength")
            e.Editor.ReadOnly = true;

    }
    protected void TemplateGrid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        string etCode = string.Empty;
        try
        {
            foreach (ASPxDataUpdateValues updValues in e.UpdateValues)
            {
                decimal vHeaderID = Convert.ToDecimal(updValues.Keys["HeaderID"]);
                var entity = entities.ETColumns.SingleOrDefault(x => x.HeaderID == vHeaderID);
                if (entity != null)
                {
                    if (updValues.NewValues["Description"] != null)
                        entity.Description = updValues.NewValues["Description"].ToString();
                    if (updValues.NewValues["ColumnWidth"] != null)
                        entity.ColumnWidth = Convert.ToInt32(updValues.NewValues["ColumnWidth"]);

                    if (StringUtils.isEmpty(etCode))
                        etCode = entity.ETCode;

                    entities.SaveChangesWithAuditLogs();
                }
                LoadTemplate(etCode);

                ReorderSeq(etCode);
            }
        }
        catch (Exception ex) { }
        finally
        {
            e.Handled = true;
        }
    }
    protected void CreateTemplateCallback_Callback(object source, CallbackEventArgs e)
    {
        var args = e.Parameter.Split('|');

        if (args[0] == "CreateTemplateFile")
        {
            var etCode = args[1];
            //var newFile = new FileInfo(@"D:\Works\FileStorage\Test.xlsx");
            //if (newFile.Exists)
            //    newFile.Delete();

            using (ExcelPackage xlPackage = new ExcelPackage())
            {
                var workBook = xlPackage.Workbook;
                var workSheet = workBook.Worksheets.Add(etCode);

                workSheet.Cells["A1"].Value = "Mẫu đổ Dữ liệu vào SQLServer";
                workSheet.Cells["A1:C1"].Merge = true;
                workSheet.Cells["A2"].Value = "(Mẫu này được sinh ra bởi chương trình đổ số liệu)";
                workSheet.Cells["A2:F2"].Merge = true;
                workSheet.Cells["A3:B3"].Value = "Sử dụng mẫu";
                workSheet.Cells["A3:B3"].Merge = true;
                workSheet.Cells["C3"].Value = etCode;
                workSheet.Cells["A4"].Value = "Cột có màu sắc thể hiện dữ liệu bắt buộc phải nhập";
                workSheet.Cells["A4:F4"].Merge = true;
                workSheet.Cells["A5"].Value = "Cột có màu sắc thể hiện dữ liệu không bắt buộc nhập số liệu";
                workSheet.Cells["A5:F5"].Merge = true;

                workSheet.Cells["G1"].Value = "Lưu ý:";
                workSheet.Cells["H1:R1"].Value = "Không xóa, thêm mới hoặc hiệu chỉnh các cột thông tin của các dòng từ 1-8, để hiệu chỉnh vào chương trình để thực hiện";
                workSheet.Cells["H1:R1"].Merge = true;
                workSheet.Cells["H2:R2"].Value = "Dữ liệu đổ vào hệ thống sẽ được bắt đầu từ dòng thứ 9";
                workSheet.Cells["H2:R2"].Merge = true;
                workSheet.Cells["H3:R3"].Value = "Không sửa đổi tên các Sheet nó là thông tin báo cho hệ thống đổ số liệu vào bảng nào";
                workSheet.Cells["H3:R3"].Merge = true;
                workSheet.Cells["H4:R4"].Value = "Với dữ liệu kiểu ngày tháng thống nhất 1 kiểu dữ liệu";
                workSheet.Cells["H4:R4"].Merge = true;

                var cols = entities.ETColumns.Where(x => x.ETCode == etCode).OrderBy(x => x.Seq).ToList();

                int i = 7;
                int j = 1;
                foreach (var col in cols)
                {
                    workSheet.Cells[i, j].Value = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
                    workSheet.Cells[i + 1, j].Value = col.ColumnName;

                    j += 1;
                }

                var allCells = workSheet.Cells[1, 1, workSheet.Dimension.End.Row, workSheet.Dimension.End.Column];
                allCells.AutoFitColumns(10);
                var cellFont = allCells.Style.Font;
                cellFont.SetFromFont(new Font("Times New Roman", 12));

                cellFont = workSheet.Cells["A1:C1"].Style.Font;
                cellFont.Color.SetColor(Color.DarkBlue);
                //cellFont.Bold = true;
                cellFont.Size = 14;

                cellFont = workSheet.Cells["A2:F2"].Style.Font;
                cellFont.Color.SetColor(Color.DarkBlue);

                cellFont = workSheet.Cells["A3:B3"].Style.Font;
                cellFont.Color.SetColor(Color.DarkBlue);

                cellFont = workSheet.Cells["C3"].Style.Font;
                cellFont.Color.SetColor(Color.DarkBlue);
                cellFont.Bold = true;

                workSheet.Cells["A4:F4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A4:F4"].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                workSheet.Cells["A4:F4"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A4:F4"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A4:F4"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A4:F4"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                cellFont = workSheet.Cells["A4:F4"].Style.Font;
                cellFont.Color.SetColor(Color.Red);
                cellFont.Bold = true;

                workSheet.Cells["A5:F5"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A5:F5"].Style.Fill.BackgroundColor.SetColor(Color.Blue);
                workSheet.Cells["A5:F5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A5:F5"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A5:F5"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                workSheet.Cells["A5:F5"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                cellFont = workSheet.Cells["A5:F5"].Style.Font;
                cellFont.Color.SetColor(Color.White);
                cellFont.Bold = true;

                cellFont = workSheet.Cells["G1"].Style.Font;
                cellFont.Color.SetColor(Color.Red);

                for (int k = 1; k <= 4; k++)
                {
                    cellFont = workSheet.Cells["H" + k + ":R" + k].Style.Font;
                    cellFont.Color.SetColor(Color.Red);
                }

                j = 1;
                foreach (var col in cols)
                {
                    workSheet.Cells[i, j].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[i, j].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i, j].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i, j].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i, j].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    workSheet.Cells[i + 1, j].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    if ((col.IsNotNull ?? false))
                    {
                        workSheet.Cells[i + 1, j].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                        cellFont = workSheet.Cells[i + 1, j].Style.Font;
                        cellFont.Color.SetColor(Color.Red);
                    }
                    else
                    {
                        workSheet.Cells[i + 1, j].Style.Fill.BackgroundColor.SetColor(Color.Blue);
                        cellFont = workSheet.Cells[i + 1, j].Style.Font;
                        cellFont.Color.SetColor(Color.White);
                    }

                    workSheet.Cells[i + 1, j].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    workSheet.Cells[i + 1, j].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 1, j].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 1, j].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    workSheet.Cells[i + 1, j].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    j += 1;
                }


                workSheet.Protection.IsProtected = false;
                workSheet.Protection.AllowSelectLockedCells = false;

                var stream = new MemoryStream();

                xlPackage.SaveAs(stream);

                stream.Position = 0;
                byte[] bytesInStream = stream.ToArray();
                stream.Close();

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=template.xlsx");
                Response.BinaryWrite(bytesInStream);
                Response.End();


            }
        }
    }
    protected void TableNameEditor_Init(object sender, EventArgs e)
    {
        var tables = entities.Database.SqlQuery<string>(@"Select DISTINCT TABLE_NAME  FROM [INFORMATION_SCHEMA].[COLUMNS]").ToList();
        ASPxComboBox cbo = sender as ASPxComboBox;
        cbo.DataSource = tables;
        cbo.DataBind();
    }
    protected void FileTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        var list = entities.DecTableValues
            .Where(x => x.Tables == "ETPARAMETERS" && x.Field == "FILE_TYPE")
            .Select(x => new { DefValue = x.DefValue, Description = x.DefValue + "-" + x.Description })
            .ToList();
        s.DataSource = list;
        s.ValueField = "DefValue";
        s.TextField = "Description";
        s.DataBind();
    }
    protected void cboTableName_Callback(object sender, CallbackEventArgsBase e)
    {
        var args = e.Parameter.Split('|');
        if (args[0] == "SAVE")
        {
            var entity = new ETParameter();

            entity.ETCode = ETCodeEditor.Text;
            entity.Name = NameEditor.Text;
            entity.ToTableName = TableNameEditor.Value.ToString();
            entity.FileType = FileTypeEditor.Value.ToString();
            entity.UseVersion = UseVersionEditor.Checked;
            entity.TransferType = TransferTypeEditor.Value.ToString();
            entity.CreateDate = DateTime.Now;
            entity.CreatedBy = (int)SessionUser.UserID;

            entities.ETParameters.Add(entity);
            entities.SaveChangesWithAuditLogs();

            cboTableName_Init(cboTableName, null);
        }
    }
}