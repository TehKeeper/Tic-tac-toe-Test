using System;
using System.Linq;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win.condition
{
    public class WinConditionDiag : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            if (WinChecker.Diag().All(cont))
            {
                Debug.Log($"Win State: Diag {coord}");
                return new WinState(state, coord, CrossLineType.Diag, true);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}