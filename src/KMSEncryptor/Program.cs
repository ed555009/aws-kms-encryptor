using System.Text;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

Console.WriteLine("Enter KMS Key ID: ");

var keyId = Console.ReadLine();

Console.WriteLine("Enter Data to encrypt: ");

List<string> lines = [];
string? input;

while (true)
{
	input = Console.ReadLine();

	if (string.IsNullOrWhiteSpace(input))
		break;

	lines.Add(input);
}

string data = string.Join("\n", lines);

try
{
	using var client = new AmazonKeyManagementServiceClient();
	var result = await client.EncryptAsync(new EncryptRequest
	{
		KeyId = keyId,
		Plaintext = new MemoryStream(Encoding.UTF8.GetBytes(data)),
		EncryptionAlgorithm = EncryptionAlgorithmSpec.SYMMETRIC_DEFAULT
	});

	if (result == null)
	{
		Console.WriteLine("Failed to encrypt data");
		Environment.Exit(1);
	}

	Console.WriteLine("Encrypted Data:");
	Console.WriteLine(Convert.ToBase64String(result.CiphertextBlob.ToArray()));
}
catch (Exception ex)
{
	Console.WriteLine($"Failed to encrypt data: {ex.Message}");
}
finally
{
	Environment.Exit(0);
}
