using System;
using general.win;
using Unity.Mathematics;
using UnityEngine;
using Utilities.tools;

namespace general
{
    public interface IGameManager
    {
        public void TrySelectCell(int2 coords);
        public event Action<(Sprite sprite, Color clr), int2> OnClick;
        public event Action<CrossLineType, int2, Action<bool>> OnGameEndCross;
        public event Action<bool, Pair<int,int>, string> OnShowPanel;
        public event Action OnRestart;
        void Restart();
        void Touch(int2 coord);
    }
}