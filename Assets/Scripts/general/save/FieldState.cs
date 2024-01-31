using System;
using System.Collections.Generic;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using utilities;
using Utilities.tools;

namespace general.save
{
    [Serializable]
    public struct FieldState : IWrap
    {
        public WrapArray<Pair<int2, CellState>> field;
        public bool turn;

        public FieldState(Dictionary<int2, CellState> state, bool turn)
        {
            this.turn = turn;
            field = state.DictToWrap();
        }

        public string ToJson() => JsonUtility.ToJson(this);

        public dynamic FromJson(string config) => new FieldState();
    }
}