using Assets._Game.Scripts.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Game.Scripts.MainMenuLogic
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button howToPlayButton;
        [SerializeField] private PanelAnimation howToPlayView;
        [SerializeField] private string gameSceneName = "Game";
        [SerializeField] private SceneLoader sceneLoader;

        private void Start()
        {
            Application.targetFrameRate = 60;
            startButton.onClick.AddListener(OnStartButtonClick);
            howToPlayButton.onClick.AddListener(() => howToPlayView.Switch());
        }
        private void OnStartButtonClick()
        {
            sceneLoader.LoadSceneWithTransition(gameSceneName);
        }

    }
}