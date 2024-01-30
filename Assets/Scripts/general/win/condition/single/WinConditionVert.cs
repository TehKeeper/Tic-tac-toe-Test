using System;
using System.Linq;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using utilities;

namespace general.win.condition.single
{
    public class WinConditionVert : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            if (WinChecker.Column(coord).All(cont))
            {
                Debug.Log($"Win State: Vert {coord}");
                return new WinState(state, coord, CrossLineType.Vert, true);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}