<%@ WebHandler Language="C#" Class="CreateTemplate" %>

using System;
using System.Web;
using OfficeOpenXml;
using System.Drawing;
using System.Data.Linq;
using System.Linq;

public class CreateTemplate : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Session.IsNewSession || SessionUser.GetLoginUser() == null)
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("Session expired!"));
                context.Response.End();
                return;
            }

            KTQTData.KTQTDataEntities entities = new KTQTData.KTQTDataEntities();

            var etCode = context.Request["etCode"];
            if (StringUtils.isEmpty(etCode))
                return;

            string fileName = HttpContext.Current.Server.MapPath("~") + @"Templates\ETTemplate.xlsx";

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
                    string len = string.Empty;
                    if ((col.DataLength ?? 0) != 0)
                        len = "(" + col.DataLength + ")";
                    workSheet.Cells[i, j].Value = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
                    workSheet.Cells[i + 1, j].Value = col.ColumnName + len;
                    col.MapingColumn = "ATT" + (j - 1);
                    j += 1;
                }
                entities.SaveChanges();

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

                xlPackage.SaveAs(new System.IO.FileInfo(fileName));

                System.IO.FileInfo file = new System.IO.FileInfo(fileName);

                context.Response.Clear();
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + etCode + ".xlsx");
                context.Response.AddHeader("Content-Length", file.Length.ToString());
                context.Response.ContentType = getContentType(fileName);
                context.Response.WriteFile(fileName);
                context.Response.Flush();
                //context.Response.End();
                context.Response.SuppressContent = true;  
                context.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ex)
        {
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message));
           //context.Response.End();
                context.Response.SuppressContent = true;  
                context.ApplicationInstance.CompleteRequest();
        }
    }

    string getContentType(String path)
    {
        switch (System.IO.Path.GetExtension(path))
        {
            case ".bmp": return "Image/bmp";
            case ".gif": return "Image/gif";
            case ".jpg": return "Image/jpeg";
            case ".png": return "Image/png";
            default: break;
        }
        return "application/octet-stream";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}