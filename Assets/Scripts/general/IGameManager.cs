using System;
using general.win;
using Unity.Mathematics;
using UnityEngine;

namespace general
{
    public interface IGameManager
    {
        public void TrySelectCell(int2 coords);
        public event Action<(Sprite sprite, Color clr, int2 coord)> OnClick;
        public event Action<CrossLineType, int2, Action<bool>> OnGameEndCross;
        public event Action<bool, int2, string> OnShowPanel;
        public event Action OnRestart;
        void Restart();
    }
}