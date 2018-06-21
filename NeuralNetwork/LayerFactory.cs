using System.Collections.Generic;

namespace NeuralNetwork
{
    public class LayerFactory
    {
        public Layer CreateLayer(int numberOfNeurons, IActivationFunction activationFunction)
        {
            var layer = new Layer();

            for (var i = 0; i < numberOfNeurons; i++)
            {
                var neuron = new Neuron(activationFunction);
                layer.Neurons.Add(neuron);
            }

            return layer;
        }

        public Layer CreateInputLayer(int numberOfNeurons, List<double> values)
        {
            var layer = new Layer();

            for (var i = 0; i < numberOfNeurons; i++)
            {
                var neuron = new InPutNeuron(values[i]);
                layer.Neurons.Add(neuron);
            }

            return layer;
        }
    }
}
