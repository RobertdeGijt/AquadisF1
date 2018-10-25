using System;
using System.Collections.Generic;
using System.Text;
using AquadisF1.DAL.Interface;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Models;

namespace AquadisF1.Logic
{
    public class RankingLogic : IRankingLogic
    {
        private readonly IRankingContext _context;

        public RankingLogic(IRankingContext repository)
        {
            _context = repository;
        }

        public bool Create(Ranking entity)
        {
            if (entity.Id > 100)
            {
                return _context.Create(entity);
            }

            return false;
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
