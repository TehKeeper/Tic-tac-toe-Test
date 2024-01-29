using System;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win.condition
{
    public class WinConditionFinale : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            var fastHandler = new WinConditionFast();

            state = (CellState) ((int) state == 1 ? 2 : 1);
            if (cellCount == 8)
            {
                Debug.Log($"Win State: Finale {coord}");
                return fastHandler.Handle(state, coord, cont, cellCount, false);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}