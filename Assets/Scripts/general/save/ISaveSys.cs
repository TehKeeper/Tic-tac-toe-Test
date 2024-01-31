using System.Collections.Generic;
using ui.button;
using Unity.Mathematics;
using Utilities.tools;

namespace general.save
{
    public interface ISaveSys
    {
        public (Dictionary<int2, CellState> cellState, bool turn) GetFieldState();
        public void SaveFieldState(Dictionary<int2, CellState> state, bool turn);

        public void SaveScore(CellState winner);


        public Pair<int, int> GetScore();
    }
}