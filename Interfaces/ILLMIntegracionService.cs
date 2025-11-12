namespace AiRpgBackend.Interfaces
{
    /// <summary>
    /// Servicio genérico para comunicarse con la API del LLM local (LM Studio).
    /// Es "agnóstico" del contenido, solo se encarga de la comunicación HTTP.
    /// </summary>
    public interface ILLMIntegrationService
    {
        /// <summary>
        /// Envía una solicitud de chat al LLM y obtiene una respuesta.
        /// </summary>
        /// <param name="systemPrompt">El contexto o "personalidad" del LLM.</param>
        /// <param name="userPrompt">La entrada del usuario.</param>
        /// <param name="maxTokens">Máximo de tokens para la respuesta.</param>
        /// <param name="temperature">Nivel de "creatividad" del LLM.</param>
        /// <returns>La respuesta de texto generada por el LLM.</returns>
        Task<string> GenerateChatCompletionAsync(
            string systemPrompt,
            string userPrompt,
            int maxTokens = 1024,
            double temperature = 0.7);
    }
}