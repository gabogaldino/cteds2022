using System;

namespace wpf_catalog.Data;

public class Product
{
    public Guid Id { get; set; }

    public string SKU { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }
}
