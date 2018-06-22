using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace NeuralNetwork
{
	public class NeuralNetwork1
	{
		private List<Layer1> Layers { get; set; }

		public NeuralNetwork1()
		{
			Layers = new List<Layer1>();
		}

		public void AddLayer(Layer1 layer)
		{
			Layers.Add(layer);
		}

		public Vector<double> GetOutput()
		{
			for (int i = 0; i < Layers.Count; i++)
			{
				var result = Layers[i].GetOutPut();

				if (i + 1 < Layers.Count)
				{
					Layers[i + 1].SetUpNeurons(result);
				}
			}

			return Layers.Last().GetOutPut();
		}

		public void SetUpInput(double[] input) 
		{
			Layers.First().SetUpNeurons(input);
		}

		public void Train(DataSet dataSet)
		{
			double totalError = 0;

			for (int i = 0; i < 30; i++)
			{
				SetUpInput(dataSet.Input);

				var output = GetOutput();

				totalError = CalculateTotalError(output.ToArray(), dataSet.Output);
			}
		}

		private double CalculateTotalError(double[] output, double[] expected)
		{
			return output.Select((t, i) => Math.Pow(t - expected[i], 2)).Sum();
		}
	}
}
