using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.S3;
using Amazon.S3.Model;

namespace PhotoStorageS3
{
    public class S3Uploader
    {
        private string bucketName = "photostorageassignment";
        private string keyName = "testTalentsPhotoUpload";
        private string filePath = "C:\\Users\\DKroz\\Desktop\\School\\CSC\\Talents photo\\Barot_Bellingham_tn.jpg";

        public void UploadFile()
        {
            var client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

            try
            {
                PutObjectRequest putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName,
                    FilePath = filePath,
                    ContentType = "text/plain"
                };

                PutObjectResponse response = client.PutObject(putRequest);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                    ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
    }
}