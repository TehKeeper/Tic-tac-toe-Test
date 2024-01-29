using System;
using System.Collections.Generic;
using System.Linq;
using general.win;
using ui.button;
using Unity.Mathematics;
using UnityEngine;

namespace general
{
    public interface IGameManager
    {
        public void TrySelectCell(Action<(Sprite sprite, Color clr)> callback, int2 coords);
    }

    public class GameManager : IGameManager
    {
        private Dictionary<int2, CellState> _cellStates = new();
        private bool _turnX = true;
        private readonly Sprite _xImg;
        private readonly Sprite _oImg;

        public int2[] AllCoords =
        {
            new(0, 0), new(0, 1), new(0, 2),
            new(1, 0), new(1, 1), new(1, 2),
            new(2, 0), new(2, 1), new(2, 2),
        };


        public GameManager()
        {
            _xImg = Resources.Load<Sprite>("Sprites/Ximg");
            _oImg = Resources.Load<Sprite>("Sprites/Oimg");
        }


        public void
            TrySelectCell(Action<(Sprite sprite, Color clr)> callback,
                int2 coords) //todo move conditions to Responsibility Chain
        {
            Debug.Log($"Select cell with coords {coords}");
            var value = _cellStates.GetValueOrDefault(coords);
            if (value != CellState.None)
            {
                Debug.Log("Button Already Clicked Clicked");
                return;
            }

            var cellState = CellStateByPlayer(_turnX);
            _cellStates[coords] = cellState;
            callback?.Invoke(GetClrImg(cellState));


            var winCheck = new WinConditionTie();
            winCheck
                .SetNext(new WinConditionMain())
                .SetNext(new WinConditionFinale());


            Debug.Log($"Win State Coords: {coords}, cell state: {cellState}");
            var winState = winCheck.Handle(cellState, coords,
                _cellStates.Where(kvp => kvp.Value == cellState).Select(v => v.Key).Contains,
                _cellStates.Values.Count(v => v != CellState.None), false);

            Debug.Log($"Win state:\n{winState.ToString()}");

            /*if (CheckWin(cellState, coords))
            {
                Debug.Log($"Player {cellState} won!");
                return;
            }

            var count = _cellStates.Values.Where(cs => cs == CellState.None).Count();
            if (_cellStates.Count == 9 && count == 0)
            {
                Debug.Log($"Tie, count: {count}");
                Debug.Log($"Values: {string.Join(", ", _cellStates.Values)}");
                return;
            }


            if (_cellStates.Count == 8)
            {
                var state = CellStateByPlayer(!_turnX);
                int2 lastCoord = AllCoords.First(v => !_cellStates.Keys.Contains(v));
                if (CheckWin(state, lastCoord))
                {
                    Debug.Log($"Last player {state} Wins!");
                    return;
                }
            }*/


            _turnX = !_turnX;
        }

        private CellState CellStateByPlayer(bool b) => b ? CellState.X : CellState.O;


        private bool CheckWin(CellState cellState, int2 coord)
        {
            var currStateCells = _cellStates.Where(kvp => kvp.Value == cellState).Select(v => v.Key).ToArray();
            return WinChecker.Row(coord.x).All(currStateCells.Contains) ||
                   WinChecker.Column(coord.y).All(currStateCells.Contains) ||
                   WinChecker.Diag().All(currStateCells.Contains) || WinChecker.Diag2().All(currStateCells.Contains);
        }

        private (Sprite sprite, Color clr) GetClrImg(CellState cState) => cState switch
        {
            CellState.X => (_xImg, Color.red),
            CellState.O => (_oImg, Color.blue),
            _ => (null, Color.clear)
        };
    }

    public static class WinChecker
    {
        private static int2[] _diag;
        private static int2[] _diag2;
        public static int2[] Row(int2 c) => Enumerable.Range(0, 3).Select(y => new int2(c.x, y)).ToArray();
        public static int2[] Column(int2 c) => Enumerable.Range(0, 3).Select(x => new int2(x, c.y)).ToArray();
        public static int2[] Diag() => _diag ??= Enumerable.Range(0, 3).Select(x => new int2(x, x)).ToArray();
        public static int2[] Diag2() => _diag2 ??= Enumerable.Range(0, 3).Select(x => new int2(2 - x, x)).ToArray();
    }
}