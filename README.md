# Simple AWS KMS Encryptor

## Description

This is a simple AWS KMS encryptor that can be used to encrypt and decrypt data using AWS KMS.

## Usage

### Prepare the environment

AWS `credentials` and `config` files should be present in the `~/.aws` directory. The `credentials` file should have the following format:

```sh
[default]
aws_access_key_id = YOUR_ACCESS_KEY
aws_secret_access_key = YOUR_SECRET
```

The `config` file should have the following format:

```sh
[default]
region = YOUR_REGION
```

### Run the script

```sh
dotnet run
```

Input KMS key ID, plaintext data accordingly. Multiplie lines data is supported.
