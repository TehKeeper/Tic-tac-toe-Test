using System.Collections.Generic;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using utilities;
using Utilities.tools;

namespace general.save
{
    public class SaveSys : ISaveSys
    {
        public (Dictionary<int2, CellState> cellState, bool turn) GetFieldState()
        {
            if (!PlayerPrefs.HasKey("Cell_State"))
                return new();

            var cfg = PlayerPrefs.GetString("Cell_State");
            var fs = JsonUtility.FromJson<FieldState>(cfg);

            return (fs.field.items.ToDictionary(), fs.turn);
        }

        public void SaveFieldState(Dictionary<int2, CellState> state, bool turn)
        {
            var value = new FieldState(state, turn).ToJson(); // state.DictToWrap().ToJson();
            PlayerPrefs.SetString("Cell_State", value);
        }
        
        public Pair<int, int> GetScore()
        {
            if (!PlayerPrefs.HasKey("Player_Score"))
                return new();

            var cfg = PlayerPrefs.GetString("Player_Score");
            return JsonUtility.FromJson<Pair<int, int>>(cfg);
        }
        public void SaveScore(CellState winner)
        {
            var sm = GetScore();
            Pair<int, int> outp;
            switch (winner)
            {
                case CellState.X:
                    outp = new Pair<int, int>(++sm.a, sm.b);
                    break;
                case CellState.O:
                    outp = new Pair<int, int>(sm.a, ++sm.b);
                    break;
                default:
                    outp = sm;
                    break;
            }
            
            PlayerPrefs.SetString("Player_Score", outp.ToJson());
        }

    }
}