using System;
namespace DEV_9
{
	// the point where program starts.
  class EntryPoint
    {
        static void Main(string[] args)
        {
            string source = "123456789";
            string destination = "qweqweqwe";
            string result = new StringReplacer(source, destination).Replace();
			Console.Write(source + "\n" + destination + "\n" + result);
            Console.ReadKey(true);
        }
    }
    
}

