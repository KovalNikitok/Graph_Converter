using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graph_Converter.Classes
{
    interface IQuantization
    {
        int QuantizationThresold { get; }
        List<int> GetQuantizationOfFunction();
        void DrawQuantizationLevels(Graphics g, int width);
    }
    class Quantization : IQuantization
    {
        private readonly int height;
        private readonly int startX;
        private readonly int quantizationLevels;
        public Quantization(Point startPoint, int quantizationLevels)
        {
            height = startPoint.Y;
            startX = startPoint.X;
            // Если пользователь задаёт количество уровней квантования 1 или меньше, то берём стандартное значение (2)
            this.quantizationLevels = quantizationLevels;//quantizationLevels <= 1 ? 2 : quantizationLevels;
        }

        public int QuantizationThresold
        {
            get => Convert.ToInt32(Math.Ceiling((double)(height / quantizationLevels))) - 1;
        }

        public List<int> GetQuantizationOfFunction()
        {
            List<int> quantizationOfFunction = new List<int>(quantizationLevels);
            if (quantizationLevels > 0)
            {
                int quantingStage = QuantizationThresold;

                for (int i = height - quantingStage; i > 1; i -= quantingStage)
                {
                    quantizationOfFunction.Add(i);
                }
            }
            return quantizationOfFunction;
        }

        public void DrawQuantizationLevels(Graphics g, int width)
        {
            if (quantizationLevels > 0)
            {
                List<int> quantizationOfFunction = GetQuantizationOfFunction();
                Pen black = new Pen(Color.Black);

                for (int i = 0; i < quantizationOfFunction.Count; i++)
                {
                    g.DrawLine(black, new Point(startX, quantizationOfFunction[i]), new Point(width, quantizationOfFunction[i]));
                }
            }
        }
    }
}
