namespace NeuralNetwork
{
	public class DataSet
	{
		public double[] Input { get; set; }

		public double[] Output { get; set; }

		public DataSet(double[] input, double[] output)
		{
			Input = input;
			Output = output;
		}
	}
}
