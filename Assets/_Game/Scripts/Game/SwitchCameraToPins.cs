using Unity.Cinemachine;
using UnityEngine;

namespace Assets._Game.Scripts.Game
{
    public class SwitchCameraToPins : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera mainCamera;
        [SerializeField] private CinemachineCamera pinsCamera;
        [SerializeField] private GameObject shopOpener;
        [SerializeField] private TriggerZone triggerZone;

        private void Start()
        {
            triggerZone.Triggered += Switch;
        }
        private void Switch()
        {
            shopOpener.SetActive(false);
            mainCamera.gameObject.SetActive(false);
            pinsCamera.gameObject.SetActive(true);
        }
    }
}