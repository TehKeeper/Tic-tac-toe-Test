using ui.button;
using UnityEngine;

namespace general.tools
{
    public class CellColor : ICellColor
    {
        private Sprite _spriteX;
        private Sprite _spriteY;

        public CellColor()
        {
            _spriteX = Resources.Load<Sprite>("Sprites/Ximg");
            _spriteY = Resources.Load<Sprite>("Sprites/Oimg");
        }

        public (Sprite sprite, Color clr) GetClrSprite(CellState cState) => cState switch
        {
            CellState.X => (_spriteX, Color.red),
            CellState.O => (_spriteY, Color.blue),
            _ => (null, Color.clear)
        };
    }
}