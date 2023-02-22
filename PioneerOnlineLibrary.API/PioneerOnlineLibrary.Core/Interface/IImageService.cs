using Microsoft.AspNetCore.Http;
using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Core.Interface
{
    public interface IImageService
    {
        Image Upload(IFormFile file);

        Image Get(string publicId);
    }
}
