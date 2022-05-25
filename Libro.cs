namespace csharp_biblioteca_db
{
    internal class Libro : Documento
    {
        public int NumeroPagine { get; set; }

        public Libro(string Codice, string Titolo, int Anno, string Settore, string Scaffale, int NumeroPagine) : base(Codice, Titolo, Anno, Settore, Scaffale)
        {
            this.NumeroPagine = NumeroPagine;

            db.libroAdd(this);
        }

        public override string ToString()
        {
            return string.Format("{0}\nNumeroPagine:{1}",
                base.ToString(),
                this.NumeroPagine);
        }
    }


}
