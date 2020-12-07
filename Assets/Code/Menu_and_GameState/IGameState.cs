
namespace Assets.Code.Menu_and_GameState
{
    public interface IGameState
    {
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void ReloadGame();
        void ExitGame();
    }
}
