using System.Runtime.Serialization;

namespace TesteIbmMQ.Domain.Entities
{
    [DataContract]
    public class EstruturaFila
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int Idade { get; set; }
    }
}
