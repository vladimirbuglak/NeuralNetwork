using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetwork
{
	public class Layer1
	{
		public Vector<double> Neurons { get; set; }

		public Matrix<double> Weights { get; set; }

		public int Number { get; set; }

		public IActivationFunction ActivationFunction { get; set; } = new SigmoidActivationFunction();

		public Layer1(int number, int numberInNextLayer)
		{
			Number = number;

			Neurons = new DenseVector(number);

			Weights = new DenseMatrix(number, numberInNextLayer);

			RandomizeWeights();

		}

		public Layer1(int number)
		{
			Number = number;

			Neurons = new DenseVector(number);
		}

		private void RandomizeWeights()
		{
			var random = new Random();

			for (int i = 0; i < Weights.RowCount; i++)
			{
				for (int j = 0; j < Weights.ColumnCount; j++)
				{
					Weights[i, j] = random.NextDouble() * 2 - 1;
				}
			}
		}

		public Vector<double> GetOutPut()
		{
			if (Weights == null)
			{
				return Neurons;
			}

			return (Neurons * Weights).Map(x => ActivationFunction.GetOutput(x + 1));
		}

		public void SetUpNeurons(double[] values)
		{
			Neurons.SetValues(values);
		}

		public void SetUpNeurons(Vector<double> values)
		{
			Neurons = values;
		}
	}
}
