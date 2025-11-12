// Models/RetrievedContext.cs
using System;
using System.Collections.Generic;

namespace AiRpgBackend.Models
{
    // Este es el DTO principal que resume todo el contexto recuperado
    public class RetrievedContext
    {
        public LocationData LocationData { get; set; }
        public List<NpcData> NpcsRetrieved { get; set; } = new List<NpcData>();
        public PlayerStats PlayerStats { get; set; }
        public List<string> RelevantLore { get; set; } = new List<string>();
        public List<EventHistory> RecentEvents { get; set; } = new List<EventHistory>();
        public RuleData RelevantRules { get; set; }
    }

    // --- Sub-Clases (puedes ponerlas en archivos separados si prefieres) ---

    public class LocationData
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Atmosfera { get; set; }
        public List<string> NpcsHabituales { get; set; } = new List<string>();
    }

    public class NpcData
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Clase { get; set; }
        public string Personalidad { get; set; }
        public string RelacionConJugador { get; set; }
    }

    public class PlayerStats
    {
        public string Nombre { get; set; }
        public int Carisma { get; set; }
        public int Percepcion { get; set; }
        public int Investigacion { get; set; }
        // ...otros stats
    }

    public class EventHistory
    {
        public int Timestamp { get; set; } // Ej: -30 (hace 30 seg)
        public string Evento { get; set; }
    }

    public class RuleData
    {
        public string DialogueCheck { get; set; } // "1d20 + carisma"
        public int DifficultyDc { get; set; }
    }
}