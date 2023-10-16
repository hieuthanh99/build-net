using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StationeryUnitPrice
/// </summary>
public class StationeryUnitPrice{
    public decimal UnitPriceDetailID { get; set; }
    public int UnitPriceID { get; set; }
    public int StationeryID { get; set; }
    public string Description { get; set; }
    public decimal Quantity { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? Amount { get; set; }
    public DateTime CreateDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public int? LastUpdatedBy { get; set; }
    public string StationeryType { get; set; }
}