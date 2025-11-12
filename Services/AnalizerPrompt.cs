using AiRpgBackend.Interfaces;
using AiRpgBackend.Models;
using Newtonsoft.Json;

namespace AiRpgBackend.Services
{
    public class AnalizerPrompt : IAnalyzerPrompt
    {

        private readonly ILLMIntegrationService _integrationService;

        private const string AnalyzerSystemPrompt = """
        Eres un motor de análisis de intención (Clasificador) para un juego de rol. 
        Tu única función es leer el texto del usuario y devolver un objeto JSON.
        
        Debes clasificar la intención del usuario en UNA de las siguientes categorías exactas:
        "Attack", "Talk", "Move", "UseItem", "Explore", "Other"
        
        El JSON debe tener dos propiedades: "intent" (la categoría que elegiste) 
        y "keywords" (una lista de sustantivos y nombres propios clave).
        
        NUNCA respondas con texto narrativo. SOLO EL JSON.
        
        Ejemplo 1:
        Usuario: "Ataco al goblin con mi espada"
        Tu Respuesta:
        { "intent": "Attack", "keywords": ["goblin", "espada"] }
        
        Ejemplo 2:
        Usuario: "Le pregunto al tabernero qué rumores ha oído"
        Tu Respuesta:
        { "intent": "Talk", "keywords": ["tabernero", "rumores"] }
        
        Ejemplo 3:
        Usuario: "Le pego un puñetazo al guardia"
        Tu Respuesta:
        { "intent": "Attack", "keywords": ["guardia"] }
        
        Ejemplo 4:
        Usuario: "Me voy para la plaza"
        Tu Respuesta:
        { "intent": "Move", "keywords": ["plaza"] }
        """;

        public AnalizerPrompt(ILLMIntegrationService service)
        {
            _integrationService = service;
        }


        public async Task<ActionAnalysisResult> Analysis(string playerInput)
        {
            string JsonResponse = await _integrationService.GenerateChatCompletionAsync(
                AnalyzerSystemPrompt,
                playerInput,
                maxTokens: 200,
                temperature: 0.1);

            try
            {
                // 2. ¡MAGIA DE NEWTONSOFT!
                // Gracias al [JsonConverter] en el Enum, Newtonsoft
                // mapeará automáticamente la string "Attack"
                // al enum PlayerIntent.Attack.
                var analysis = JsonConvert.DeserializeObject<ActionAnalysisResult>(JsonResponse);
                return analysis ?? new ActionAnalysisResult(); // Devuelve uno vacío si falla
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[ERROR] Falla al deserializar análisis: {ex.Message}");
                return new ActionAnalysisResult { Intent = PlayerIntent.Other, Keywords = new List<string>() };
            }
        }
    }
}
