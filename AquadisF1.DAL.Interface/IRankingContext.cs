using System;
using System.Collections.Generic;
using System.Text;
using AquadisF1.Model.Models;

namespace AquadisF1.DAL.Interface
{
    public interface IRankingContext : IContext<Ranking>
    {
        string kektus(string kek);
    }
}
