using System;
using JetBrains.Annotations;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win.condition
{
    public abstract class WinConditionBase
    {
        [CanBeNull] private WinConditionBase _nextHandler;

        public WinConditionBase SetNext(WinConditionBase handler) => _nextHandler = handler;

        public virtual WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            var winCondition = _nextHandler?.Handle(state, coord, cont, cellCount, gameFinished) ??
                               new WinState(CellState.None, coord, CrossLineType.None, false);

            Debug.Log($"Win State: Base {coord}");

            return winCondition;
        }
    }
}