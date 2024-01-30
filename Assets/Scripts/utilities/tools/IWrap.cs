using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities.tools
{
    public interface IWrap
    {
        public string ToJson();

        public dynamic FromJson(string config);
    }

    [Serializable]
    public struct WrapArray<T> : IWrap
    {
        public T[] items;

        public WrapArray(IEnumerable<T> items) => this.items = items.ToArray();
        public WrapArray(params T[] items) => this.items = items.ToArray();

        public static WrapArray<T> UnwrapArray(string cfg) => JsonUtility.FromJson<WrapArray<T>>(cfg);

        public string ToJson() => JsonUtility.ToJson(this);

        public dynamic FromJson(string config) => JsonUtility.FromJson<WrapArray<T>>(config);
    }


    [Serializable]
    public struct Pair<T1, T2> : IWrap
    {
        public T1 a;
        public T2 b;

        public Pair(T1 a, T2 b)
        {
            this.a = a;
            this.b = b;
        }

        public string ToJson() => JsonUtility.ToJson(this);

        public dynamic FromJson(string config) => JsonUtility.FromJson<Pair<T1, T2>>(config);
    }
}