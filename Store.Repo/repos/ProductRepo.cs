using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Store.Repo.repos
{
    public class ProductRepo : IProduct
    {
        private readonly StoreDbContext _Context;
        public ProductRepo(StoreDbContext context)
        {
            _Context = context;
        }

        public void addProduct(product product)
        {
             _Context.Products.Add(product);
             _Context.SaveChanges();
        }

        public IReadOnlyList<product> getAllProducts()
        {
            
            return _Context.Products.Include(x=>x.prodBrand).Include(x => x.productImages).ThenInclude(productImages=>productImages.image).Include(x => x.prodType).ToList();

        }

        public product getPrdouctById(int id)
        {
            return  _Context.Products.Include(x=>x.prodBrand).Include(x=>x.productImages).ThenInclude(productimages=>productimages.image).Include(x => x.prodType).FirstOrDefault(x => x.ID == id);
        }

        public void updateProduct(product product)
        {
            _Context.Products.Update(product);
             _Context.SaveChanges();
        }

        public product addProductGet(product product)
        {
            product productToBeUploaded = new product()
            {
                description = product.description,
                price = product.price,
                brandID = product.brandID,
                typID = product.typID,
                CreatedAt = product.CreatedAt,
                Name = product.Name,
            };
            _Context.Products.Add(productToBeUploaded);
            _Context.SaveChanges();
            return productToBeUploaded;
        }

        public void  removeProduct(product product)
        {
            _Context.Products.Remove(product);
            _Context.SaveChanges();
        }
    }
}
