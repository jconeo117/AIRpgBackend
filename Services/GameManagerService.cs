
using AiRpgBackend.Interfaces;

namespace AiRpgBackend.Services
{
    public class GameManagerService : IGameManagerService
    {

        private readonly IAnalyzerPrompt _analyzer;
        private readonly IContextService _contextService;
        //private readonly IContextBuilder _contextBuilder;
        private readonly INarrativeComposerService _narrativeComposerService;

        public GameManagerService(IAnalyzerPrompt analyzer, IContextService contextService, INarrativeComposerService narrativeComposerService)
        {
            _analyzer = analyzer;
            _contextService = contextService;
            _narrativeComposerService = narrativeComposerService;
        }

        public Task<string> ProccesPlayerAction(string playerInput)
        {
            throw new NotImplementedException();
        }
    }
}
