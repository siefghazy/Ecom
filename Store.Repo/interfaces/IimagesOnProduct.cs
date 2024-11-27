using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IimagesOnProduct
    {
        public void addOnImageOnProduct(imagesOnProduct imagesOnProduct);
        public void updateImageOnProduct(int ?imageId);
        public void removeImageOnProduct(int? imageId);
        public void removeProduct(int? productID);
        public ICollection<imagesOnProduct> getProductImages(int? productID);
    }
}
