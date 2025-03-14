using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityModel;

namespace PaymentManagement;

public class ClientDemoService : ITransientDependency
{
    private readonly IIdentityModelAuthenticationService _authenticationService;
    private readonly IConfiguration _configuration;

    public ClientDemoService(
        IIdentityModelAuthenticationService authenticationService,
        IConfiguration configuration)
    {
        _authenticationService = authenticationService;
        _configuration = configuration;
    }

    public async Task RunAsync()
    {
        await TestWithDynamicProxiesAsync();
        await TestWithHttpClientAndIdentityModelAuthenticationServiceAsync();
        await TestAllManuallyAsync();
    }

    private async Task TestWithDynamicProxiesAsync()
    {
        await Task.CompletedTask;
        Console.WriteLine();
        Console.WriteLine($"***** {nameof(TestWithDynamicProxiesAsync)} *****");

    }

    private async Task TestWithHttpClientAndIdentityModelAuthenticationServiceAsync()
    {
        Console.WriteLine();
        Console.WriteLine($"***** {nameof(TestWithHttpClientAndIdentityModelAuthenticationServiceAsync)} *****");

        var accessToken = await _authenticationService.GetAccessTokenAsync(
            new IdentityClientConfiguration(
                _configuration["IdentityClients:Default:Authority"],
                _configuration["IdentityClients:Default:Scope"],
                _configuration["IdentityClients:Default:ClientId"],
                _configuration["IdentityClients:Default:ClientSecret"],
                _configuration["IdentityClients:Default:GrantType"],
                _configuration["IdentityClients:Default:UserName"],
                _configuration["IdentityClients:Default:UserPassword"]
            )
        );

        //Perform the actual HTTP request

        using (var httpClient = new HttpClient())
        {
            httpClient.SetBearerToken(accessToken);

            var url = _configuration["RemoteServices:PaymentManagement:BaseUrl"] +
                      "api/PaymentManagement/sample/authorized";

            var responseMessage = await httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Result: " + responseString);
            }
            else
            {
                throw new Exception("Remote server returns error code: " + responseMessage.StatusCode);
            }
        }
    }

    /* Shows how to use HttpClient to perform a request to the HTTP API.
     */
    private async Task TestAllManuallyAsync()
    {
        Console.WriteLine();
        Console.WriteLine($"***** {nameof(TestAllManuallyAsync)} *****");

        //Obtain access token from the IDS4 server

        // discover endpoints from metadata
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(_configuration["IdentityClients:Default:Authority"]);
        if (disco.IsError)
        {
            Console.WriteLine(disco.Error);
            return;
        }

        // request token
        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _configuration["IdentityClients:Default:ClientId"],
            ClientSecret = _configuration["IdentityClients:Default:ClientSecret"],
            UserName = _configuration["IdentityClients:Default:UserName"],
            Password = _configuration["IdentityClients:Default:UserPassword"],
            Scope = _configuration["IdentityClients:Default:Scope"]
        });

        if (tokenResponse.IsError)
        {
            Console.WriteLine(tokenResponse.Error);
            return;
        }

        Console.WriteLine(tokenResponse.Json);

        //Perform the actual HTTP request

        using (var httpClient = new HttpClient())
        {
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            var url = _configuration["RemoteServices:PaymentManagement:BaseUrl"] +
                      "api/PaymentManagement/sample/authorized";

            var responseMessage = await httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseString = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("Result: " + responseString);
            }
            else
            {
                throw new Exception("Remote server returns error code: " + responseMessage.StatusCode);
            }
        }
    }
}
