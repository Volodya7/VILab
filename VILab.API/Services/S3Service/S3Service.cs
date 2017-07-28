using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;

namespace VILab.API.Services.S3Service
{
  public class S3Service : IS3Service
  {
    private IAmazonS3 _s3Client;

    private const string BucketName = "volodymyrbabak";
    private const string AmazonS3Url = "https://s3.eu-central-1.amazonaws.com";

    public S3Service(IAmazonS3 s3Client)
    {
      _s3Client = s3Client;
    }

    public string UploadFile(IFormFile file)
    {
      var filename = GetFileName(file);

      TransferUtility fileTransferUtility = new TransferUtility(_s3Client);

      using (MemoryStream ms = new MemoryStream())
      {
        file.CopyTo(ms);
        fileTransferUtility.Upload(ms, BucketName, filename);
      }

      return string.Format("{0}/{1}/{2}",AmazonS3Url, BucketName, filename);

    }

    private void CreateFolder(string bucketName, string folderName)
    {
      var folderKey = folderName + "/"; //end the folder name with "/"

      var request = new PutObjectRequest()
      {
        BucketName = BucketName,
        Key = "Images/",
        ContentBody = String.Empty
      };

      request.StorageClass = S3StorageClass.Standard;
      request.ServerSideEncryptionMethod = ServerSideEncryptionMethod.None;

      var response = _s3Client.PutObjectAsync(request);
    }

    private string GetFileName(IFormFile file)
    {
      return ContentDispositionHeaderValue
          .Parse(file.ContentDisposition)
          .FileName
          .Trim('"');
    }
  }
}
