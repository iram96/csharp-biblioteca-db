namespace csharp_biblioteca_db // Note: actual namespace depends on the project name.
{
    enum Stato { Disponibile, Prestito }
    internal class Program
    {
        static void Main(string[] args)
        {









            //using (SqlCommand query = new SqlCommand("select * from clienti", conn))
            //{
            //    using (SqlDataReader reader = query.ExecuteReader())
            //    {
            //        Console.WriteLine(reader.FieldCount);
            //        while (reader.Read())
            //        {
            //            for (int i = 0; i < reader.FieldCount; ++i)
            //                Console.Write("{0}, ", reader[i]);
            //            Console.WriteLine();
            //        }
            //    }
            //}




            Biblioteca b = new Biblioteca("Civica");
            List<Autore> lAutoriLibro = new List<Autore>();

            Autore a3 = new Autore("Nome 3", "Cognome 3", "nd");
            lAutoriLibro.Add(a3);
            b.AggiungiLibro(3, "La grande cavalcata", "Avventura", "SS11", 200, lAutoriLibro);



            //b.AggiungiScaffale("SS11");
            //b.AggiungiScaffale("SS12");
            //b.AggiungiScaffale("SS13");

            b.Scaffali.ForEach(x => Console.WriteLine(x.Numero));

            Libro l2 = new Libro(4324234, "Titolo 2", "Storia", "SS12", 130);

            l2.Autori.Add(a3);

            Console.WriteLine("Lista Operazioni :");

            Console.WriteLine("\t1:  Cerca libro per Autore");
            Console.WriteLine("\t Cosa vuoi fare?");

            string sAppo = Console.ReadLine();

            while (sAppo != "")
            {
                b.GestisciOperazioneBiblioteca(Convert.ToInt32(sAppo));
            }

            /*
            Scaffale s1 = new Scaffale("S001");
            Scaffale s2 = new Scaffale("S002");
            Scaffale s3 = new Scaffale("S003");

            #region "Libro 1"
            Libro l1 = new Libro("ISBN1", "Titolo 1", 2009, "Storia", 220);

            Autore a1 = new Autore("Nome 1", "Cognome 1");
            Autore a2 = new Autore("Nome 2", "Cognome 2");


            //Autore.Add(a1);
            //Autore.Add(a2);




            b.Documenti.Add(l1);
            #endregion

            #region "Libro 2"
            Libro l2 = new Libro("ISBN2", "Titolo 2", 2009, "Storia", 130);

            Autore a3 = new Autore("Nome 3", "Cognome 3");
            Autore a4 = new Autore("Nome 4", "Cognome 4");

            l2.Autori.Add(a3);
            l2.Autori.Add(a4);

            l2.Scaffale = s2;
            b.Documenti.Add(l2);
            #endregion

            #region "DVD"
            DVD dvd1 = new DVD("Codice1", "Titolo 3", 2019, "Storia", 130);

            dvd1.Autori.Add(a3);

            dvd1.Scaffale = s3;
            b.Documenti.Add(dvd1);
            #endregion

            Utente u1 = new Utente("Nome 1", "Cognome 1", "Telefono 1", "Email 1", "Password 1");

            b.Utenti.Add(u1);

            Prestito p1 = new Prestito("P00001", new DateTime(2019, 1, 20), new DateTime(2019, 2, 20), u1, l1);
            Prestito p2 = new Prestito("P00002", new DateTime(2019, 3, 20), new DateTime(2019, 4, 20), u1, l2);

            b.Prestiti.Add(p1);
            b.Prestiti.Add(p2);

            Console.WriteLine("\n\nSearchByCodice: ISBN1\n\n");

            List<Documento> results = b.SearchByCodice("ISBN1");

            foreach (Documento doc in results)
            {
                Console.WriteLine(doc.ToString());

                if (doc.Autori.Count > 0)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Autori");
                    Console.WriteLine("--------------------------");
                    foreach (Autore a in doc.Autori)
                    {
                        Console.WriteLine(a.ToString());
                        Console.WriteLine("--------------------------");
                    }
                }
            }

            Console.WriteLine("\n\nSearchPrestiti: Nome 1, Cognome 1\n\n");

            List<Prestito> prestiti = b.SearchPrestiti("Nome 1", "Cognome 1");

            foreach (Prestito p in prestiti)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("--------------------------");
            }
            */

        }
    }
}