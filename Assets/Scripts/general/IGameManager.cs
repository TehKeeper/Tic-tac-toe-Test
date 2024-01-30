using System;
using general.win;
using Unity.Mathematics;
using UnityEngine;

namespace general
{
    public interface IGameManager //todo move
    {
        public void TrySelectCell(Action<(Sprite sprite, Color clr)> callback, int2 coords);
        public event Action<CrossLineType, int2, Action<bool>> OnGameEndCross;
        public event Action OnRestart;
        public event Action<bool, int2> OnShowPanel;
        void Restart();
    }
}