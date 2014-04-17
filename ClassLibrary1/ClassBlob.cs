using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchestration;


namespace BlobsManager
{
    public class ClassBlob
    {
        CloudBlobClient blobClient;
        private static readonly char specialChar = '_';
        private static readonly char extensionChar = '.';

        public ClassBlob()
        {
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey("cloudclassstorage", "cNedBFVd5SE2h4xsesVNraAN08itjeUjddZn7yoB8rYVj5rYAS8j+9cGV37rtk2N92nknjiwx9EgkKf8O8u9Zw=="), true);
            blobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public void uploadToBlob(Guid courseId, string fileName,string owner, FileStream fileStream)
        {
            // Retrieve a reference to a container. 
            CloudBlobContainer container = blobClient.GetContainerReference(courseId.ToString());

            // Create the container if it doesn't already exist.
            if (container.CreateIfNotExist())
            {
                BlobContainerPermissions containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(containerPermissions);
            }

            // retrieve reference to the blob
            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);
            
            // create name of blob 
            string blobName = fileName + specialChar + owner;
            blob.UploadFromStream(fileStream);
        }

        public List<BlobFileresult> getAllBlobsUnderCourse(Guid courseId)
        {
            List<BlobFileresult> blobUris = new List<BlobFileresult>();
            CloudBlobContainer container = blobClient.GetContainerReference(courseId.ToString());
            if (container.CreateIfNotExist())
            {
                BlobContainerPermissions containerPermissions = new BlobContainerPermissions();
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                container.SetPermissions(containerPermissions);
            }

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs())
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    int lastIndexOfSpecialChar = blob.Name.LastIndexOf(specialChar);
                    int lastIndexOfExtensionChar = blob.Name.LastIndexOf(extensionChar);

                    string blobNameWithoutOwner = blob.Name.Substring(0,lastIndexOfSpecialChar);
                    string ownerName = blob.Name.Substring(lastIndexOfSpecialChar + 1, lastIndexOfExtensionChar - lastIndexOfSpecialChar - 1);

                    blobUris.Add(new BlobFileresult(blobNameWithoutOwner, blob.Uri, ownerName, blob.Properties.LastModifiedUtc));
                }

            }
            return blobUris;
        }
    }
}

