using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using PioneerOnlineLibrary.Core.Interface;
using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Core.Services
{
    public class ImageService : IImageService
    {
        //private readonly IImageService _imageService;
        private readonly Cloudinary _cloudinary;
        public ImageService(Cloudinary cloudinary)
        {
            //_imageService = imageService;
            _cloudinary = cloudinary;
        }

        public Image Upload(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            var image = new Image
            {
                PublicId = uploadResult.PublicId,
                ImageUrl = uploadResult.SecureUrl.AbsoluteUri

            };

            return image;
        }

        public Image Get(string publicId)
        {
            var image = new Image
            {
                PublicId = publicId,
                ImageUrl = _cloudinary.Api.UrlImgUp.BuildUrl(publicId),

            };
            
            return image;
        }
    }
}
