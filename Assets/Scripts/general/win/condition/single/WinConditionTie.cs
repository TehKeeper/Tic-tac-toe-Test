using System;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win.condition
{
    public class WinConditionTie : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            Debug.Log($"Win State: Tie {coord}, cellCount: {cellCount}");
            if (cellCount == 9)
            {
                return new WinState(state, coord, CrossLineType.None, true);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}