namespace Portfolio.Pages
{
    public partial class Index
    {

        string[] Colors { get; set; } = new[] { "#4D562C", "#91262C", "#912284", };


        protected override Task OnInitializedAsync()
        {
            Colors = GetRandomNumberOfRandomColors().ToArray();
            return base.OnInitializedAsync();
        }

        private IEnumerable<string> GetRandomNumberOfRandomColors()
        {
            Random random = new Random();
            return Enumerable.Range(1, random.Next(0, 30)).Select(x => GenerateColor());
            //return Enumerable.Range(1, 7).Select(x => GenerateColor());
        }
        private string GenerateColor()
        {

            var random = new Random();
            var a = new[] { new byte(), new byte(), new byte() };
            random.NextBytes(a);
            return "#" + Convert.ToHexString(a);

        }
        private int GetRandom(int min, int max, int offset = default)
        {
            Random r = new Random();
            return r.Next(min, max + 1) + offset;
        }


    }
}
