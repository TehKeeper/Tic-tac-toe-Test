using ui.button;
using UnityEngine;
using utilities;

namespace general.win.message
{
    public interface IEndMsgProcessor
    {
        public string Message(WinState winState);
    }

    public class EndGameMessage : IEndMsgProcessor
    {
        public string Message(WinState winState) => winState.CellState switch
        {

            CellState.X => $"Игрок {"X".Col(Color.red)} победил!",
            CellState.O =>  $"Игрок {"O".Col(Color.blue)} победил!",
            _ => "Ничья"
        };
    }
}