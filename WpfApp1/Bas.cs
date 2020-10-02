using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    class Bas
    {
        public static MySqlConnection Connect = new MySqlConnection("server=localhost; userid = root; password = ; database= radio_bas; port =3360; persistsecurityinfo=true");

        public string log = "SELECT * FROM users where login=";
        public string pas = "SELECT * FROM users where id=";
        public string rol = "SELECT * FROM people WHERE id=";
        public string login = null;
    }
}

