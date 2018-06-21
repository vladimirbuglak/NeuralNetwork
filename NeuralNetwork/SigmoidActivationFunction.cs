using System;

namespace NeuralNetwork
{
    public interface IActivationFunction
    {
        double GetOutput(double input);
    }

    public class SigmoidActivationFunction : IActivationFunction
    {
        public double GetOutput(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }
    }
}
