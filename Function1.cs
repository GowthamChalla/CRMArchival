using System;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;

private const string applicationId = "fdc44122-10e0-41b8-a0f3-e5b06ec9c274";
private const string applicationSecret = "2zNTKm4jcPlaYCjUkBinQK4Me1+NoAVXpoPz6iUip0g=";

public static async Task<List<Microsoft.Azure.KeyVault.Secret>> Run(HttpRequestMessage req, TraceWriter log)
{
    List<Microsoft.Azure.KeyVault.Secret> secrets = new List<Microsoft.Azure.KeyVault.Secret>();
    var keyClient = new KeyVaultClient(async (authority, resource, scope) =>
    {
        var adCredential = new ClientCredential(applicationId, applicationSecret);
        var authenticationContext = new AuthenticationContext(authority, null);
        return (await authenticationContext.AcquireTokenAsync(resource, adCredential)).AccessToken;
    });

    var secretIdentifier1 = "https://obfuscationkeyvault.vault.azure.net/secrets/DataCatalogName";
    var secret1 = await keyClient.GetSecretAsync(secretIdentifier1);
    log.Info($"Key Vault Secret Value secret1 : {secret1}");
    secrets.Add(secret1);

    var secretIdentifier2 = "https://obfuscationkeyvault.vault.azure.net/secrets/DataCatalogClientId";
    var secret2 = await keyClient.GetSecretAsync(secretIdentifier2);
    log.Info($"Key Vault Secret Value secret2 : {secret2}");
    secrets.Add(secret2);

    var  secretIdentifier3 = "https://obfuscationkeyvault.vault.azure.net/secrets/DataCatalogTenantId";
    var secret3 = await keyClient.GetSecretAsync(secretIdentifier3);
    log.Info($"Key Vault Secret Value secret3 : {secret3}");
    secrets.Add(secret3);

    var secretIdentifier4 = "https://obfuscationkeyvault.vault.azure.net/secrets/DataCatalogSecret";
    var secret4 = await keyClient.GetSecretAsync(secretIdentifier4);
    log.Info($"Key Vault Secret Value secret4 : {secret4}");
    secrets.Add(secret4);

    var secretIdentifier5 = "https://obfuscationkeyvault.vault.azure.net/secrets/StorageAccountName";
    var secret5 = await keyClient.GetSecretAsync(secretIdentifier5);
    log.Info($"Key Vault Secret Value secret5 : {secret5}");
    secrets.Add(secret5);

    var  secretIdentifier6 = "https://obfuscationkeyvault.vault.azure.net/secrets/StorageKey";
   var secret6 = await keyClient.GetSecretAsync(secretIdentifier6);
    log.Info($"Key Vault Secret Value secret6 : {secret6}");
    secrets.Add(secret6);

    var  secretIdentifier7 = "https://obfuscationkeyvault.vault.azure.net/secrets/StorageSASToken";
    var secret7 = await keyClient.GetSecretAsync(secretIdentifier7);
    log.Info($"Key Vault Secret Value secret7 : {secret7}");
    secrets.Add(secret7);

    return secrets;

}
