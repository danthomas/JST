namespace JST.Business.Models
{
    public class Route
    {
        public Route(string text, string url)
        {
            Text = text;
            Url = url;
        }

        public string Text { get; set; }
        public string Url { get; set; }
    }
}