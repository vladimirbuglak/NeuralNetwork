using System;
using System.Linq;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
			//класс для герерирования случайных чисел
	        var random = new Random();

			//создания первого слоя, первое число - количество нейронов на текущем слое,
	        //второе - количество нейронов на следующем слое
			var l1 = new Layer1(1000, 5000);

			//создание скрытого слоя
			var l2 = new Layer1(5000, 5);

			//создание выходного слоя
			var l3 = new Layer1(5);

			//инициализация нейронной сети
			var network = new NeuralNetwork1();

			//добавление слоев в нейронную сеть
			network.AddLayer(l1);
			network.AddLayer(l2);
			network.AddLayer(l3);
			
			//заполнение входного вектора случайными числами
			network.SetUpInput(Enumerable.Repeat(0, 1000).Select(x => random.NextDouble()).ToArray());

	        //получение выходного вектора
			var result = network.GetOutput();
        }
    }
}
