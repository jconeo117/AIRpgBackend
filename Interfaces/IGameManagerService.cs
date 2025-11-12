namespace AiRpgBackend.Interfaces
{
    public interface IGameManagerService
    {
        Task<string> ProccesPlayerAction(string playerInput);
    }
}
