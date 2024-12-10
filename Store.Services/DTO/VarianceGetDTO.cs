using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.DTO
{
    public class VarianceGetDTO
    {
        //product
        public int productId {  get; set; }
        public string productName{ get; set; }
        public List<dynamic> productImages{ get; set; }
        public string productDescribtion { get; set; }
        //type
        public int? productTypeId { get; set; }
        public string? productTypeName { get; set; }
        //brand
        public int? productBrandId { get; set; }
        public string? productBrandName { get; set; }
        public int? productBrandImageId { get; set; }
        public string? productBrandImage { get; set; }
        //variances
        public List<object> variances {  get; set; }


    }
}
