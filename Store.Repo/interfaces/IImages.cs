using Store.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repo.interfaces
{
    public interface IImages
    {
        public void addImage(image image);
        public image getImageById(int ?id);
        public IReadOnlyList<image> getAllImages();
        public void removeImage(int ?id);
        public void updateImage(image image);
        public ICollection<image> getImageForProduct(int? productID);
    }
}
