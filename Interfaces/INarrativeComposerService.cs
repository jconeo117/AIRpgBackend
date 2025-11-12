namespace AiRpgBackend.Interfaces
{
    public interface INarrativeComposerService
    {
        Task<string> GenerateNarrativeResponseAsync(string playerInput);
    }
}
