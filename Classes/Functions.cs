using System;
using System.Drawing;

namespace Graph_Converter.Classes
{
    interface IFunctionGraphPoints
    {
        Point[] GetGraphPoints(int boxWidth);
    }
    abstract class Functions : IFunctionGraphPoints
    {
        abstract public Point[] GetGraphPoints(int boxWidth);
    }
    class Sinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                functionPoints[i] = new Point(i + 32, (int)(Math.Sin((double)i / 10) * 100 + 120));
            }
            return functionPoints;
        }
    }
    class Cosinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                functionPoints[i] = new Point(i + 32, (int)(Math.Cos((double)i / 10) * 100 + 120));
            }
            return functionPoints;
        }
    }
    class SquareRoot : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                functionPoints[i] = new Point(i + 32, (int)(Math.Sqrt((double)i * 10)) + 120);
            }
            return functionPoints;
        }
    }
}
