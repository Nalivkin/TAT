using System;

namespace DEV_10
{
	//This class is used for output the different sorts
	//of arrays.
	class Outputer
	{
		//This method is used for output the 2-dimension array.
		public void Output(double[][] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
				{
					Console.Write(String.Format("{0:f4}", array[i][j]) + " ");
				}
				Console.Write("\n");
			}
		}

		//This method is used for output the 1-dimension array.
		public void Output(double[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write(String.Format("{0:f4}", array[i]) + " ");
			}
		}
	}
}
