using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get; set; }

        public double LearningRate { get; set; }

        public List<double> ExpectedResult { get; set; }

        private LayerFactory LayerFactory { get; set; }

        public NeuralNetwork()
        {
            Layers = new List<Layer>();

            LayerFactory = new LayerFactory();

            LearningRate = 1.5;
        }

        public void AddLayer(Layer newLayer)
        {
            if (Layers.Any())
            {
                var lastLayer = Layers.Last();
                newLayer.ConnectLayers(lastLayer);
            }

            Layers.Add(newLayer);
        }

        public List<double> GetOutput()
        {
            var returnValue = new List<double>();

            Layers.Last().Neurons.ForEach(neuron =>
            {
                returnValue.Add(neuron.GetOutput());
            });

            return returnValue;
        }

        public void SetUpInputs(List<double> inputs)
        {
            var firstLayer = Layers.First();
        }

        public void Train(List<double> inputs, int numberOfEpochs)
        {
            double totalError = 0;

            for (int i = 0; i < numberOfEpochs; i++)
            {
                for (int j = 0; j < inputs.Count; j++)
                {
                    //PushInputValues(inputs[j]);

                    var outputs = new List<double>();

                    // Get outputs.
                    Layers.Last().Neurons.ForEach(x =>
                    {
                        outputs.Add(x.GetOutput());
                    });

                    // Calculate error by summing errors on all output neurons.
                    totalError = CalculateTotalError(outputs, j);
                    //HandleOutputLayer(j);
                    //HandleHiddenLayers();
                }
            }
        }

        private double CalculateTotalError(List<double> outputs, int row)
        {
            double totalError = 0;

            outputs.ForEach(output =>
            {
                var error = Math.Pow(output - ExpectedResult.ElementAt(row), 2);
                totalError += error;
            });

            return totalError;
        }
    }
}
