using Store.Data.Models;
using Store.Repo.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.middlewares
{
    public class ImageUploadMiddleware
    {

        public static image imageUpload(string imagePath, IImages _image)
        {
            image imageToUpload = new image()
            {
                path = imagePath
            };
            _image.addImage(imageToUpload);
            return imageToUpload;
        }
        public static void deleteImageDuringRemoveBrand(prodBrand brand,IImages _image)
        {
            _image.removeImage((int)brand.imageId);
        }
    }
}
