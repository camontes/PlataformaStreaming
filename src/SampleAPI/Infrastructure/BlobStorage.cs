using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Infrastructure
{
    public static class BlobStorage
    {
        public static async Task<string> UploadImage(IFormFile photo)
        {
            if (photo is null || photo.Length <= 0)
            {
                return string.Empty;
            }

            //Create Uniq file name
            var uniqFileName = Guid.NewGuid().ToString();
            var filename = Path.GetFileName(uniqFileName + "." + photo.FileName.Split(".")[1].ToLower());

            var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=streamedublob;AccountKey=6M99opS17xhV/QDoyW4ZOChyDimCqV7HwYYryXUlQ2ETyZdupqJxdWhLDXn+xw6Wd8N1sp2xsrMmU7R8HDqW/w==;EndpointSuffix=core.windows.net");
            var blobClient = blobServiceClient.GetBlobContainerClient("images");
            var blob = blobClient.GetBlobClient(filename);
            var blobHttpHeader = new BlobHttpHeaders
            {
                ContentType = "image/jpg"
            };
            using (var fileStream = photo.OpenReadStream())
            {
                var result = await blob.UploadAsync(fileStream, blobHttpHeader);
                return $"https://streamedublob.blob.core.windows.net/images/{filename}";
            }
        }
    }
}
