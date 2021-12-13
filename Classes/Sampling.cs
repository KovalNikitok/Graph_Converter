using System;
using System.Collections.Generic;
using System.Drawing;

namespace Graph_Converter.Classes
{
    interface ISampling
    {
        int Levels { get; }
        int[] SamplingDecompose(Point startPoint, Point[] functionPoints, List<int> quantizationOfFunction);
    }
    sealed class Sampling : ISampling
    {
        private readonly int width;
        private readonly float samplingLevel;
        private readonly int quantizationLevels;

        public Sampling(int width, float samplingLevel, int quantizationLevels)
        {
            this.width = width;
            this.samplingLevel = samplingLevel;
            this.quantizationLevels = quantizationLevels;
        }
        public int Levels
        {
            get => Convert.ToInt32(Math.Ceiling(quantizationLevels / samplingLevel));
        }
        public int[] SamplingDecompose(Point startPoint, Point[] functionPoints, List<int> quantizationOfFunction)
        {
            int samplingStage = (int)(width * samplingLevel);
            int[] samplingDecompose = new int[Levels];

            for (int i = samplingStage, n = 0; i < width; i += samplingStage, n++)
            {
                // Уровень квантования для данной точки графика находится в рамках от firstIndex = IndexOf(elem) до secondIndex = firstIndex + 1
                samplingDecompose[n] = quantizationOfFunction.IndexOf(quantizationOfFunction.Find(elem => elem <= functionPoints[i].Y));
            }
            return samplingDecompose;
        }
        public void DrawSampling(Graphics g, int[] samplingDecompose, List<int> quantizationOfFunction, int QuantizationThresold)
        {
            int samplingStage = (int)(width * samplingLevel);

            for (int i = samplingStage, n = 0; i < width; i += samplingStage, n++)
            {
                // Уровень квантования для данной точки графика находится в рамках от firstIndex = IndexOf(elem) до secondIndex = firstIndex + 1
                g.DrawLine(new Pen(Color.BlueViolet, 2.0f),
                    new Point(i + 32, quantizationOfFunction[samplingDecompose[n]] + QuantizationThresold),
                    new Point(i + 32, quantizationOfFunction[samplingDecompose[n]])
                );
            }
        }
    }
}
