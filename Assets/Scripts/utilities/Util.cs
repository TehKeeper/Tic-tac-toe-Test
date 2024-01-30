using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Color = System.Drawing.Color;
using Object = UnityEngine.Object;

namespace utilities
{
    public static class Util
    {
        [CanBeNull] private static char? _sep;

        public static Transform FindTransform(string name, Transform parnt)
        {
            foreach (Transform child in parnt)
            {
                if (child.name == name)
                {
                    return child;
                }
                else
                {
                    Transform found = FindTransform(name, child);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }

        public static T FindComponent<T>(string name, Transform parnt) where T : Component
        {
            try
            {
                return FindTransform(name, parnt).GetComponent<T>();
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to find {name} of type {typeof(T).ToString().Col(Color.Orchid)} in parent {parnt}");
                return null;
            }
        }

        public static string PrintArray<T>(IEnumerable<T> array, string divide = "\n")
        {
            if (array != null)
                return string.Join(divide, array.Select((v, i) => $"[{i}]: {v}"));
            else return "Array is null!";
        }

        public static string PrintDictionary<T1, T2>(Dictionary<T1, List<T2>> dict, string div = "\n")
        {
            var ol = dict.Select(kvp => $"{div}[{kvp.Key}] : {PrintArray(kvp.Value, ", ")}").ToList();

            return PrintArray(ol);
        }

        public static void ManageEnum<TEnum>(Action<TEnum> handler) where TEnum : Enum
        {
            for (int i = 0; i < Enum.GetValues(typeof(TEnum)).Length; i++)
            {
                TEnum element = (TEnum) Enum.GetValues(typeof(TEnum)).GetValue(i);
                handler.Invoke(element);
            }
        }

        public static void ManageEnum<TEnum>(Action<TEnum, int> handler) where TEnum : Enum
        {
            for (int i = 0; i < Enum.GetValues(typeof(TEnum)).Length; i++)
            {
                TEnum element = (TEnum) Enum.GetValues(typeof(TEnum)).GetValue(i);
                handler.Invoke(element, i);
            }
        }

        public static int ChooseProb(List<int> probs)
        {
            float total = 0;

            probs.ForEach(v => total += v);

            float randomPoint = UnityEngine.Random.Range(0, total);

            for (int i = 0; i < probs.Count; i++)
            {
                if (randomPoint < probs[i])
                {
                    //Debug.Log($"Choosed Unit: {(UnitType)i}");
                    return i;
                }

                randomPoint -= probs[i];
            }

            return 0;
        }

        public static void DestroyScripts<T>(GameObject gameObject) where T : Component =>
            gameObject.GetComponentsInChildren<T>().ToList().ForEach(s => Object.Destroy(s));

        public static void CgControl(CanvasGroup canvasGroup, bool b, bool objectToo = false)
        {
            canvasGroup.alpha = b ? 1 : 0;
            canvasGroup.interactable = b;
            canvasGroup.blocksRaycasts = b;
            if (objectToo)
                canvasGroup.gameObject.SetActive(b);
        }

        public static void TryGetValue(string s, Action<float> onSuccess)
        {
            if (string.IsNullOrEmpty(s))
                return;

            float xValue = 0;
            if (float.TryParse(s, out xValue))
            {
                onSuccess?.Invoke(xValue);
            }
        }

        public static List<T> Unwrap<T>(List<List<T>> allColls)
        {
            var outp = new List<T>();
            allColls.ForEach(v => outp.AddRange(v));

            return outp;
        }


        public static int Get3dCoord(int x, int y, int z, int i, int j, int k) =>
            i * y * z + j * z + k;

        public static float SineMove(float min, float max, float t) =>
            Mathf.Lerp(min, max, Mathf.Sin(Mathf.Lerp(0, 180, t) * Mathf.Deg2Rad));

        public static char Sep => _sep ??= Path.DirectorySeparatorChar;
    }
}