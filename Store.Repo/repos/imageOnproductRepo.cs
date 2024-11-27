using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.repos
{
    public class imageOnproductRepo : IimagesOnProduct
    {
        private readonly StoreDbContext _context;
        public imageOnproductRepo(StoreDbContext context)
        {
            _context = context;
        }

        public void addOnImageOnProduct(imagesOnProduct imagesOnProduct)
        {
            _context.imagesOnProducts.Add(imagesOnProduct);
            _context.SaveChanges();
        }

        public ICollection<imagesOnProduct> getProductImages(int? productID)
        {
            return _context.imagesOnProducts.Where(x => x.productID == productID).ToList();
        }

        public void removeImageOnProduct(int? imageId)
        {
           var image= _context.imagesOnProducts.FirstOrDefault(x=>x.ImageID==imageId);
            _context.imagesOnProducts.Remove(image);
            _context.SaveChanges();
        }

        public void updateImageOnProduct(int? imageId)
        {
            throw new NotImplementedException();
        }

        public void removeProduct(int? productID)
        {
            var product = _context.imagesOnProducts.Where(x=>x.productID==productID);
            _context.imagesOnProducts.RemoveRange(product);
            _context.SaveChanges();
        }
    }
}
