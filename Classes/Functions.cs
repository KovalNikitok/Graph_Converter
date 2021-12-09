using System;
using System.Drawing;

namespace Graph_Converter.Classes
{
    class Functions
    {
        public Point[] SinusoidFunction(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                functionPoints[i] = new Point(i + 32, (int)(Math.Sin((double)i / 10) * 100 + 120));
            }
            return functionPoints;
        }
    }

}
