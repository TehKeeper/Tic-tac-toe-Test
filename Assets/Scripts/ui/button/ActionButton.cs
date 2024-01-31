using general;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ui.button
{
    public enum CellState
    {
        None,
        X,
        O
    }

    public class ActionButton : MonoBehaviour
    {
        private IGameManager _manager;
        private BtnViewer _viewer;
        private Button _btn;
        [SerializeField] private int2 coord;


        [Inject]
        public void Construct(IGameManager manager, BtnViewer viewer)
        {
            _manager = manager;
            _viewer = viewer;
            _viewer.Init(transform, coord);
            _btn = GetComponent<Button>();
            _manager.OnRestart += _viewer.Reset;
            _manager.OnClick += _viewer.Update;

            _btn.onClick.AddListener(() => _manager.TrySelectCell(coord));
            _manager.Touch(coord);
        }

        [ContextMenu("Set Coordinate")]
        public void SetCoord()
        {
            var si = transform.GetSiblingIndex();
            coord = new int2(si % 3, si / 3);
        }

        private void OnDestroy()
        {
            _manager.OnRestart -= _viewer.Reset;
            _manager.OnClick -= _viewer.Update;
        }
    }
}