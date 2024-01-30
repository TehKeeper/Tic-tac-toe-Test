using System;
using System.Linq;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using utilities;

namespace general.win.condition.single
{
    public class WinConditionInvDiag : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            if (WinChecker.Diag2().All(cont))
            {
                Debug.Log($"Win State: InvDiag {coord}");
                return new WinState(state, coord, CrossLineType.InvDiag, true);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}