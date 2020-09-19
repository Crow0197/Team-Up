using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Up.DAL.EF
{
    public class RepositoryConfig : IRepositoryConfig
    {
        public string GetOne(string idSearch)
        {
            var configValue = "";

            TeamUpContext dbConfig = new TeamUpContext();

            configValue = dbConfig.Database.SqlQuery<string>("SELECT TOP (1)  [value]  FROM [ConfigSystem]  where nome ='" + idSearch  + "'").FirstOrDefault();
           

            return configValue;
        }
    }
}
