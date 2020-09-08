using Yet.API.TratamentoBase;

namespace Yet.API.AuthEndpoints
{
    public class AutenticacaoRequest : BaseRequest 
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
