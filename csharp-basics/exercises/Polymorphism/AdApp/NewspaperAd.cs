namespace AdApp
{
    public class NewspaperAd : Advert
    {
        private int _column;
        private int _rate;

        public NewspaperAd(int fee) : base(fee)
        {
        }

        private new int Cost()
        {
            return base.Cost();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}