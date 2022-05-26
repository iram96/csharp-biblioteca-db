namespace csharp_biblioteca_db
{
    internal class Libro : Documento
    {
        public int NumeroPagine { get; set; }

        public Libro(int Codice, string Titolo, string Settore, string Scaffale, int NumeroPagine) : base(Codice, Titolo, Settore, Scaffale)
        {
            this.NumeroPagine = NumeroPagine;


        }

        public override string ToString()
        {
            return string.Format("{0}\nNumeroPagine:{1}",
                base.ToString(),
                this.NumeroPagine);
        }
    }


}
