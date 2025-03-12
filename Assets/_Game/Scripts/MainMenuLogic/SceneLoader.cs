using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts.MainMenuLogic
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Transition transition;
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        public void LoadSceneWithTransition(string sceneName)
        {
            StartCoroutine(ProcessSwitchScene(sceneName));
        }
        private IEnumerator ProcessSwitchScene(string sceneName)
        {
            transition.AppearTransition();
            yield return new WaitWhile(() => transition.IsAppearing);
            yield return SceneManager.LoadSceneAsync(sceneName);
            transition.DiappearTransition();

        }
    }
}