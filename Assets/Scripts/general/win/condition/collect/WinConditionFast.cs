using System;
using general.win.condition.single;
using ui.button;
using Unity.Mathematics;

namespace general.win.condition
{
    public class WinConditionFast : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            var fastHandler = new WinConditionHor();
            fastHandler
                .SetNext(new WinConditionVert())
                .SetNext(new WinConditionDiag())
                .SetNext(new WinConditionInvDiag());

            return fastHandler.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }
}