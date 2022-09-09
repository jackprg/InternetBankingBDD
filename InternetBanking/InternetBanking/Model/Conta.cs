namespace InternetBanking.Model
{
    public class Conta
    {
        public string Chave { get; set; }

        public string TipoChave { get; set; }

        public string Titular { get; set; }

        public string Banco { get; set; }

        public string Numero { get; set; }
    }

    public class ContaRepository
    {
        private static readonly List<Conta> contas = new List<Conta>();

        static ContaRepository()
        {
            contas.Add(new Conta()
            {
                Banco = "Caixa Economica Federal",
                Numero = "224455-6",
                Chave = "62995452590",
                TipoChave = "CPF",
                Titular = "Guilherme Correia Santos"
            });

            contas.Add(new Conta()
            {
                Banco = "Banco do Brasil",
                Numero = "336677-8",
                Chave = "18788865339",
                TipoChave = "CPF",
                Titular = "Luana Costa Sousa"
            });

            contas.Add(new Conta()
            {
                Banco = "Santander",
                Numero = "9999888-8",
                Chave = "54911223344",
                TipoChave = "TELEFONE",
                Titular = "Emilly Carvalho Costa"
            });
        }

        public static Conta Get(string tipoChave, string chave)
        {
            return contas.FirstOrDefault(x => x.TipoChave == tipoChave && x.Chave == chave);
        }
    }
}
