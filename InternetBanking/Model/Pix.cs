namespace InternetBanking.Model
{
    public class Pix
    {
        public Guid IdTransacao { get; set; }

        public Conta Conta { get; set; }

        public decimal Valor { get; set; }

        public string Status { get; set; }
    }

    public class PixRepository
    {
        private readonly static List<Pix> pixes = new List<Pix>();

        public static void Save(Pix pix)
        {
            pixes.Add(pix);
        }

        public static Pix Get(Guid IdTransacao)
        {
            return pixes.FirstOrDefault(x => x.IdTransacao == IdTransacao);
        }
    }
}
