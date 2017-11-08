using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_13
{
  // This class is used for implementation of the first criterion
  // using the Strategy pattern.
  class Criterion1:IStrategy
  {
    Programmist junior = new Programmist(95, 120, "junior");
    Programmist middle = new Programmist(380, 420, "middle");
    Programmist senior = new Programmist(900, 900, "senior");
    Programmist lead = new Programmist(2250, 2000, "lead");
    int summa;
    int RequestedSumma { get; set; }
    public Criterion1(int summa)
    {
      this.summa = summa;
    }
    public Programmist[] Algorithm()
    {
      int performance = 0;
      RequestedSumma = 0;
      Programmist[] team = { junior, middle, senior, lead };
      Sort(team);
      if (summa < team[0].Salary)
      {
        return null;
      }
      for (int i = 0; i < team.Length; i++)
      {
        team[i].Count = (summa - RequestedSumma) / team[i].Salary;
        RequestedSumma += team[i].Count * team[i].Salary;
        performance += team[i].Count * team[i].Performance;
      }
      return team;
    }
    // this method is used for sort the members of team
    // according of their efficiency.
    public void Sort(Programmist[] team)
    {
      bool flag = true;
      while (flag)
      {
        flag = false;
        for (int i = 0; i < team.Length - 1; i++)
        {
          if (team[i].Efficiency < team[i + 1].Efficiency) // a b c
          {
            var buf = team[i];
            team[i] = team[i + 1];
            team[i + 1] = buf;
            flag = true;
          }
        }
      }
    }
  }
}
