using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RoboKent
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J59HL2O\\SQLEXPRESS;Initial Catalog=Robokent;Integrated Security=True");
            baglanti.Open();
            return baglanti;
    }

    }
}
