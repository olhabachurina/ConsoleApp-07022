using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppсд07022.context
{
    public  class AppDbcontext
    {
    
        private string connectionString = (@"Server=(localdb)\mssqllocaldb;Database=proba;Trusted_Connection=True;");
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

}
