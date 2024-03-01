// Autoglass.Application/DTOs/ProductDTO.cs
using System;

namespace Autoglass.Application.Dto
{
    public class ProductDTO
    {
        public string Description { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCNPJ { get; set; }
    }
}
