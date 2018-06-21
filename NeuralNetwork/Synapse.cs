using System;

namespace NeuralNetwork
{
    public interface ISynapse
    {
        double Weight { get; set; }

        INeuron StartNeuron { get; set; }

        INeuron EndNeuron { get; set; }
    }

    public class Synapse : ISynapse
    {
        public double Weight { get; set; }

        public INeuron StartNeuron { get; set; }

        public INeuron EndNeuron { get; set; }


        public Synapse(INeuron startNeuron, INeuron endNeuron, double weight)
        {
            StartNeuron = startNeuron;
            EndNeuron = endNeuron;

            Weight = weight;
        }

        public Synapse(INeuron fromNeuraon, INeuron toNeuron)
        {
            StartNeuron = fromNeuraon;
            EndNeuron = toNeuron;

            var tmpRandom = new Random();
            Weight = tmpRandom.NextDouble();
        }
    }
}
