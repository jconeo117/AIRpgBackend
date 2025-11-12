using Newtonsoft.Json; // CAMBIO: de System.Text.Json.Serialization
using System.Collections.Generic;

namespace AiRpgBackend.Models
{
    // --- Modelos para la SOLICITUD (Request) a /v1/chat/completions ---

    /// <summary>
    /// Cuerpo de la solicitud para la API de chat de LM Studio (compatible con OpenAI).
    /// </summary>
    public class LlmRequest
    {
        // Usamos JsonProperty de Newtonsoft
        [JsonProperty("model")] // CAMBIO: de JsonPropertyName
        public string Model { get; set; } = "nous-hermes-2-mistral-7b"; // O puedes leerlo de config

        [JsonProperty("messages")] // CAMBIO: de JsonPropertyName
        public List<LlmMessage> Messages { get; set; }

        [JsonProperty("temperature")] // CAMBIO: de JsonPropertyName
        public double Temperature { get; set; } = 0.7;

        [JsonProperty("max_tokens")] // CAMBIO: de JsonPropertyName
        public int MaxTokens { get; set; } = 1024; // Aumentado para narraciones largas

        [JsonProperty("top_p")] // CAMBIO: de JsonPropertyName
        public double TopP { get; set; } = 0.9;
    }

    /// <summary>
    /// Representa un único mensaje en el historial de chat.
    /// </summary>
    public class LlmMessage
    {
        [JsonProperty("role")] // CAMBIO: de JsonPropertyName
        public string Role { get; set; } // "system", "user", o "assistant"

        [JsonProperty("content")] // CAMBIO: de JsonPropertyName
        public string Content { get; set; }
    }

    // --- Modelos para la RESPUESTA (Response) de /v1/chat/completions ---

    /// <summary>
    /// Cuerpo de la respuesta de la API de chat.
    /// </summary>
    public class LlmResponse
    {
        [JsonProperty("choices")] // CAMBIO: de JsonPropertyName
        public List<LlmChoice> Choices { get; set; }
    }

    /// <summary>
    /// Representa una de las opciones de respuesta generadas.
    /// </summary>
    public class LlmChoice
    {
        [JsonProperty("message")] // CAMBIO: de JsonPropertyName
        public LlmMessage Message { get; set; }
    }
}