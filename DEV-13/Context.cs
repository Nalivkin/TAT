using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  public class Context
  {
    public IStrategy Strategy { get; set; }

    public Context(IStrategy strategy)
    {
      this.Strategy = strategy;
    }

    public Programmist[] ExecuteAlrgorithm()
    {
      return Strategy.Algorithm();
    }
  }
}
