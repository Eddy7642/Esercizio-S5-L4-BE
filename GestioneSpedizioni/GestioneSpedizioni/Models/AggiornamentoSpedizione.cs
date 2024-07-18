namespace GestioneSpedizioni.Models
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }
        public int SpedizioneId { get; set; }
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataOraAggiornamento { get; set; }
    }
}
