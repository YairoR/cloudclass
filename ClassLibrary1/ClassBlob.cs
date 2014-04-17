using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobsManager
{
    public class ClassBlob
    {
        CloudBlobClient blobClient;

        public ClassBlob()
        {
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey("cloudclassstorage", "cNedBFVd5SE2h4xsesVNraAN08itjeUjddZn7yoB8rYVj5rYAS8j+9cGV37rtk2N92nknjiwx9EgkKf8O8u9Zw=="), true);
            blobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public void uploadToBlob(string courseId,string fileName,FileStream fileStream)
        {
           // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference(courseId);

            // Create the container if it doesn't already exist.
            container.CreateIfNotExist();

           // retrieve reference to the blob
           CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
           blob.UploadFromStream(fileStream);

        }

        public string getBlobUri(string courseId,string blobName)
        {
            CloudBlobContainer courseContainer = blobClient.GetContainerReference(courseId);

            // Retrieve reference to a blob named in our container
            CloudBlockBlob blockBlob = courseContainer.GetBlockBlobReference(blobName);

           return blockBlob.Uri.AbsoluteUri.ToString();
        }

        }
    }

