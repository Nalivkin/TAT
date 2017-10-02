using System;

namespace DEV_10
{
	//The point where program starts.
	class EntryPoint
	{
		static void Main(string[] args)
		{
			MultidimensionalArray array = new MultidimensionalArray(5);
			new Outputer().Output(array.Array);
			double[] result = array.MergeNonUniqueElements();
			Console.Write("Result is: ");
			new Outputer().Output(result);
			Console.ReadKey(true);
		}
	}
}