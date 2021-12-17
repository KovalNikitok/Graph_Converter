using System;
using System.Drawing;

namespace Graph_Converter.Classes
{
    interface IFunctionGraphPoints
    {
        Point[] GetGraphPoints(int boxWidth, Point startPoint, int coefficient);
    }
    abstract class Functions : IFunctionGraphPoints
    {
        abstract public Point[] GetGraphPoints(int boxWidth, Point startPoint, int coefficient);
    }
    class Sinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth, Point startPoint, int coefficient)
        {
            Point[] functionPoints = new Point[boxWidth];
            int heightShift = startPoint.Y / 2;
            coefficient = coefficient < 1 ? 1 : coefficient > 5 ? 5 : coefficient;
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Sin((double)i / 10) * 20 * coefficient) + heightShift;
                functionPoints[i] = new Point(i + startPoint.X, y > startPoint.Y ? startPoint.Y : y);
            }
            return functionPoints;
        }
    }
    class Cosinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth, Point startPoint, int coefficient)
        {
            Point[] functionPoints = new Point[boxWidth];
            int heightShift = startPoint.Y / 2;
            coefficient = coefficient < 1 ? 1 : coefficient > 5 ? 5 : coefficient;
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Cos((double)i / 10) * 19 * coefficient) + heightShift;
                functionPoints[i] = new Point(i + startPoint.X, y > startPoint.Y ? startPoint.Y : y);
            }
            return functionPoints;
        }
    }
    class SquareRoot : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth, Point startPoint, int coefficient)
        {
            Point[] functionPoints = new Point[boxWidth];
            int heightShift = startPoint.Y / 5;
            coefficient = coefficient < 1 ? 1 : coefficient > 5 ? 5 : coefficient;
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Sqrt(i * coefficient) * 3) + heightShift;
                functionPoints[i] = new Point(i + startPoint.X, y > startPoint.Y ? startPoint.Y : y);
            }
            return functionPoints;
        }
    }
}
