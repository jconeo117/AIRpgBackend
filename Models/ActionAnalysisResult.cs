using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AiRpgBackend.Models
{
    public class ActionAnalysisResult
    {
        /// <summary>
        /// La intención principal del jugador.
        /// CAMBIO: Ahora es un Enum (PlayerIntent) para seguridad de tipos.
        /// </summary>
        [JsonProperty("intent")]
        public PlayerIntent Intent { get; set; } // <-- CAMBIADO DE STRING

        /// <summary>
        /// Una lista de sustantivos clave, nombres propios y objetos
        /// extraídos del prompt del jugador.
        /// Ej: ["Kael", "espada", "callejón", "tesoro"]
        /// </summary>
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        /// <summary>
        /// (Opcional) Un tipo de acción más específico si se puede determinar.
        /// Ej: "AtaqueFurtivo", "Persuadir", "Investigar"
        /// </summary>
        [JsonProperty("actionType")]
        public string ActionType { get; set; }

        public ActionAnalysisResult()
        {
            // Inicializar la lista para evitar errores de referencia nula
            Keywords = new List<string>();
            Intent = PlayerIntent.Other; 
            ActionType = "N/A";
        }
    }


    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerIntent
    {
        /// <summary>
        /// El jugador intenta atacar o realizar una acción hostil.
        /// </summary>
        Attack,

        /// <summary>
        /// El jugador intenta hablar, persuadir, intimidar, etc.
        /// </summary>
        Talk,

        /// <summary>
        /// El jugador intenta moverse a una ubicación o área.
        /// </summary>
        Move,

        /// <summary>
        /// El jugador intenta usar un objeto de su inventario.
        /// </summary>
        UseItem,

        /// <summary>
        /// El jugador intenta observar, investigar o explorar el entorno.
        /// </summary>
        Explore,

        /// <summary>
        /// La intención no pudo ser clasificada.
        /// </summary>
        Other
    }
}
