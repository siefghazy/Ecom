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
    public class ImageRepo : IImages
    {
        private readonly StoreDbContext _context;
        public ImageRepo(StoreDbContext context)
        {
            _context = context;
        }
        public void addImage(image image)
        {
            _context.images.Add(image);
            _context.SaveChanges();
        }

        public IReadOnlyList<image> getAllImages()
        {
           return  _context.images.ToList();
        }

        public image getImageById(int id)
        {
            return _context.images.Find(id);
        }

        public void removeImage(image image)
        {
            _context.Remove(image);
            _context.SaveChanges();
        }

        public void updateImage(image image)
        {
            _context.Update(image);
            _context.SaveChanges();
        }
    }
}
