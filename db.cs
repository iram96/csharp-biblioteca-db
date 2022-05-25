using System.Data.SqlClient;

namespace csharp_biblioteca_db
{
    internal class db
    {
        private static string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";



        //Mi connetto al db
        private static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(stringaDiConnessione);

            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return conn;


        }

        internal static int libroAdd(Libro libro)
        {
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("unable to connect to db");
            }
            //"insert into Scaffale (Scafflae) values ('aaa')"

            var cmd = String.Format("insert into Libri (Scaffale) values ('{0}')", libro);


            using (SqlCommand insert = new
                 SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    return numrows;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }

            }

        }

        //Aggiungo al db

        internal static int ScaffaleAdd(string s1)
        {
            //collegarmi al db e inviare un comando di insert nel nuovo scaffale
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("unable to connect to db");
            }
            //"insert into Scaffale (Scafflae) values ('aaa')"

            var cmd = String.Format("insert into Scaffale (Scaffale) values ('{0}')", s1);


            using (SqlCommand insert = new
                 SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    return numrows;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }

            }

        }

        internal static List<string> scaffaliGet()
        {
            List<string> scaffaliList = new List<string>();


            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("unable to connect to db");
            }
            //"insert into Scaffale (Scafflae) values ('aaa')"

            var cmd = String.Format("select Scaffale from Scaffale");


            using (SqlCommand select = new
                 SqlCommand(cmd, conn))
            {
                using (SqlCommand query = new SqlCommand(cmd, conn))
                {
                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);
                        while (reader.Read())
                        {
                            scaffaliList.Add(reader.GetString(0));

                            //for (int i = 0; i < reader.FieldCount; ++i)
                            //    Console.Write("{0}, ", reader[i]);
                            //Console.WriteLine();
                        }
                    }
                }

            }
            conn.Close();
            return scaffaliList;


        }

        //nel caso ci siano più attributi, allora potete utilizzare le tuple
        internal static List<Tuple<int, string, string, string, string, string>> documentiGet()
        {
            var ld = new List<Tuple<int, string, string, string, string, string>>();
            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");
            var cmd = String.Format("select codice, Titolo, Settore, Stato, Tipo, Scaffale from Documenti");  //Li prendo tutti
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Tuple<Int32, string, string, string, string, string>(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5));
                        ld.Add(data);
                    }
                }
            }
            conn.Close();
            return ld;
        }
    }
}