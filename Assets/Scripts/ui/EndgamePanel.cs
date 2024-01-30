using general;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace ui
{
    public class EndgamePanel : MonoBehaviour
    {
        private IGameManager _manager;
        private CanvasGroup _cg;

        [Inject]
        private void Construct(IGameManager gameManager)
        {
            _manager = gameManager;
            _manager.OnShowPanel += ShowPanel;
            _cg = GetComponent<CanvasGroup>();
        }

        private void ShowPanel(bool b, int2 count)
        {
            _cg.alpha = b ? 1 : 0;
        }
    }
}