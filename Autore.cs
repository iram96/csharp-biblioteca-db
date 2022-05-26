namespace csharp_biblioteca_db
{
    class Autore : Persona
    {
        public string Mail;
        public int CodiceAutore;

        public Autore(string Nome, string Cognome, string Mail) : base(Nome, Cognome)
        {
            this.Mail = Mail;
            this.CodiceAutore = GeneraCodiceAutore();
        }

        public int GeneraCodiceAutore()
        {
            return 1000 + this.Nome.Length + this.Cognome.Length + this.Mail.Length;
        }
    }
}
