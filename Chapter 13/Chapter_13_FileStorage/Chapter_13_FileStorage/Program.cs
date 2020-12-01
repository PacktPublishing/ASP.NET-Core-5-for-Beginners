using System;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Chapter_13_FileStorage
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {            
            File.WriteAllText("foo.txt", "Hello World");
            Console.WriteLine(File.ReadAllText("foo.txt"));

            //Set up the connection and a blob reference
            string connString = "DefaultEndpointsProtocol=https;AccountName=<name>;AccountKey=<key>;EndpointSuffix=core.windows.net";
            BlobServiceClient blobServiceClient = new BlobServiceClient(connString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient("foo");
            BlobClient blobClient = blobContainerClient.GetBlobClient("foo.txt");

            //Upload to Blob Storage
            using FileStream uploadFileStream = File.OpenRead("foo.txt");
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

            //Download from Blob Storage
            BlobDownloadInfo dl = await blobClient.DownloadAsync();
            using (FileStream dlfs = File.OpenWrite("fooBlob.txt"))
            {
                await dl.Content.CopyToAsync(dlfs);
                dlfs.Close();
            }

            Console.WriteLine(File.ReadAllText("fooBlob.txt"));
        }
    }
}
