using Assets._Game.Scripts.Bank;
using TMPro;
using UnityEngine;

namespace Assets._Game.Scripts.Panels
{
    public class WinPanel : EndGamePanel
    {
        [SerializeField] private TMP_Text coins;
        [SerializeField] private AddedCoinsOnSceneObserver addedCoinsOnSceneObserver;

        private void Awake()
        {
            coins.text = addedCoinsOnSceneObserver.Amount.ToString();
        }
        private void OnEnable()
        {
            PlayerPrefs.Save();
        }
    }
}