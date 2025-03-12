using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets._Game.Scripts.Panels
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private Button exitButton;
        void Start()
        {
            exitButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}