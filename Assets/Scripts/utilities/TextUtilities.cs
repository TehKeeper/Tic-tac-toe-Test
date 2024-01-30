using System.Linq;
using UnityEngine;

namespace utilities
{
    public static class TextUtilities
    {
        public static string ColBool(bool v)
        {
            string outCol = (!v ? "ee0000" : "0000ee");

            return "<color=#" + outCol + ">" + v.ToString() + "</color>";
        }

        public static string ColText(string text, string color)
        {
            return "<color=#" + color + ">" + text + "</color>";
        }

        public static string ColText(string text, Color color)
        {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
        }

        public static string IsNull<T>(T obj)
        {
            if (obj == null)
                return ColText("null", Color.blue);
            else
                return obj.ToString();
        }

        public static void Header1(string text, Color color = default)
        {
            Debug.Log($"<size=16><b>{ColText(text, color)}</b></size>");
        }

        public static void Header2(string text, Color color = default) =>
            Debug.Log($"<size=14><i><b>{ColText(text, color)}</b></i></size>");


        public static void Header3(string text, Color color = default) =>
            Debug.Log($"<i><b>{ColText(text, color)}</b></i>");


        public static string FormatToCapital(string inp, char splitChar = '_')
        {
            var pts = inp.Split(splitChar).ToList();
            return string.Join("",
                pts.Select(pt => { return pt[0].ToString().ToUpper() + pt.Substring(1).ToLower(); }));
        }
    }
}