namespace Portfolio.Pages
{
    public partial class Index
    {
        private int spacingColumns  = 2;
        private int gapItems  = 2;


        string[] Colors { get; set; } = new[] { "#4D562C", "#91262C", "#912284", };


        public List<string> Files { get; set; } = new List<string>(Enumerable.Range(1, 40).Select(x=>x.ToString("00"))); 


        public IEnumerable<string> GetEveryNthItem(int nth, int offset = default)
        {
          return  Files
                .Select((x, i) => new { File = x, Index = i })
                .Where(x => (x.Index-offset  )% nth == 0)
                .Select(x => x.File);
        }
        protected override Task OnInitializedAsync()
        {
            Colors = GetRandomNumberOfRandomColors().ToArray();
            return base.OnInitializedAsync();
        }
        private void Refresh()
        {
            Colors = GetRandomNumberOfRandomColors().ToArray();
        }
        private IEnumerable<string> GetRandomNumberOfRandomColors()
        {
            Random random = new Random();
            return Enumerable.Range(1, random.Next(1, 30)).Select(x => GenerateColor());
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
