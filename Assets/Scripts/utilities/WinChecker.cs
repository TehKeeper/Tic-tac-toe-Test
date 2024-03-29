﻿using System.Linq;
using Unity.Mathematics;

namespace utilities
{
    public static class WinChecker
    {
        private static int2[] _diag;
        private static int2[] _diag2;
        private const int CellCnt = 3;
        public static int2[] Row(int2 c) => Enumerable.Range(0, CellCnt).Select(x => new int2(x, c.y)).ToArray();
        public static int2[] Column(int2 c) => Enumerable.Range(0, CellCnt).Select(y => new int2(c.x, y)).ToArray();
        public static int2[] Diag() => _diag ??= Enumerable.Range(0, CellCnt).Select(x => new int2(x, x)).ToArray();

        public static int2[] Diag2() => _diag2 ??= Enumerable.Range(0, CellCnt).Select(x => new int2(CellCnt - 1 - x, x)).ToArray();
    }
}