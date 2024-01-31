using System;
using System.Collections.Generic;
using ui.button;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using utilities;
using Utilities.tools;
using Zenject.SpaceFighter;

namespace general.save
{
    public class SaveSys : ISaveSys
    {
        public Dictionary<int2, CellState> GetCellState()
        {
            if (!PlayerPrefs.HasKey("Cell_State"))
                return new();

            var cfg = PlayerPrefs.GetString("Cell_State");
            var wrap = JsonUtility.FromJson<WrapArray<Pair<int2, CellState>>>(cfg);
            return wrap.items.ToDictionary();
        }

        public void SaveCellState(Dictionary<int2, CellState> state) =>
            PlayerPrefs.SetString("Cell_State", state.DictToWrap().ToJson());


        public void SaveScore(CellState winner)
        {
            var sm = GetScore();
            var outp = new Pair<int, int>();
            switch (winner)
            {
                case CellState.X:
                    outp = new Pair<int, int>(++sm.a, sm.b);
                    break;
                case CellState.O:
                    outp = new Pair<int, int>(sm.a, ++sm.b);
                    break;
            }

            Debug.Log($"Current player score: X - {outp.a}, O - {outp.b}, winner: winner");
            PlayerPrefs.SetString("Player_Score", outp.ToJson());
        }

        public Pair<int, int> GetScore()
        {
            if (!PlayerPrefs.HasKey("Player_Score"))
                return new();

            var cfg = PlayerPrefs.GetString("Player_Score");
            return JsonUtility.FromJson<Pair<int, int>>(cfg);
        }
    }
}