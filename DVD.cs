namespace csharp_biblioteca_db
{
    internal class DVD : Documento
    {
        public int Durata { get; set; }

        public DVD(string Codice, string Titolo, int Anno, string Settore, string Scaffale, int Durata) : base(Codice, Titolo, Anno, Settore, Scaffale)
        {
            this.Durata = Durata;
        }

        public override string ToString()
        {
            return string.Format("{0}\nDurata:{1}",
                base.ToString(),
                this.Durata);
        }
    }
}
