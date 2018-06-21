using System.Collections.Generic;

namespace NeuralNetwork
{
    public class InPutNeuron : INeuron
    {
        public List<ISynapse> Inputs { get; set; }
        public List<ISynapse> Outputs { get; set; }

        private double Value { get; set; }

        public InPutNeuron(double value)
        {
            Value = value;
        }

        public double GetOutput()
        {
            return Value;
        }

        public void AddInputNeuron(INeuron inputNeuron)
        {
        }

        public void AddOutputNeuron(INeuron outputNeuron)
        {
            var synapse = new Synapse(this, outputNeuron);
            Outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }
    }
}
