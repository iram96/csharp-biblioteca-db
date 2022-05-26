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

        /*
        insert into dbo.DOCUMENTI(Codice,Titolo,Settore,Stato,Tipo,Scaffale) 
VALUES(1,'I PROMESSI SPOSI','romanzo','disponibile','LIBRO', 'S001')

        insert into dbo.LIBRI(Codice,NumPagine) 
VALUES(1,300)

        INSERT INTO AUTORI(Nome,Cognome,mail) values ('Alessandro','Manzoni','nd') 

        INSERT INTO AUTORI_DOCUMENTI(codice_autore,codice_documento) 
values(1000,1)

        */


        internal static int LibroAdd(Libro libro, List<Autore> lAutori)
        {
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("unable to connect to db");
            }
            //"insert into Scaffale (Scafflae) values ('aaa')"

            #region DOCUMENTI_SQL

            var cmd = String.Format(@"insert into Documenti (Codice,Titolo,Settore,Stato,Tipo,Scaffale) 
VALUES('{0}', '{1}', '{2}', '{3}', 'LIBRO', '{4}')", libro.Codice, libro.Titolo, libro.Settore, libro.Stato.ToString(), libro.Scaffale);


            using (SqlCommand insert = new
                 SqlCommand(cmd, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();

                    if (numrows != 1)
                        throw new System.Exception("Valore errato");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn.Close();
                    return 0;
                }

            }
            #endregion

            #region LIBRI_SQL

            var cmd1 = String.Format(@"insert into Libri (Codice,NumPagine) 
VALUES('{0}','{1}')", libro.Codice, libro.NumeroPagine);

            using (SqlCommand insert = new
                 SqlCommand(cmd1, conn))
            {
                try
                {
                    var numrows = insert.ExecuteNonQuery();
                    if (numrows != 1)
                        throw new System.Exception("Valore errato seconda query");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    conn.Close();
                    return 0;
                }

            }
            #endregion

            #region AUTORI_SQL

            string cmd2;
            foreach (Autore aut in lAutori)
            {

                cmd2 = String.Format(@"INSERT INTO Autori (Codice, Nome, Cognome, mail) values ('{0}','{1}','{2}', '{3}')", aut.CodiceAutore, aut.Nome, aut.Cognome, aut.Mail);

                using (SqlCommand insert = new
                     SqlCommand(cmd2, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();
                        if (numrows != 1)
                            throw new System.Exception("Valore errato seconda query");


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        conn.Close();
                        return 0;
                    }

                }
            }

            #endregion

            #region AUTORI_DOCUMENTI_SQL

            string cmd3;
            foreach (Autore aut in lAutori)
            {

                cmd3 = String.Format(@"INSERT INTO Autori_documenti (codice_autore,codice_documento) 
values('{0}','{1}')", aut.CodiceAutore, libro.Codice);

                using (SqlCommand insert = new
                     SqlCommand(cmd3, conn))
                {
                    try
                    {
                        var numrows = insert.ExecuteNonQuery();
                        if (numrows != 1)
                            throw new System.Exception("Valore errato quarta query");
                        //return numrows;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        conn.Close();
                        return 0;
                    }




                }
            }


            #endregion


            return 0;
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