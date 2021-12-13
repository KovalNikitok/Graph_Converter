using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace Graph_Converter.Classes
{
    interface IQuantizationByLevels
    {
        FunctionPointFromQuantization[] GetQuantizationFunctionByLevels();
        void DrawQuantizationOfFunction(Graphics g);
    }
    abstract class QuantizationByLevels : IQuantizationByLevels
    {
        protected readonly Point[] functionPoints;
        protected readonly Quantization funcQuantization;
        protected readonly Sampling funcSampling;

        public QuantizationByLevels(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
        {
            this.functionPoints = functionPoints;
            this.funcQuantization = funcQuantization;
            this.funcSampling = funcSampling;
        }
        public abstract FunctionPointFromQuantization[] GetQuantizationFunctionByLevels();
        public abstract void DrawQuantizationOfFunction(Graphics g);
    }

    class FunctionPointFromQuantization
    {
        public readonly Point functionPoint;

        public int QuantizationLevel { get; private set; }

        public FunctionPointFromQuantization(Point functionPoints)
        {
            this.functionPoint = functionPoints;
        }
        public void FindQuantizationLevel(List<int> quantizationLevels, int quantizationThresold)
        {
            this.QuantizationLevel = quantizationLevels.Find(elem => elem + quantizationThresold >= functionPoint.Y &&
                                                                elem <= functionPoint.Y);
        }
    }

    class QuantizationByClosestFromBelowLevel : QuantizationByLevels
    {
        private readonly List<int> quantizationLevels;
        public QuantizationByClosestFromBelowLevel(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
            : base(functionPoints, funcQuantization, funcSampling)
        {
            quantizationLevels = funcQuantization.GetQuantizationOfFunction();
        }
        public bool IsShiftByQuantizationLevel(Point firstPoint, Point secondPoint)
        {
            int first = quantizationLevels.Find(
                elem => elem + funcQuantization.QuantizationThresold > firstPoint.Y && elem <= firstPoint.Y);
            int second = quantizationLevels.Find(
                elem => elem + funcQuantization.QuantizationThresold > secondPoint.Y && elem <= secondPoint.Y);
            if (first != -1)
            {
                if (second != -1)
                {
                    return first != second;
                }
            }
            return false;
        }
        public override FunctionPointFromQuantization[] GetQuantizationFunctionByLevels()
        {
            List<FunctionPointFromQuantization> closestFromBelow = new List<FunctionPointFromQuantization>(funcSampling.Levels);
            for (int i = 1; i < functionPoints.Length; i++)
            {
                if (IsShiftByQuantizationLevel(functionPoints[i - 1], functionPoints[i]))
                {
                    closestFromBelow.Add(new FunctionPointFromQuantization(functionPoints[i]));
                }
            }
            return closestFromBelow.ToArray();
        }
        public override void DrawQuantizationOfFunction(Graphics g)
        {
            FunctionPointFromQuantization[] closestFromBelow = GetQuantizationFunctionByLevels();
            Pen gPen = new Pen(Color.Red, 2.0f);
            int maxY = quantizationLevels.Max() + funcQuantization.QuantizationThresold;

            foreach (var item in closestFromBelow)
            {
                item.FindQuantizationLevel(quantizationLevels, funcQuantization.QuantizationThresold);
            }

            int quantizationThresold = funcQuantization.QuantizationThresold;
            int nextY = functionPoints[0].Y > closestFromBelow[0].functionPoint.Y
                ? closestFromBelow[0].QuantizationLevel + quantizationThresold
                : closestFromBelow[0].QuantizationLevel;
            g.DrawLine(gPen,
                    new Point(closestFromBelow[0].functionPoint.X, nextY),
                    new Point(closestFromBelow[0].functionPoint.X, nextY + quantizationThresold)
                );
            nextY = functionPoints[0].Y > closestFromBelow[0].functionPoint.Y ? maxY : nextY;
            g.DrawLine(gPen, 
                new Point(functionPoints[0].X, nextY),
                new Point(closestFromBelow[0].functionPoint.X, nextY)
            );

            for (int i = 0; i < closestFromBelow.Length - 1; i++)
            {
                if (closestFromBelow[i].QuantizationLevel > closestFromBelow[i + 1].QuantizationLevel)
                {
                    nextY = closestFromBelow[i].QuantizationLevel + quantizationThresold;
                    //рисуем линию по уровню квантования
                    g.DrawLine(gPen,
                        new Point(closestFromBelow[i + 1].functionPoint.X, closestFromBelow[i].QuantizationLevel),
                        new Point(closestFromBelow[i + 1].functionPoint.X, nextY)
                    );
                    //соединяем текущий уровень с предыдущим
                    g.DrawLine(gPen, new Point(closestFromBelow[i + 1].functionPoint.X, nextY), new Point(closestFromBelow[i].functionPoint.X, nextY));
                }
                else if (closestFromBelow[i].QuantizationLevel < closestFromBelow[i + 1].QuantizationLevel)
                {
                    nextY = closestFromBelow[i + 1].QuantizationLevel;
                    //рисуем линию по уровню квантования
                    g.DrawLine(gPen,
                        new Point(closestFromBelow[i + 1].functionPoint.X, closestFromBelow[i + 1].QuantizationLevel),
                        new Point(closestFromBelow[i + 1].functionPoint.X, nextY + quantizationThresold)
                    );
                    //соединяем текущий уровень с предыдущим
                    g.DrawLine(gPen, new Point(closestFromBelow[i + 1].functionPoint.X, nextY), new Point(closestFromBelow[i].functionPoint.X, nextY));
                }
            }
            g.DrawLine(gPen,
                new Point(closestFromBelow[closestFromBelow.Length - 1].functionPoint.X, maxY),
                new Point(closestFromBelow[closestFromBelow.Length - 2].functionPoint.X, maxY)
            );
            g.DrawLine(gPen, closestFromBelow[closestFromBelow.Length - 1].functionPoint.X, maxY, functionPoints[functionPoints.Length - 1].X, maxY);
            g.DrawLine(gPen,
                new Point(closestFromBelow[closestFromBelow.Length - 1].functionPoint.X, maxY),
                new Point(functionPoints[functionPoints.Length - 1].X, maxY)
            );
        }
    }
}