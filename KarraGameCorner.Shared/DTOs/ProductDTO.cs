using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using KarraGameCorner.DataAccess.Enums;

namespace KarraGameCorner.Shared.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; }
    public List<ProductCategoryDTO> Categories { get; set; }
    public EntertainmentSoftwareRatingBoard ESRB { get; set; }
    public string Picture { get; set; }
    public int Quantity { get; set; }
    public bool Status { get; set; }

    public string GetBlobSasUrl()
    {
        try
        {
            string connectionString = Environment.GetEnvironmentVariable("StorageContainerConnectionString");
            string containerName = Environment.GetEnvironmentVariable("ContainerName");

            var blobServiceClient = new BlobServiceClient(connectionString);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(Picture);

            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = Picture,
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1) // SAS token expiration time
            };
            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            var sasToken = blobClient.GenerateSasUri(sasBuilder).Query;

            return $"{blobClient.Uri}{sasToken}";
        }
        catch (Exception e)
        {
            return string.Empty;
        }

    }
}