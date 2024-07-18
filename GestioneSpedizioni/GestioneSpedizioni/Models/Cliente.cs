namespace GestioneSpedizioni.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }  // Solo per privati
        public string RagioneSociale { get; set; }  // Solo per aziende
        public string PartitaIVA { get; set; }  // Solo per aziende
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Indirizzo { get; set; }
    }
}
