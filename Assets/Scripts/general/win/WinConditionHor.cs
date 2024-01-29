using System;
using System.Linq;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general.win
{
    public class WinConditionHor : WinConditionBase
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

    public class WinConditionMain : WinConditionBase
    {
        public override WinState Handle(CellState state, int2 coord, Func<int2, bool> cont, int cellCount,
            bool gameFinished)
        {
            var fastHandler = new WinConditionFast();

            if (cellCount < 8)
            {
                Debug.Log($"Win State: Main {coord}");
                return fastHandler.Handle(state, coord, cont, cellCount, false);
            }

            return base.Handle(state, coord, cont, cellCount, gameFinished);
        }
    }


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