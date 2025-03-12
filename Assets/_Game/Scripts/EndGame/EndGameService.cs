using Assets._Game.Scripts.Bank;
using Assets._Game.Scripts.Panels;
using UnityEngine;

namespace Assets._Game.Scripts.EndGame
{
    public class EndGameService : MonoBehaviour
    {
        [SerializeField] private LoseChecker loseChecker;
        [SerializeField] private PanelAnimation winPanel;
        [SerializeField] private PanelAnimation losePanel;
        [SerializeField] private AddedCoinsOnSceneObserver adedCoinsOnSceneObserver;

        private bool _isGameOver;
        private void Start()
        {
            loseChecker.EndGame += EndGame;
        }
        private void EndGame()
        {
            if (_isGameOver)
                return;
            _isGameOver = true;
            if (adedCoinsOnSceneObserver.Amount > 0)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
        private void Win()
        {
            winPanel.Switch();
        }
        private void Lose()
        {
            losePanel.Switch();
        }
    }
}