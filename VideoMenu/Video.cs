namespace VideoMenu
{
    public class Video
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public static int Id { get; private set; } = 0;

        public Video()
        {
            ++Id;
        }
    }
}