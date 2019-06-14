using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Net.Http.Headers;
using System.Configuration;

public async static Task Run(Stream myBlob, string name, TraceWriter log)
{
	log.Info($"Analyzing uploaded image {name} - cat or dog?");

	var array = await ToByteArrayAsync(myBlob);
	log.Info("Created byte array");
	var result = await AnalyzeImageAsync(array, log);

	log.Info($"Is {result.predictions[0].tagName}: {result.predictions[0].probability}");
	log.Info($"Is {result.predictions[1].tagName}: {result.predictions[1].probability}");

	if (result.predictions[0].probability > 0.5)
	{
		await StoreBlobWithMetadata(myBlob, result.predictions[0].tagName + "s", name, result, log);
	}
	else if (result.predictions[1].probability > 0.5)
	{
		await StoreBlobWithMetadata(myBlob, result.predictions[1].tagName + "s", name, result, log);
	}
    else 
    {
        log.Info("Cannot classify");
    }
}

private async static Task<ImageAnalysisInfo> AnalyzeImageAsync(byte[] bytes, TraceWriter log)
{
	HttpClient client = new HttpClient();

	var key = Environment.GetEnvironmentVariable("CustomVisionKey");
	client.DefaultRequestHeaders.Add("Prediction-Key", key);
	log.Info("Found key: " + key);

	HttpContent payload = new ByteArrayContent(bytes);
	payload.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/octet-stream");

	var endpoint = Environment.GetEnvironmentVariable("CustomVisionEndpoint");
	log.Info("Posting to: " + endpoint);
	var results = await client.PostAsync(endpoint, payload);
	var result = await results.Content.ReadAsAsync<ImageAnalysisInfo>();
	return result;
}

// Writes a blob to a specified container and stores metadata with it
private async static Task StoreBlobWithMetadata(Stream image, string containerName, string blobName, ImageAnalysisInfo info, TraceWriter log)
{
	log.Info($"Writing blob and metadata to {containerName} container...");

	var connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage").ToString();
	var account = CloudStorageAccount.Parse(connection);
	var client = account.CreateCloudBlobClient();
	var container = client.GetContainerReference(containerName);

	try
	{
		var blob = container.GetBlockBlobReference(blobName);

		if (blob != null)
		{
			// Upload the blob
			await blob.UploadFromStreamAsync(image);
		}
	}
	catch (Exception ex)
	{
		log.Info(ex.Message);
	}
}

// Converts a stream to a byte array
private async static Task<byte[]> ToByteArrayAsync(Stream stream)
{
	Int32 length = stream.Length > Int32.MaxValue ? Int32.MaxValue : Convert.ToInt32(stream.Length);
	byte[] buffer = new Byte[length];
	await stream.ReadAsync(buffer, 0, length);
	stream.Position = 0;
	return buffer;
}

public class Prediction
{
    public double probability { get; set; }
    public string tagId { get; set; }
    public string tagName { get; set; }
}

public class ImageAnalysisInfo
{
    public string id { get; set; }
    public string project { get; set; }
    public string iteration { get; set; }
    public DateTime created { get; set; }
    public List<Prediction> predictions { get; set; }
}