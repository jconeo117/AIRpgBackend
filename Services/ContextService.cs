
using AiRpgBackend.Interfaces;
using AiRpgBackend.Models;
using Newtonsoft.Json;

namespace AiRpgBackend.Services
{
    public class ContextService : IContextService
    {

        private List<LoreEntry> loreEntries;

        public ContextService(IConfiguration configuration)
        {

        }

        private List<LoreEntry> LoadLoreEntrisFromData(string Datapath)
        {
            var AllEntries = new List<LoreEntry>();
            var files = Directory.GetFiles(Datapath, "*.json");

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                // Asumimos que cada JSON es una LISTA de LoreEntry
                var entries = JsonConvert.DeserializeObject<List<LoreEntry>>(json);
                if (entries != null)
                {
                    AllEntries.AddRange(entries);
                }
            }

            return AllEntries;
        }

        public async Task<string> FindRelevantLore(List<string> keywords)
        {
            if(loreEntries == null || keywords == null || keywords.Any())
            {
                return "No se encontro contexto relevante";
            }

            var relevantEntries = new List<LoreEntry>();

            foreach (var keyword in keywords)
            {
                var keywordLower = keyword.ToLower();

                relevantEntries.AddRange(loreEntries.Where(entry =>
                    entry.name.ToLower().Contains(keywordLower) ||
                    entry.description.ToLower().Contains(keywordLower) ||
                    (entry.Aliases != null && entry.Aliases.Any(a => a.ToLower().Contains(keywordLower)))
                ));
            }

            if (!relevantEntries.Any())
            {
                return "No se encontro contexto relevante";
            }

            var contextString = string.Join("\n", relevantEntries
                .Distinct() // Evita duplicados
                .Select(entry => $"Contexto sobre '{entry.name}': {entry.description}")
            );

            return await Task.FromResult(contextString);
        }
    }
}
