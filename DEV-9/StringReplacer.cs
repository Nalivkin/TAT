using System;

namespace DEV_9
{
   //this class is used for operate with string, particularly
   //to replace the parts of strings.
  class StringReplacer
    {
	  public string SourceString { get; set; }
	  public string DestinationString { get; set; }
	  Random rand = new Random();
    // if any string is empty, constructor will return an exception.
      public StringReplacer(string sourceString, string destinationString)
        {
            if (sourceString.Length == 0 || destinationString.Length == 0)
            {
                throw new EmptyStringException();
            }
            SourceString = sourceString;
            DestinationString = destinationString;
        }
    // this method is used for replace the parts of strings.
      public string Replace()
        {
		  int[] index = GetIndexesOfStart(SourceString.Length, DestinationString.Length);
		  int[] length = GetLengthesOfParts(SourceString.Length, DestinationString.Length, index);
          string resultOfReplace = DestinationString.Remove(index[1], length[1]);
		  resultOfReplace = resultOfReplace.Insert(index[1], SourceString.Substring(index[0], length[0]));
          return resultOfReplace;
        }

	  // this method is used for randomly calculate the index in strings,
	  // from which we will take the symbols to replace, and where we will
	  // replace them.
	  private int[] GetIndexesOfStart(int sourceStringLength,int destinationStringLength)
	  {
		  int[] indexes = new int[2];
		  indexes[0] = rand.Next(sourceStringLength);
		  indexes[1] = rand.Next(destinationStringLength);
		  return indexes;
	  }
	  // this method is used for randomly calculate the lengthes 
	  // of parts we will replace.
	  private int[] GetLengthesOfParts(int sourceStringLength, int destinationStringLength, int[] indexesOfStart)
	  {
		  int[] lengthes = new int[2];
		  lengthes[0] = rand.Next(1, sourceStringLength - indexesOfStart[0]);
		  lengthes[1] = rand.Next(1, destinationStringLength - indexesOfStart[1]);
		  return lengthes;
	  }
		
    }
}
