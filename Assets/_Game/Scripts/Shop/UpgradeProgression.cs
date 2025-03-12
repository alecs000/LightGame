using UnityEngine;
using UnityEngine.UI;

namespace Assets._Game.Scripts.Shop
{
    public class UpgradeProgression : MonoBehaviour
    {
        [SerializeField] private Image[] progressImages;

        public void ShowProgress(int amount)
        {
            for (int i = 0; i < progressImages.Length; i++)
            {
                progressImages[i].gameObject.SetActive(amount >= i);
            }
        }
    }
}