using System.Drawing;

namespace Graph_Converter.Classes
{
    class Selectors
    {
        public static string QuantizationLevelRadioSelector(string text)
        {
            switch (text)
            {
                case "По нижнему":
                    {
                        return "lesser";
                    }
                case "По среднему":
                    {
                        return "medium";
                    }
                default:
                    {
                        return "higher";
                    }
            }
        }
        public static QuantizationByLevels SelectionQuantization(string text, Point[] points, Quantization quantization, Sampling sampling)
        {
            switch (text)
            {
                case "lesser":
                    {
                        return new ClosestFromBelowLevel(points, quantization, sampling);
                    }
                case "medium":
                    {
                        return new ClosestFromAverageLevel(points, quantization, sampling);
                    }
                default:
                    {
                        return new ClosestFromAboveLevel(points, quantization, sampling);
                    }
            }
        }
        public static Functions GraphOfFunctionRadioSelector(string text)
        {
            switch (text)
            {
                case "Синусоида":
                    {
                        return new Sinusoid();
                    }
                case "Косинусоида":
                    {
                        return new Cosinusoid();
                    }
                default:
                    {
                        return new SquareRoot();
                    }
            }
        }
    }
}
