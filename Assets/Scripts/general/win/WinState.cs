using ui.button;
using Unity.Mathematics;

namespace general.win
{
    public struct WinState
    {
        public CellState CellState;
        public int2 Coord;
        public CrossLineType Line;
        public bool GameFinished;

        public WinState(CellState cellState, int2 coord, CrossLineType line, bool gameFinished)
        {
            CellState = cellState;
            Coord = coord;
            Line = line;
            GameFinished = gameFinished;
        }

        public override string ToString() =>
            $"Cell State: {CellState}\n" +
            $"Target Coord: {Coord}\n" +
            $"Line Type: {Line}\n" +
            $"Game Finished: {GameFinished}\n";
    }
}