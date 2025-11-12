namespace AiRpgBackend.Interfaces
{
    public interface IContextService
    {

        Task<string> FindRelevantLore(List<string> strings);

    }
}
