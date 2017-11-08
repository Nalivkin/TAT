using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  class EntryPoint
  {
    static void Main(string[] args)
    {
      int summa = 50;
      int productivity = 90;
      Console.Write("Enter the criterion:\n");
      Context context= new Context(null);
      Programmist[] team;
      int criterion;
      while (true)
      {
        try
        {
          criterion = Int32.Parse(Console.ReadLine());
          break;
        }
        catch (FormatException)
        {
          Console.Write("Try to input the criterion one more time!\n");
        }
      }
      switch (criterion)
      {
        case (1):
          context.Strategy = new Criterion1(summa);
          team = context.ExecuteAlrgorithm();
          if (team == null)
          {
            Console.Write("Cant make a team with such money!");
          }
          else
          {
            StringBuilder answer = new StringBuilder();
            foreach (var programmist in team)
            {
              answer.Append(programmist.Type);
              answer.Append(":");
              answer.Append(programmist.Count);
              answer.Append("\n");
            }
            Console.Write(answer);
          }
          break;
        case(2):
          context.Strategy = new Criterion2(productivity);
          team =context.ExecuteAlrgorithm();
          if (team == null)
          {
            Console.Write("Cant make a team with such performance!");
          }
          else
          {
            foreach (var programmist in team)
            {
              Console.Write(programmist.Type + ":" + programmist.Count + "\n");
            }
          }
          break;
        case(3):
          context.Strategy = new Criterion3(productivity);
          team =context.ExecuteAlrgorithm();
          if (team == null)
          {
            Console.Write("Cant make a team with such performance!");
          }
          else
          {
            foreach (var programmist in team)
            {
              Console.Write(programmist.Type + ":" + programmist.Count + "\n");
            }
          }
          break;
        default:
          break;
      }
      Console.ReadKey();
    }
    
  }
}
