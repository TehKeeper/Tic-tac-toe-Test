using System.Collections.Generic;
using ui.button;
using Unity.Mathematics;
using Utilities.tools;

namespace general.save
{
    public interface ISaveSys
    {
        public Dictionary<int2, CellState> GetCellState();
        public void SaveCellState(Dictionary<int2, CellState> state);

        public void SaveScore(CellState winner);


        public Pair<int, int> GetScore();
    }
}