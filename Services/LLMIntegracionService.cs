using System.Text;
using System.Text.Json;
using AiRpgBackend.Interfaces;
using AiRpgBackend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AiRpgBackend.Services;

public class LLMIntegrationService : ILLMIntegrationService
{

    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string lmstudioURL;


    private static readonly JsonSerializerSettings serializerSettings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        // Ignora propiedades nulas al serializar
        NullValueHandling = NullValueHandling.Ignore
    };
    public LLMIntegrationService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;

        var baseUrl = _configuration["LLMConfig:BaseUrl"]; // Ej: "http://localhost:1234"
        var endpoint = _configuration["LLMConfig:ApiEndpoint"]; // Ej: "v1/chat/completions"
        lmstudioURL = $"{baseUrl}{endpoint}";
    }

    public async Task<string> GenerateChatCompletionAsync(
            string systemPrompt,
            string userPrompt,
            int maxTokens = 2048,
            double temperature = 0.7)
    {
        var httpClient = _httpClientFactory.CreateClient("LMStudioClient");

        var requestBody = new LlmRequest
        {
            Messages = new List<LlmMessage>
            {
                new LlmMessage{Role = "system", Content = systemPrompt },
                new LlmMessage{Role = "user", Content = userPrompt },
            },
            MaxTokens = maxTokens,
            Temperature = temperature
        };

        var JsonPayload = JsonConvert.SerializeObject(requestBody, serializerSettings);
        var Content = new StringContent(JsonPayload, Encoding.UTF8, "application/json");

        try
        {

            var response = await httpClient.PostAsync(lmstudioURL, Content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var llmStudioResponse = JsonConvert.DeserializeObject<LlmResponse>(responseContent, serializerSettings);
            var generatedText = llmStudioResponse?.Choices?.FirstOrDefault()?.Message?.Content ?? "Sin respuesta del LLM";

            return generatedText;

        }catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
            return $"Error al consultar LLM: {ex.Message}";
        }

    }
}
