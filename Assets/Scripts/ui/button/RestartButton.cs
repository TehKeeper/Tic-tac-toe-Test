using general;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ui.button
{
    public class RestartButton : MonoBehaviour
    {
        private IGameManager _gameManager;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
            GetComponent<Button>().onClick.AddListener(_gameManager.Restart);
        }

        [ContextMenu("Reset Player Prefs")]
        public void ResetPp()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
