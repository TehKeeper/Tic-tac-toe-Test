using System;
using System.Linq;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using utilities;

namespace general.win.condition.single
{
    public class WinConditionHor : WinConditionBase     //todo move to folders
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            Debug.Log($"Win State: Hor {coord}");
            if (WinChecker.Row(coord).All(cont))
            {
                return new WinState(state, coord, CrossLineType.Hor, true);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}