﻿namespace BackendSiteVendas.Domain.Entities.Product; 
public class Category : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}