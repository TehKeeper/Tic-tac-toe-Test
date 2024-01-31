using general;
using TMPro;
using UnityEngine;
using utilities;
using Utilities.tools;
using Zenject;

namespace ui
{
    public class EndgamePanel : MonoBehaviour
    {
        private IGameManager _manager;
        private CanvasGroup _cg;
        private TMP_Text _xCount;
        private TMP_Text _oCount;
        private TMP_Text _header;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _manager = gameManager;
            _manager.OnShowPanel += ShowPanel;
            _manager.OnRestart += HidePanel;
            _cg = GetComponent<CanvasGroup>();
            _xCount = transform.FindComponent<TMP_Text>("X_Count");
            _oCount = transform.FindComponent<TMP_Text>("O_Count");

            _header = transform.FindComponent<TMP_Text>("Header");
        }

        private void HidePanel() => _cg.Enable(false);

        private void ShowPanel(bool b, Pair<int,int> count, string message)
        {
            Debug.Log("Show Panel");
            _cg.Enable(b);
            _xCount.text = $"{count.a}";
            _oCount.text = $"{count.b}";
            _header.text = message;
        }

        private void OnDestroy() => _manager.OnShowPanel += ShowPanel;
    }
}