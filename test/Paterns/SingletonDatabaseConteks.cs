using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Entity;

namespace test.Paterns
{
    public class SingletonDatabaseConteks
    {

        private static MarketlerEntities3 dbEntity;
        private SingletonDatabaseConteks()
        {

        }

        public static MarketlerEntities3 getDbConteks()
        {
            if (dbEntity == null)
                dbEntity = new MarketlerEntities3();

            return dbEntity;
        }
    }
}