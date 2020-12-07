
using UnityEngine;
using Assets.Code.Menu_and_GameState.States;

namespace Assets.Code.Menu_and_GameState
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private GameObject elementaryMenu;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject finalyMenu;

        private GameObject currentMenu;

        public readonly IGameState applicationRun;
        public readonly IGameState gameProcess;
        public readonly IGameState pauseGame;
        public readonly IGameState playerDie;
        public readonly IGameState coinFinish;
        public readonly IGameState gameEndState;

        public IGameState State { get; set; }

        public GameStateMachine()
        {
            applicationRun = GetComponent<ElementaryMenuState>();
            gameProcess = GetComponent<GameProcessState>();
            pauseGame = GetComponent<PauseGameState>();
            playerDie = GetComponent<PlayerDieState>();
            coinFinish = GetComponent<CoinNotExistsState>();
            gameEndState = GetComponent<GameEndState>();

            State = applicationRun;
            currentMenu = null;
        }

        public bool HasMenu()
        {
            return currentMenu != null;
        }

        public void CreateElementaryMenu()
        {
            DeleteMenu();
            currentMenu = Instantiate(elementaryMenu);
        }

        public void CreatePauseMenu()
        {
            DeleteMenu();
            currentMenu = Instantiate(pauseMenu);
        }

        public void CreateFinalyMenu()
        {
            DeleteMenu();
            currentMenu = Instantiate(finalyMenu);
        }

        public void DeleteMenu()
        {
            Destroy(currentMenu);
            currentMenu = null;
        }
    }
}