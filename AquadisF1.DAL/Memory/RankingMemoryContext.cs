using System;
using System.Collections.Generic;
using System.Text;
using AquadisF1.DAL.Interface;
using AquadisF1.Model.Models;

namespace AquadisF1.DAL.Memory
{
    public class RankingMemoryContext : IRankingContext
    {
        public bool Create(Ranking entity)
        {
            return true;
        }

        public Ranking Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ranking entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string kektus(string kek)
        {
            throw new NotImplementedException();
        }
    }
}
