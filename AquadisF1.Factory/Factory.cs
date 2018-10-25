using System;
using System.Collections.Generic;
using AquadisF1.DAL.Memory;
using AquadisF1.DAL.MSSQL;
using AquadisF1.Logic;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Enums;

namespace AquadisF1.Factory
{
    public class Factory
    {
        private Dictionary<Engine, string> _connectionStrings;

        public Factory(Dictionary<Engine, string> connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }
        
        public IAccountLogic GetAccountLogic(Engine engine)
        {
            switch (engine)
            {
                case Engine.MSSQL:
                    return new AccountLogic(new AccountMSSQLContext(_connectionStrings[engine]));
                case Engine.Memory:
                    return new AccountLogic(new AccountMemoryContext());
                   
                default:
                    throw new NotImplementedException();  
            }
        }

        public IRankingLogic GetRankingLogic(Engine engine)
        {
            switch (engine)
            {
                case Engine.MSSQL:
                    throw new NotImplementedException();
                case Engine.Memory:
                    return new RankingLogic(new RankingMemoryContext());
                default:
                    throw new NotImplementedException();
            }
        }

    }
}