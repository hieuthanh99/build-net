<%@ WebHandler Language="C#" Class="CreateRevCostTemplate" %>

using System;
using System.Web;
using OfficeOpenXml;
using System.Drawing;
using System.Data.Linq;
using System.Linq;
using DevExpress.Data.Filtering;

public class CreateRevCostTemplate : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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
            int aPlanVersionID, aVersionID, aPlanMonth;

            var etCode = context.Request["etCode"];
            if (StringUtils.isEmpty(etCode))
                return;

            var OriArea = context.Request["area"];
            if (StringUtils.isEmpty(OriArea))
                return;

            // Version
            var versionID = context.Request["versionID"];
            aVersionID = int.Parse(versionID);
            if (aVersionID == 0)
                return;

            //Plan Version
            var PlanVersionID = context.Request["PlanVersionID"];
            aPlanVersionID = int.Parse(PlanVersionID);

            // Month
            var PlanMonth = context.Request["PlanMonth"];
            aPlanMonth = int.Parse(PlanMonth);

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

                i = 9;
                #region 
                /* if (area=="HAN")
                {
                    if (aPlanVersionID == 0 && aVersionID > 0 && aPlanMonth > 0)
                    {
                        // Neu chon Version dau tien va thang thi chi xuat du lieu 
                        var vstores = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();
                        // Export cho tung don vi
                        foreach (var astore in vstores)
                        {
                            workSheet.Cells[i, 1].Value = astore.CompanyID;
                            workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                            workSheet.Cells[i, 2].AutoFitColumns();
                            workSheet.Cells[i, 3].Value = astore.SubaccountID;
                            workSheet.Cells[i, 4].Value = astore.Description;
                            workSheet.Cells[i, 4].AutoFitColumns();
                            workSheet.Cells[i, 5].Value = astore.Sorting;
                            workSheet.Cells[i, 6].Value = astore.Calculation;
                            workSheet.Cells[i, 6].AutoFitColumns();

                            for (int k = 1; k <= aPlanMonth; k++)
                            {
                                if (k == 1)
                                {
                                    workSheet.Cells[i, 7].Value = astore.M01;
                                    workSheet.Cells[i, 7].AutoFitColumns();
                                }
                                else if (k == 2)
                                {
                                    workSheet.Cells[i, 8].Value = astore.M02;
                                    workSheet.Cells[i, 8].AutoFitColumns();
                                }
                                else if (k == 3)
                                {
                                    workSheet.Cells[i, 9].Value = astore.M03;
                                    workSheet.Cells[i, 9].AutoFitColumns();
                                }
                                else if (k == 4)
                                {
                                    workSheet.Cells[i, 10].Value = astore.M04;
                                    workSheet.Cells[i, 10].AutoFitColumns();
                                }
                                else if (k == 5)
                                {
                                    workSheet.Cells[i, 11].Value = astore.M05;
                                    workSheet.Cells[i, 11].AutoFitColumns();
                                }
                                else if (k == 6)
                                {
                                    workSheet.Cells[i, 12].Value = astore.M06;
                                    workSheet.Cells[i, 12].AutoFitColumns();
                                }
                                else if (k == 7)
                                {
                                    workSheet.Cells[i, 13].Value = astore.M07;
                                    workSheet.Cells[i, 13].AutoFitColumns();
                                }
                                else if (k == 8)
                                {
                                    workSheet.Cells[i, 14].Value = astore.M08;
                                    workSheet.Cells[i, 14].AutoFitColumns();
                                }
                                else if (k == 9)
                                {
                                    workSheet.Cells[i, 15].Value = astore.M09;
                                    workSheet.Cells[i, 15].AutoFitColumns();
                                }
                                else if (k == 10)
                                {
                                    workSheet.Cells[i, 16].Value = astore.M10;
                                    workSheet.Cells[i, 16].AutoFitColumns();
                                }
                                else if (k == 11)
                                {
                                    workSheet.Cells[i, 17].Value = astore.M11;
                                    workSheet.Cells[i, 17].AutoFitColumns();
                                }
                                else if (k == 12)
                                {
                                    workSheet.Cells[i, 18].Value = astore.M12;
                                    workSheet.Cells[i, 18].AutoFitColumns();
                                }

                            }
                            i += 1;
                        }

                    }
                    else if (aPlanVersionID > 0 && aVersionID > 0 && aPlanMonth > 0)
                    {// Lay du lieu ca 2 version
                        if (aPlanMonth == 1)
                        {
                            // chon Uoc thang 1  thi lay Plan 12 thang ( theo Verbase)
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();
                            // Export cho tung don vi
                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 12; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = astore.M07;
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = astore.M08;
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = astore.M09;
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = astore.M10;
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = astore.M11;
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = astore.M12;
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 2 || aPlanMonth == 3)
                        {
                            //Khi thực hiện ước tháng 2+3: Chọn số liệu lũy kế đến tháng báo cáo như file đính kèm
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k < aPlanMonth; k++)
                                {
                                    var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                    var vstoreActuals = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();

                                    if (k == 1)
                                    {
                                        if (aTempMaser.TempType == "A")
                                        {
                                            workSheet.Cells[i, 7].Value = vstoreActuals.M01;
                                            workSheet.Cells[i, 7].AutoFitColumns();
                                        }
                                        else
                                        {
                                            workSheet.Cells[i, 7].Value = astore.M01;
                                            workSheet.Cells[i, 7].AutoFitColumns();
                                        }

                                    }
                                    else if (k == 2)
                                    {
                                        if (aTempMaser.TempType == "A")
                                        {
                                            workSheet.Cells[i, 8].Value = vstoreActuals.M02;
                                            workSheet.Cells[i, 8].AutoFitColumns();
                                        }
                                        else
                                        {
                                            workSheet.Cells[i, 8].Value = astore.M02;
                                            workSheet.Cells[i, 8].AutoFitColumns();
                                        }
                                    }
                                }
                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = aPlanMonth; k <= 12; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = vstorePlans.M01; // entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = vstorePlans.M02;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = vstorePlans.M03; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = vstorePlans.M04;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = vstorePlans.M05;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = vstorePlans.M06;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = vstorePlans.M07;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 4)
                        {
                            // Lay Q1 la so thuc hien, 9 thang con lai la Planning
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstoreActuals = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();

                            foreach (var astore in vstoreActuals)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 3; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }

                                }
                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 4; k <= 12; k++)
                                {
                                    if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = vstorePlans.M04;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = vstorePlans.M05;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = vstorePlans.M06;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = vstorePlans.M07;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 5)
                        {
                            //Khi thực hiện ước tháng 5: Chọn số liệu Quý 1 là actual, tháng 4 như file đính kèm, 8 tháng còn lại là planning
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstoreActuals = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();

                            foreach (var astore in vstoreActuals)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 3; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                }
                                // Thang 4 theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 10].Value = astore.M04;
                                    workSheet.Cells[i, 10].AutoFitColumns();
                                }
                                else
                                {
                                    workSheet.Cells[i, 10].Value = vstoreEstimates.M04;
                                    workSheet.Cells[i, 10].AutoFitColumns();
                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 5; k <= 12; k++)
                                {
                                    if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = vstorePlans.M05;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = vstorePlans.M06;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = vstorePlans.M07;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 6)
                        {
                            //Khi thực hiện ước Tháng 6:Chọn số liệu Quý 1 là actual, tháng 4+5 như file đính kèm, 7 tháng còn lại là planning 
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();
                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 3; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                }
                                // Thang 4 +5  theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 10].Value = astore.M04;
                                    workSheet.Cells[i, 10].AutoFitColumns();
                                    workSheet.Cells[i, 11].Value = astore.M05;
                                    workSheet.Cells[i, 11].AutoFitColumns();
                                }
                                else
                                {
                                    workSheet.Cells[i, 10].Value = vstoreEstimates.M04;
                                    workSheet.Cells[i, 10].AutoFitColumns();
                                    workSheet.Cells[i, 11].Value = vstoreEstimates.M05;
                                    workSheet.Cells[i, 11].AutoFitColumns();
                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 6; k <= 12; k++)
                                {
                                    if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = vstorePlans.M06;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = vstorePlans.M07;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 7)
                        {
                            //Khi thực hiện ước tháng 7: Chọn số liệu Quý 1+2 là actual, 6 tháng còn lại là Planning
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();


                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 6; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 7; k <= 12; k++)
                                {
                                    if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = vstorePlans.M07;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 8)
                        {
                            //Ước tháng 8+9+11+12 tương tự tháng 4+5
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();

                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 6; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                }
                                // Thang 7  theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 13].Value = astore.M07;
                                    workSheet.Cells[i, 13].AutoFitColumns();

                                }
                                else
                                {
                                    workSheet.Cells[i, 13].Value = vstoreEstimates.M07;
                                    workSheet.Cells[i, 13].AutoFitColumns();

                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 8; k <= 12; k++)
                                {
                                    if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = vstorePlans.M08;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 9)
                        {
                            //Ước tháng 8+9+11+12 tương tự tháng 4+5
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();

                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 6; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                }
                                // Thang 7 +8  theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 13].Value = astore.M07;
                                    workSheet.Cells[i, 13].AutoFitColumns();
                                    workSheet.Cells[i, 14].Value = astore.M08;
                                    workSheet.Cells[i, 14].AutoFitColumns();
                                }
                                else
                                {
                                    workSheet.Cells[i, 13].Value = vstoreEstimates.M07;
                                    workSheet.Cells[i, 13].AutoFitColumns();
                                    workSheet.Cells[i, 14].Value = vstoreEstimates.M08;
                                    workSheet.Cells[i, 14].AutoFitColumns();
                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 9; k <= 12; k++)
                                {

                                    if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = vstorePlans.M09;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }
                                    else if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 10)
                        {
                            //Ước tháng 8+9+11+12 tương tự tháng 4+5

                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();
                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();
                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 9; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = astore.M07;
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = astore.M08;
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = astore.M09;
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }

                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 10; k <= 12; k++)
                                {
                                    if (k == 10)
                                    {
                                        workSheet.Cells[i, 16].Value = vstorePlans.M10;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 16].AutoFitColumns();
                                    }
                                    else if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 11)
                        {
                            //Ước tháng 8+9+11+12 tương tự tháng 4+5

                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();

                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();


                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 9; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = astore.M07;
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = astore.M08;
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = astore.M09;
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }

                                }
                                // Thang 10  theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 16].Value = astore.M10;
                                    workSheet.Cells[i, 16].AutoFitColumns();

                                }
                                else
                                {
                                    workSheet.Cells[i, 16].Value = vstoreEstimates.M10;
                                    workSheet.Cells[i, 16].AutoFitColumns();

                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 11; k <= 12; k++)
                                {
                                    if (k == 11)
                                    {
                                        workSheet.Cells[i, 17].Value = vstorePlans.M11;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 17].AutoFitColumns();
                                    }
                                    else if (k == 12)
                                    {
                                        workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                        workSheet.Cells[i, 18].AutoFitColumns();
                                    }

                                }
                                i += 1;
                            }
                        }
                        else if (aPlanMonth == 12)
                        {
                            decimal aversionActual = entities.Database.SqlQuery<decimal>("select dbo.FnVersionActual({0}) As MyResult", aVersionID).First();

                            var vstores = entities.V_STORE.Where(x => x.VersionID == aversionActual && x.OriArea == area).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();


                            foreach (var astore in vstores)
                            {
                                workSheet.Cells[i, 1].Value = astore.CompanyID;
                                workSheet.Cells[i, 2].Value = astore.OriArea + "-" + astore.NameV;
                                workSheet.Cells[i, 2].AutoFitColumns();
                                workSheet.Cells[i, 3].Value = astore.SubaccountID;
                                workSheet.Cells[i, 4].Value = astore.Description;
                                workSheet.Cells[i, 4].AutoFitColumns();
                                workSheet.Cells[i, 5].Value = astore.Sorting;
                                workSheet.Cells[i, 6].Value = astore.Calculation;
                                workSheet.Cells[i, 6].AutoFitColumns();
                                for (int k = 1; k <= 9; k++)
                                {
                                    if (k == 1)
                                    {
                                        workSheet.Cells[i, 7].Value = astore.M01;
                                        workSheet.Cells[i, 7].AutoFitColumns();
                                    }
                                    else if (k == 2)
                                    {
                                        workSheet.Cells[i, 8].Value = astore.M02;
                                        workSheet.Cells[i, 8].AutoFitColumns();
                                    }
                                    else if (k == 3)
                                    {
                                        workSheet.Cells[i, 9].Value = astore.M03;
                                        workSheet.Cells[i, 9].AutoFitColumns();
                                    }
                                    else if (k == 4)
                                    {
                                        workSheet.Cells[i, 10].Value = astore.M04;
                                        workSheet.Cells[i, 10].AutoFitColumns();
                                    }
                                    else if (k == 5)
                                    {
                                        workSheet.Cells[i, 11].Value = astore.M05;
                                        workSheet.Cells[i, 11].AutoFitColumns();
                                    }
                                    else if (k == 6)
                                    {
                                        workSheet.Cells[i, 12].Value = astore.M06;
                                        workSheet.Cells[i, 12].AutoFitColumns();
                                    }
                                    else if (k == 7)
                                    {
                                        workSheet.Cells[i, 13].Value = astore.M07;
                                        workSheet.Cells[i, 13].AutoFitColumns();
                                    }
                                    else if (k == 8)
                                    {
                                        workSheet.Cells[i, 14].Value = astore.M08;
                                        workSheet.Cells[i, 14].AutoFitColumns();
                                    }
                                    else if (k == 9)
                                    {
                                        workSheet.Cells[i, 15].Value = astore.M09;
                                        workSheet.Cells[i, 15].AutoFitColumns();
                                    }


                                }
                                // Thang 10 + 11  theo file 
                                var aTempMaser = entities.TempFileMasterOptions.Where(t => t.SubaccountID == astore.SubaccountID).SingleOrDefault();
                                var vstoreEstimates = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                if (aTempMaser.TempType == "A")
                                {
                                    workSheet.Cells[i, 16].Value = astore.M10;
                                    workSheet.Cells[i, 16].AutoFitColumns();
                                    workSheet.Cells[i, 17].Value = astore.M11;
                                    workSheet.Cells[i, 17].AutoFitColumns();
                                }
                                else
                                {
                                    workSheet.Cells[i, 16].Value = vstoreEstimates.M10;
                                    workSheet.Cells[i, 16].AutoFitColumns();
                                    workSheet.Cells[i, 17].Value = vstoreEstimates.M11;
                                    workSheet.Cells[i, 17].AutoFitColumns();
                                }

                                // Gia tri Plan
                                var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                                for (int k = 12; k <= 12; k++)
                                {
                                    workSheet.Cells[i, 18].Value = vstorePlans.M12;//entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                                    workSheet.Cells[i, 18].AutoFitColumns();
                                }
                                i += 1;
                            }
                        }
                    }
                }
                else
                {*/
                #endregion

                // khong phai HAN
                //var vstores = entities.V_STORE.Where(x => x.VersionID == aVersionID && x.OriArea == OriArea).OrderBy(x => x.CompanyID).ThenBy(x => x.Seq).ToList();

                //foreach (var astore in vstores)
                //{
                //    workSheet.Cells[i, 1].Value = astore.AccountGroup;
                //    workSheet.Cells[i, 2].Value = astore.CompanyID;
                //    workSheet.Cells[i, 2].AutoFitColumns();

                //    workSheet.Cells[i, 3].Value = astore.OriArea + "-" + astore.NameV;
                //    workSheet.Cells[i, 4].Value = astore.SubaccountID;
                //    workSheet.Cells[i, 4].AutoFitColumns();

                //    workSheet.Cells[i, 5].Value = astore.Description;
                //    workSheet.Cells[i, 6].Value = astore.Sorting;
                //    workSheet.Cells[i, 6].AutoFitColumns();

                //    workSheet.Cells[i, 7].Value = astore.Calculation;
                //    workSheet.Cells[i, 7].AutoFitColumns();


                //    for (int k = 1; k <= aPlanMonth; k++)
                //    {
                //        if (k == 1)
                //        {
                //            workSheet.Cells[i, 8].Value = astore.M01;
                //            workSheet.Cells[i, 8].AutoFitColumns();
                //        }
                //        else if (k == 2)
                //        {
                //            workSheet.Cells[i, 9].Value = astore.M02;
                //            workSheet.Cells[i, 9].AutoFitColumns();
                //        }
                //        else if (k == 3)
                //        {
                //            workSheet.Cells[i, 10].Value = astore.M03;
                //            workSheet.Cells[i, 10].AutoFitColumns();
                //        }
                //        else if (k == 4)
                //        {
                //            workSheet.Cells[i, 11].Value = astore.M04;
                //            workSheet.Cells[i, 11].AutoFitColumns();
                //        }
                //        else if (k == 5)
                //        {
                //            workSheet.Cells[i, 12].Value = astore.M05;
                //            workSheet.Cells[i, 12].AutoFitColumns();
                //        }
                //        else if (k == 6)
                //        {
                //            workSheet.Cells[i, 13].Value = astore.M06;
                //            workSheet.Cells[i, 13].AutoFitColumns();
                //        }
                //        else if (k == 7)
                //        {
                //            workSheet.Cells[i, 14].Value = astore.M07;
                //            workSheet.Cells[i, 14].AutoFitColumns();
                //        }
                //        else if (k == 8)
                //        {
                //            workSheet.Cells[i, 15].Value = astore.M08;
                //            workSheet.Cells[i, 15].AutoFitColumns();
                //        }
                //        else if (k == 9)
                //        {
                //            workSheet.Cells[i, 16].Value = astore.M09;
                //            workSheet.Cells[i, 16].AutoFitColumns();
                //        }
                //        else if (k == 10)
                //        {
                //            workSheet.Cells[i, 17].Value = astore.M10;
                //            workSheet.Cells[i, 17].AutoFitColumns();
                //        }
                //        else if (k == 11)
                //        {
                //            workSheet.Cells[i, 18].Value = astore.M11;
                //            workSheet.Cells[i, 18].AutoFitColumns();
                //        }
                //        else if (k == 12)
                //        {
                //            workSheet.Cells[i, 19].Value = astore.M12;
                //            workSheet.Cells[i, 19].AutoFitColumns();
                //        }

                //    }

                //    if (astore.Calculation.ToString() == "SUM")
                //    {
                //        cellFont = workSheet.Cells[i, 19].Style.Font;
                //        cellFont.Bold = true;
                //    }

                //    // Gia tri Plan
                //    /*var vstorePlans = entities.V_STORE.Where(x => x.VersionID == aPlanVersionID && x.OriArea == area && x.SubaccountID == astore.SubaccountID && x.CompanyID == astore.CompanyID).SingleOrDefault();
                //    for (int k = aPlanMonth+1; k <= 12; k++)
                //    {
                //        if (k == 1)
                //        {
                //            workSheet.Cells[i, 7].Value = vstorePlans.M01; // entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 7].AutoFitColumns();
                //        }
                //        else if (k == 2)
                //        {
                //            workSheet.Cells[i, 8].Value = vstorePlans.M02;//= entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 8].AutoFitColumns();
                //        }
                //        else if (k == 3)
                //        {
                //            workSheet.Cells[i, 9].Value = vstorePlans.M03;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 9].AutoFitColumns();
                //        }
                //        else if (k == 4)
                //        {
                //            workSheet.Cells[i, 10].Value = vstorePlans.M04; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 10].AutoFitColumns();
                //        }
                //        else if (k == 5)
                //        {
                //            workSheet.Cells[i, 11].Value = vstorePlans.M05; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 11].AutoFitColumns();
                //        }
                //        else if (k == 6)
                //        {
                //            workSheet.Cells[i, 12].Value = vstorePlans.M06;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 12].AutoFitColumns();
                //        }
                //        else if (k == 7)
                //        {
                //            workSheet.Cells[i, 13].Value = vstorePlans.M07; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 13].AutoFitColumns();
                //        }
                //        else if (k == 8)
                //        {
                //            workSheet.Cells[i, 14].Value = vstorePlans.M08; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 14].AutoFitColumns();
                //        }
                //        else if (k == 9)
                //        {
                //            workSheet.Cells[i, 15].Value = vstorePlans.M09; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 15].AutoFitColumns();
                //        }
                //        else if (k == 10)
                //        {
                //            workSheet.Cells[i, 16].Value = vstorePlans.M10; //entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 16].AutoFitColumns();
                //        }
                //        else if (k == 11)
                //        {
                //            workSheet.Cells[i, 17].Value = vstorePlans.M11;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 17].AutoFitColumns();
                //        }
                //        else if (k == 12)
                //        {
                //            workSheet.Cells[i, 18].Value = vstorePlans.M12;// entities.Database.SqlQuery<decimal>("select dbo.GetStoreAmount({0},{1},{2},{3}) As MyResult", aPlanVersionID, astore.SubaccountID, astore.CompanyID, k).First();
                //            workSheet.Cells[i, 18].AutoFitColumns();
                //        }

                //    }*/
                //    i += 1;
                //}
                // }



                allCells = workSheet.Cells[9, 1, workSheet.Dimension.End.Row, workSheet.Dimension.End.Column];
                cellFont = allCells.Style.Font;
                cellFont.SetFromFont(new Font("Times New Roman", 12));

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