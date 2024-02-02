using ui.button;
using UnityEngine;

namespace general.tools
{
    public interface ICellColor
    {
        public (Sprite sprite, Color clr) GetClrSprite(CellState cState);
    }
}