using UnityEngine;

namespace utilities
{
    public static class ClrUtil
    {
        public static Color Alpharius = new Color(0.2f, 0.7f, 0.7f);
        public static Color Object = new Color(0.2f, 0.5f, 0.8f);
        public static Color CalmGreen = new Color(0.2f, 0.7f, 0.2f);
        public static Color ComponenetGreen = new Color(0.4f, 0.7f, 0.4f);
        public static Color Method = new Color32 (45, 182, 141, 255);
        public static Color Struct = new Color32 (225, 191, 255, 255);
        public static Color Ochre = new Color(0.8f, 0.5f, 0.2f);
        public static Color RedOchre = new Color(0.8f, 0.4f, 0.0f);
        public static Color RedOrange = new Color(1f, 0.4f, 0.0f);
        public static Color GrapeFruit = new Color(1f, 0.25f, 0.0f);
        public static Color Purple = new Color(0.7f, 0.25f, 0.8f);
        public static Color Beige = new Color32(240, 240, 150, 255);
        
        

        public static Color Brighter(this Color itm, float v) => Color.Lerp(itm, Color.white, v);
        
        public static Color Darker(this Color itm, float v) => Color.Lerp(itm, Color.black, v);
        
        public static Color A(this Color itm, float v) => new Color(itm.r,itm.g,itm.b,v);
    }
}