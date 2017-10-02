using System;
using System.Collections.Generic;

namespace DEV_10
{
	//This class is used for initilize and operate with
	//multidimensional arrays.
	class MultidimensionalArray
	{
		const double EPSILON = 10e-5;
		public double[][] Array { get; set; }
		
		//Multiple constructors to initialize the object
		//with different ways.
		public MultidimensionalArray()
		{
			Array = null;
		}
		public MultidimensionalArray(double[][] array)
		{
			Array = array;
		}
		public MultidimensionalArray(int size)
		{
			Array = CreateArray(size);
		}
		
		//This method is used for randomly create and initialize
		//the 2-dimension array.
		public double[][] CreateArray(int size)
		{
			Random rand = new Random();
			double[][] arrays = new double[size][];
			for (int i = 0; i < arrays.Length; i++)
				arrays[i] = new double[rand.Next(1, 10)];
			for (int i = 0; i < arrays.Length; i++)
			{
				for (int j = 0; j < arrays[i].Length; j++)
					arrays[i][j] = rand.NextDouble();
			}
			return arrays;
		}
		
		//This method returns the result of searching in
		//multidimensional array non-unique elements.
		public double[] MergeNonUniqueElements()
		{
			List<double> resultList = new List<double>();
			for (int compareIndexI = 0; compareIndexI < Array.Length; compareIndexI++)
			{
				for (int compareIndexJ = 0; compareIndexJ < Array[compareIndexI].Length; compareIndexJ++)
				{
					for (int i = compareIndexI + 1; i < Array.Length; i++)
					{
						for (int j = 0; j < Array[i].Length; j++)
						{
							if (Math.Abs(Array[i][j] - Array[compareIndexI][compareIndexJ]) < EPSILON && i != compareIndexI && j != compareIndexJ)
							{
								bool flag = true;
								for (int check = 0; check < resultList.Count; i++)
								{
									if (Array[i][j] == resultList[check])
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									resultList.Add(Array[compareIndexI][compareIndexJ]);
									break;
								}
							}
						}
					}
				}
			}
			double[] result = new double[resultList.Count];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = resultList[i];
			}
			return result;
		}
	}
}
