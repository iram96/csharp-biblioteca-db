namespace csharp_biblioteca_db
{
    internal class Biblioteca
    {
        public string Nome { get; set; }

        public List<Scaffale> Scaffali { get; set; }
        public List<Documento> Documenti { get; set; }
        public List<Prestito> Prestiti { get; set; }


        public List<Utente> Utenti { get; set; }

        //public Dictionary<string,Utente> MioDizionario;



        /*
        Chiave     Nome;Cognome;email
        */



        /*public ListaUtenti MiaListaUtenti {}


        MioDizionario.Add(

        MiaListaUtenti.AggiungiUtente(sMioNome, sMioCognome, sMiaMail,.......)

        UtentePresente = MioDizionario["Mario;Rossi;mariorossi@gmail.com"];


         MioDizionario(chiave, valore)
        */








        public Biblioteca(string Nome)
        {
            this.Nome = Nome;
            this.Scaffali = new List<Scaffale>();
            this.Documenti = new List<Documento>();
            this.Prestiti = new List<Prestito>();
            this.Utenti = new List<Utente>();

            //Recuper elenco degli scaffali

            List<string> ElencoScaffali = db.scaffaliGet();
            ElencoScaffali.ForEach(s =>
            {
                //AggiungiScaffale(item, false);
                Scaffale sl = new Scaffale(s);
                Scaffali.Add(sl);
            });

        }



        public void AggiungiScaffale(string sNomeScaffale, bool addToDb = true)
        {
            Scaffale s1 = new Scaffale(sNomeScaffale);
            Scaffali.Add(s1);
            if (addToDb)
                db.ScaffaleAdd(s1.Numero);
        }

        public void AggiungiLibro(int iCodice, string sTitolo, string sSettore, string sScaffale, int iNumPagine, List<Autore> lListaAutori)
        {
            Libro MioLibro = new Libro(iCodice, sTitolo, sSettore, sScaffale, iNumPagine);
            //MioLibro.Scaffale = new Scaffale("SS12");
            MioLibro.Stato = Stato.Disponibile;
            db.LibroAdd(MioLibro, lListaAutori);
        }

        public int GestisciOperazioneBiblioteca(int codiceOperazione)
        {
            List<Documento> lResult;
            string sAppo;
            switch (codiceOperazione)
            {
                case 1:
                    Console.WriteLine("Inserisci autore : ");
                    sAppo = Console.ReadLine();
                    lResult = SearchByAuthor(sAppo);
                    if (lResult == null)
                        return 1;
                    else
                        StampaListaDocumenti(lResult);
                    break;
            }
            return 0;
        }


        public void StampaListaDocumenti(List<Documento> lDocumenti)
        {
            return;
        }
        public List<Documento> SearchByAuthor(string autore)
        {
            // CONNETTITI AL DB PRENDI I
            //LANCIA QUERY
            //PRENDI RISULTATI
            //STAMPA RISULTATI


            /*
                SELECT Titolo, Settore, Stato, Tipo 
                FROM documenti, autori_documenti
                INNER JOIN (autori_documenti ON documenti.codice_documento = autori_documenti.codice_autore )
                WHERE autori_documenti.codice_autore =
            */

            return null;
        }
        public List<Documento> SearchByCodice(string Codice)
        {
            Console.WriteLine("METODO DA IMPLEMENTARE");
            return null;
        }

        public List<Documento> SearchByTitolo(string Titolo)
        {
            Console.WriteLine("METODO DA IMPLEMENTARE");
            return null;
        }

        public List<Prestito> SearchPrestiti(string Numero)
        {
            Console.WriteLine("METODO DA IMPLEMENTARE");
            return null;


        }
        public List<Prestito> SearchPrestiti(string Nome, string Cognome)
        {
            Console.WriteLine("METODO DA IMPLEMENTARE");
            return null;
        }
    }
}

