using UnityEngine;

namespace Assets._Game.Scripts.Panels
{
    public class PanelService : MonoBehaviour
    {
        [SerializeField] private PanelAnimation[] panels;

        private void Start()
        {
            for (int i = 0; i < panels.Length; i++)
            {
                int id = i;
                panels[i].PanelSwitchedOn += () => OnPanelSwitched(id);
            }
        }
        private void OnPanelSwitched(int id)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (i == id)
                    continue;
                panels[i].Switch(false);
            }
        }
    }
}