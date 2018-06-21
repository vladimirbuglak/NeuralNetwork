using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public interface INeuron
    {
        List<ISynapse> Inputs { get; set; }

        List<ISynapse> Outputs { get; set; }

        double GetOutput();

        void AddInputNeuron(INeuron inputNeuron);

        void AddOutputNeuron(INeuron outputNeuron);
    }

    public class Neuron : INeuron
    {
        private IActivationFunction ActivationFunction { get; set; }

        public List<ISynapse> Inputs { get; set; }

        public List<ISynapse> Outputs { get; set; }

        public Neuron(IActivationFunction activationFunction)
        {
            ActivationFunction = activationFunction;

            Inputs = new List<ISynapse>();
            Outputs = new List<ISynapse>();
        }

        public double GetOutput()
        {
            return ActivationFunction.GetOutput(Inputs.Sum(x => x.Weight * x.StartNeuron.GetOutput()));
        }

        public void AddInputNeuron(INeuron inputNeuron)
        {
            var synapse = new Synapse(inputNeuron, this);
            Inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        public void AddOutputNeuron(INeuron outputNeuron)
        {
            var synapse = new Synapse(this, outputNeuron);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }
    }
}
