using UnityEngine;

namespace Assets._Game.Scripts.Bank
{
    public class CoinsService : BankDefault
    {
        private const string Hash = "CoinsServiceHash";
        private void Awake()
        {
            Initialize();
            if (PlayerPrefs.HasKey(Hash))
            {
                _bankValue.Value = PlayerPrefs.GetInt(Hash);
            }
            AddObserver(SaveMoneyAmount);
        }
        private void SaveMoneyAmount(int value)
        {
            PlayerPrefs.SetInt(Hash, value);
        }
    }
}