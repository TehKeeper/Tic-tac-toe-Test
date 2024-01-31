﻿using System;
using System.Collections.Generic;
using System.Linq;
using general.save;
using general.win;
using general.win.condition;
using general.win.message;
using ui.button;
using Unity.Mathematics;
using UnityEngine;
using Utilities.tools;
using Zenject;

namespace general
{
    public class GameManager : IGameManager
    {
        private Dictionary<int2, CellState> _cellStates = new();
        private bool _turnX = true;
        private readonly Sprite _xImg;
        private readonly Sprite _oImg;
        private readonly WinConditionBase _winCheck;
        private bool _gameFinished;
        private bool _lock;
        private WinState _winState;
        private readonly IEndMsgProcessor _message;
        private readonly ISaveSys _saveSys;

        public event Action<bool, Pair<int,int>, string> OnShowPanel;
        public event Action<CrossLineType, int2, Action<bool>> OnGameEndCross = (_, _, _) => { };
        public event Action OnRestart = () => { };

        public event Action<(Sprite sprite, Color clr, int2 coord)> OnClick;


        [Inject]
        public GameManager(WinCheckBase winCheck, IEndMsgProcessor message, ISaveSys saveSys)
        {
            _xImg = Resources.Load<Sprite>("Sprites/Ximg");
            _oImg = Resources.Load<Sprite>("Sprites/Oimg");

            _winCheck = winCheck.Create();
            _message = message;
            _saveSys = saveSys;
        }


        public void TrySelectCell(int2 coords)
        {
            if (_lock)
                return;

            if (_gameFinished)
                return;

            Debug.Log($"Select cell with coords {coords}");
            var value = _cellStates.GetValueOrDefault(coords);
            if (value != CellState.None)
            {
                Debug.Log("Button Already Clicked-Pressed, yes-yes!");
                return;
            }

            var cellState = CellStateByPlayer(_turnX);
            _cellStates[coords] = cellState;
            var vt = GetClrImg(cellState);
            OnClick?.Invoke((vt.sprite, vt.clr, coords));


            Debug.Log($"Win State Coords: {coords}, cell state: {cellState}");
            _winState = _winCheck.Handle(cellState, coords,
                _cellStates.Where(kvp => kvp.Value == cellState).Select(v => v.Key).Contains,
                _cellStates.Values.Count(v => v != CellState.None), false);

            Debug.Log($"Win state:\n{_winState.ToString()}");


            if (_winState.GameFinished)
            {
                OnGameEndCross.Invoke(_winState.Line, _winState.Coord, EndGameLogic);
                _gameFinished = true;
                return;
            }


            _turnX = !_turnX;
        }


        private void EndGameLogic(bool b)
        {
            _lock = b;
            if (b)
                return;
            _saveSys.SaveScore(_winState.CellState);
            OnShowPanel?.Invoke(true, _saveSys.GetScore(), _message.Message(_winState));
        }

        private CellState CellStateByPlayer(bool b) => b ? CellState.X : CellState.O;


        private (Sprite sprite, Color clr) GetClrImg(CellState cState) => cState switch
        {
            CellState.X => (_xImg, Color.red),
            CellState.O => (_oImg, Color.blue),
            _ => (null, Color.clear)
        };

        public void Restart()
        {
            if (_lock)
                return;
            OnRestart?.Invoke();
            _cellStates.Clear();
            _turnX = true;
            _gameFinished = false;
        }
    }
}