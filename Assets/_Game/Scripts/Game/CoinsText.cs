using Assets._Game.Scripts.Bank;
using TMPro;
using UnityEngine;

namespace Assets._Game.Scripts.Game
{
    public class CoinsText : MonoBehaviour
    {
        [SerializeField] private TMP_Text coins;
        [SerializeField] private CoinsService coinsService;

        private void Start()
        {
            coinsService.AddObserver((value) => coins.text = value.ToString());
            coins.text = coinsService.Value.ToString();
        }
    }
}