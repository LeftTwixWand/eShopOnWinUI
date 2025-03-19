using System;
using System.Collections.Generic;
using eShopOnWinUI.Application.Models;
using Microsoft.UI.Xaml.Controls;

namespace eShopOnWinUI.Presentation.Views.Product;

public sealed partial class ProductView : Page
{
    public ProductView()
    {
        InitializeComponent();
        ViewModel = new SampleOrder()
        {
            OrderID = 10643, // Symbol Globe
            OrderDate = new DateTime(1997, 8, 25),
            RequiredDate = new DateTime(1997, 9, 22),
            ShippedDate = new DateTime(1997, 9, 22),
            ShipperName = "Speedy Express",
            ShipperPhone = "(503) 555-9831",
            Freight = 29.46,
            Company = "Company A",
            ShipTo = "Company A, Obere Str. 57, Berlin, 12209, Germany",
            OrderTotal = 814.50,
            Status = "Shipped",
            SymbolCode = 57643,
            SymbolName = "Globe",
            Details = new List<SampleOrderDetail>()
            {
                new()
                {
                    ProductID = 28,
                    ProductName = "Rössle Sauerkraut",
                    Quantity = 15,
                    Discount = 0.25,
                    QuantityPerUnit = "25 - 825 g cans",
                    UnitPrice = 45.60,
                    CategoryName = "Produce",
                    CategoryDescription = "Dried fruit and bean curd",
                    Total = 513.00,
                },
                new()
                {
                    ProductID = 39,
                    ProductName = "Chartreuse verte",
                    Quantity = 21,
                    Discount = 0.25,
                    QuantityPerUnit = "750 cc per bottle",
                    UnitPrice = 18.0,
                    CategoryName = "Beverages",
                    CategoryDescription = "Soft drinks, coffees, teas, beers, and ales",
                    Total = 283.50,
                },
                new()
                {
                    ProductID = 46,
                    ProductName = "Spegesild",
                    Quantity = 2,
                    Discount = 0.25,
                    QuantityPerUnit = "4 - 450 g glasses",
                    UnitPrice = 12.0,
                    CategoryName = "Seafood",
                    CategoryDescription = "Seaweed and fish",
                    Total = 18.00,
                },
            },
        };
    }

    private SampleOrder ViewModel { get; }
}