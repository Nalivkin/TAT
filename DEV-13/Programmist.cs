using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  public class Programmist
  {
    public int Performance{get; private set;}
    public int Salary { get; private set; }
    public string Type { get; private set; }
    public float Efficiency { get; private set; }
    public int Count { get; set; }
    public Programmist(int performance, int salary, string type)
    {
      Performance = performance;
      Salary = salary;
      Type = type;
      Efficiency = Performance / (float)Salary;
    }
  }
}
