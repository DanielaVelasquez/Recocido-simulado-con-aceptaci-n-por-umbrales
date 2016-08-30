using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatedAnneling.Model.SimulatedAnneling;

namespace SimulatedAnneling.Model.TravelerSalesmanProblem
{
    public class Tour: ISolution
    {
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
