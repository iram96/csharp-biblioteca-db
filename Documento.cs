namespace csharp_biblioteca_db
{
    internal class Documento
    {
        public int Codice { get; set; }
        public string Titolo { get; set; }
        //public int Anno { get; set; }
        public string Settore { get; set; }
        public Stato Stato { get; set; }
        public List<Autore> Autori { get; set; }
        public string Scaffale { get; set; }

        public Documento(int Codice, string Titolo, string Settore, string Scaffale)
        {
            this.Codice = Codice;
            this.Titolo = Titolo;
            this.Settore = Settore;
            this.Autori = new List<Autore>();
            this.Stato = Stato.Disponibile;
            this.Scaffale = Scaffale;
        }

        public override string ToString()
        {
            return string.Format("Codice:{0}\nTitolo:{1}\nSettore:{2}\nStato:{3}\nScaffale numero:{4}",
                this.Codice,
                this.Titolo,
                this.Settore,
                this.Stato,
                this.Scaffale);
        }

        public void ImpostaInPrestito()
        {
            this.Stato = Stato.Prestito;
        }

        public void ImpostaDisponibile()
        {
            this.Stato = Stato.Disponibile;
        }
    }
}
