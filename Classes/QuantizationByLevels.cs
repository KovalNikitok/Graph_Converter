using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace Graph_Converter.Classes
{
    interface IQuantizationByLevels
    {
        FunctionPointFromQuantization[] GetQuantizationFunctionByLevels();
        void DrawQuantizationOfFunction(Graphics g);
        bool IsShiftByQuantizationLevel(Point firstPoint, Point secondPoint);
        bool IsShiftByQuantizationLevel(int firstY, int secondY);
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
        public abstract void DrawQuantizationOfFunction(Graphics g);
        public abstract FunctionPointFromQuantization[] GetQuantizationFunctionByLevels();
        public abstract bool IsShiftByQuantizationLevel(Point firstPoint, Point secondPoint);
        public abstract bool IsShiftByQuantizationLevel(int firstY, int secondY);
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
        public void FindQuantizationLevel(List<int> quantizationLevels, int quantizationThresold, int shiftByThresold)
        {
            this.QuantizationLevel = quantizationLevels.Find(elem => elem + quantizationThresold + shiftByThresold >= functionPoint.Y &&
                                                                elem + shiftByThresold <= functionPoint.Y);
        }
    }

    class QuantizationBySomeLevel : QuantizationByLevels
    {
        protected List<int> quantizationLevels;
        public QuantizationBySomeLevel(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
            : base(functionPoints, funcQuantization, funcSampling)
        {
            quantizationLevels = funcQuantization.GetQuantizationOfFunction();
        }
        public override bool IsShiftByQuantizationLevel(Point firstPoint, Point secondPoint)
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
        public override bool IsShiftByQuantizationLevel(int firstY, int secondY)
        {
            int first = quantizationLevels.Find(
                elem => elem + funcQuantization.QuantizationThresold > firstY && elem <= firstY);
            int second = quantizationLevels.Find(
                elem => elem + funcQuantization.QuantizationThresold > secondY && elem <= secondY);
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
            List<FunctionPointFromQuantization> quantizationFunc = new List<FunctionPointFromQuantization>(funcSampling.Levels);
            for (int i = 1; i < functionPoints.Length; i++)
            {
                if (IsShiftByQuantizationLevel(functionPoints[i - 1], functionPoints[i]))
                {
                    quantizationFunc.Add(new FunctionPointFromQuantization(functionPoints[i]));
                }
            }
            return quantizationFunc.ToArray();
        }
        public override void DrawQuantizationOfFunction(Graphics g)
        {

        }
    }
    class ClosestFromBelowLevel : QuantizationBySomeLevel
    {
        public ClosestFromBelowLevel(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
            : base(functionPoints, funcQuantization, funcSampling)
        {
        }
        public override void DrawQuantizationOfFunction(Graphics g)
        {
            FunctionPointFromQuantization[] closestFromBelow = GetQuantizationFunctionByLevels();
            if (closestFromBelow.Length > 1)
            {
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
                nextY = functionPoints[0].Y > closestFromBelow[0].functionPoint.Y ? nextY + quantizationThresold : nextY;
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
                     new Point(closestFromBelow[closestFromBelow.Length - 1].functionPoint.X, closestFromBelow[closestFromBelow.Length - 1].functionPoint.Y + quantizationThresold),
                     new Point(functionPoints[functionPoints.Length - 1].X, closestFromBelow[closestFromBelow.Length - 1].functionPoint.Y + quantizationThresold)
                 );
            }
        }
    }

    class ClosestFromAboveLevel : QuantizationBySomeLevel
    {
        public ClosestFromAboveLevel(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
            : base(functionPoints, funcQuantization, funcSampling)
        {
        }
        
        public override void DrawQuantizationOfFunction(Graphics g)
        {
            FunctionPointFromQuantization[] closestFromAbove = GetQuantizationFunctionByLevels();
            if (closestFromAbove.Length > 1)
            {
                Pen gPen = new Pen(Color.Red, 2.0f);
                int quantizationThresold = funcQuantization.QuantizationThresold;
                foreach (var item in closestFromAbove)
                {
                    item.FindQuantizationLevel(quantizationLevels, quantizationThresold);
                }
                int nextY = functionPoints[0].Y > closestFromAbove[0].functionPoint.Y
                    ? closestFromAbove[0].QuantizationLevel
                    : closestFromAbove[0].QuantizationLevel - quantizationThresold;

                g.DrawLine(gPen,
                        new Point(closestFromAbove[0].functionPoint.X, nextY),
                        new Point(closestFromAbove[0].functionPoint.X, nextY + quantizationThresold)
                    );
                nextY = functionPoints[0].Y > closestFromAbove[0].functionPoint.Y ? nextY + quantizationThresold : nextY;
                g.DrawLine(gPen,
                    new Point(functionPoints[0].X, nextY),
                    new Point(closestFromAbove[0].functionPoint.X, nextY)
                );

                for (int i = 0; i < closestFromAbove.Length - 1; i++)
                {
                    if (closestFromAbove[i].QuantizationLevel > closestFromAbove[i + 1].QuantizationLevel)
                    {
                        nextY = closestFromAbove[i].QuantizationLevel;
                        //рисуем линию по уровню квантования
                        g.DrawLine(gPen,
                            new Point(closestFromAbove[i + 1].functionPoint.X, closestFromAbove[i + 1].QuantizationLevel),
                            new Point(closestFromAbove[i + 1].functionPoint.X, nextY)
                        );
                        //соединяем текущий уровень с предыдущим
                        g.DrawLine(gPen, new Point(closestFromAbove[i].functionPoint.X, nextY), new Point(closestFromAbove[i + 1].functionPoint.X, nextY));
                    }
                    else if (closestFromAbove[i].QuantizationLevel < closestFromAbove[i + 1].QuantizationLevel)
                    {
                        nextY = closestFromAbove[i].QuantizationLevel;
                        //рисуем линию по уровню квантования
                        g.DrawLine(gPen,
                            new Point(closestFromAbove[i + 1].functionPoint.X, closestFromAbove[i + 1].QuantizationLevel),
                            new Point(closestFromAbove[i + 1].functionPoint.X, nextY)
                        );
                        //соединяем текущий уровень с предыдущим
                        g.DrawLine(gPen, new Point(closestFromAbove[i].functionPoint.X, nextY), new Point(closestFromAbove[i + 1].functionPoint.X, nextY));
                    }
                }
                g.DrawLine(gPen,
                    new Point(closestFromAbove[closestFromAbove.Length - 1].functionPoint.X, closestFromAbove[closestFromAbove.Length - 1].functionPoint.Y),
                    new Point(functionPoints[functionPoints.Length - 1].X, closestFromAbove[closestFromAbove.Length - 1].functionPoint.Y)
                );
            }
        }
    }
    class ClosestFromAverageLevel : QuantizationBySomeLevel
    {
        public ClosestFromAverageLevel(Point[] functionPoints, Quantization funcQuantization, Sampling funcSampling)
            : base(functionPoints, funcQuantization, funcSampling)
        {

        }
        private Point[] GetPointsOfAverageQuantization()
        {
            int halfOfQuantizationStage = funcQuantization.QuantizationThresold / 2;
            List<int> quantizationLevels = funcQuantization.GetQuantizationOfFunction().
                    Select(elem => elem + halfOfQuantizationStage).ToList();
            quantizationLevels.Add(halfOfQuantizationStage);
            List<Point> result = new List<Point>();
            Point repeatPoint = new Point();
            var temp = functionPoints.Select(elem => elem.Y);
            int maxY = temp.Max();
            int minY = temp.Min();
            foreach (var elem in functionPoints)
            {
                if (quantizationLevels.Any(item => item + 4 >= elem.Y && item - 4 <= elem.Y))
                {
                    if (result.Count() == 0)
                        result.Add(elem);
                    else
                    {
                       // Баг с неправильной обработкой переходов сверху вниз, при нахождении на одном уровне квантования
                        Point lastAddedPoint = result[result.Count() - 1];
                        repeatPoint = elem;
                        if (IsShiftByQuantizationLevel(lastAddedPoint, repeatPoint) 
                            // TODO:
                            /*|| шило на мыло :/
                            IsShiftByQuantizationLevel(elem.Y, maxY) ||
                            IsShiftByQuantizationLevel(elem.Y, minY)
                            */
                           )
                        {
                            result.Add(elem);
                        }
                    }
                }
            }
            return result.ToArray();
        }
        private int GetQuantizationLevel(int y, List<int> levels, int stage) => 
            levels.Find(elem => y + stage > elem && y < elem) - stage;
        public override void DrawQuantizationOfFunction(Graphics g)
        {
            FunctionPointFromQuantization[] allPoints = GetQuantizationFunctionByLevels();
            foreach (var elem in allPoints)
            {
                elem.FindQuantizationLevel(quantizationLevels, funcQuantization.QuantizationThresold);
            }
            {
                if (allPoints.Length > 1)
                {
                    var POINTS = GetPointsOfAverageQuantization();
                    Pen gPen = new Pen(Color.Red, 2.0f);
                    List<int> levels = new List<int>
                    {
                        funcQuantization.GetQuantizationOfFunction().Max() + funcQuantization.QuantizationThresold
                    }; 
                    levels.AddRange(funcQuantization.GetQuantizationOfFunction());
                    levels.Add(0);

                    var stage = funcQuantization.QuantizationThresold;
                    int firstY = 0;
                    int secondY = 0;
                    g.DrawLine(gPen,
                         new Point(functionPoints[0].X, GetQuantizationLevel(POINTS[0].Y, levels, stage)),
                         new Point(POINTS[0].X, GetQuantizationLevel(POINTS[0].Y, levels, stage))
                    );
                    for (int i = 0; i < POINTS.Length; i++)
                    {
                        if (i > 0)
                        {
                            if (POINTS[i - 1].Y > POINTS[i].Y) // предыдущий ниже текущего
                            {
                                g.DrawLine(gPen,
                                    new Point(POINTS[i].X, secondY - stage),
                                    new Point(POINTS[i - 1].X, secondY - stage)
                                );
                            }
                            else if (POINTS[i - 1].Y < POINTS[i].Y) // предыдущий выше текущего
                            {
                                g.DrawLine(gPen,
                                    new Point(POINTS[i].X, secondY),
                                    new Point(POINTS[i - 1].X, secondY)
                                );
                            }
                        }
                        firstY = GetQuantizationLevel(POINTS[i].Y, levels, stage);
                        secondY = GetQuantizationLevel(POINTS[i].Y + stage, levels, stage);
                        if (secondY < 0) secondY = 240;
                        if (secondY > 240) secondY = 0;
                        g.DrawLine(gPen,
                            new Point(POINTS[i].X, firstY),
                            new Point(POINTS[i].X, secondY)
                        );
                    }
                    g.DrawLine(gPen,
                         new Point(POINTS[POINTS.Length - 1].X, secondY),
                         new Point(functionPoints[functionPoints.Length - 1].X, secondY)
                    );
                } 
            }
        }
    }
}