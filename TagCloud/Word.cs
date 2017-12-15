namespace TagCloud
{
    public class Word
    {
        public string Text { get; set; }
        public int Quantity { get; set; }

        public Word(){}

        public Word(string text, int quantity)
        {
            Text = text;
            Quantity = quantity;
        }
    }
}