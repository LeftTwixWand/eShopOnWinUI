using System;
using System.Collections.Generic;

namespace eShopOnWinUI.Application.Models;

public class SampleOrder
{
    public long OrderID { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime ShippedDate { get; set; }

    public string ShipperName { get; set; } = string.Empty;

    public string ShipperPhone { get; set; } = string.Empty;

    public double Freight { get; set; }

    public string Company { get; set; } = string.Empty;

    public string ShipTo { get; set; } = string.Empty;

    public double OrderTotal { get; set; }

    public string Status { get; set; } = string.Empty;

    public int SymbolCode { get; set; }

    public string SymbolName { get; set; } = string.Empty;

    public char Symbol => (char)SymbolCode;

    public ICollection<SampleOrderDetail> Details { get; set; } = new List<SampleOrderDetail>();

    public string ShortDescription => $"Order ID: {OrderID}";

    public override string ToString()
    {
        return $"{Company} {Status}";
    }
}