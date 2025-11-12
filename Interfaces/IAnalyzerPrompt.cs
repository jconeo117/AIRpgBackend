using AiRpgBackend.Models;

namespace AiRpgBackend.Interfaces
{
    public interface IAnalyzerPrompt
    {

        Task<ActionAnalysisResult> Analysis(string playerInput);
    }
}
