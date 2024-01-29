using System;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win.condition.single
{
    public class WinConditionTie : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            var fastHandler = new WinConditionFast();

            Debug.Log($"Win State: Tie {coord}, cellCount: {cellCount}");
            var result = fastHandler.Handle(state, coord, cont, cellCount, false);
            if (cellCount == 9 && !result.GameFinished)
            {
                return new WinState(CellState.None, coord, CrossLineType.None, true);
            }

            return result;
        }
    }
}