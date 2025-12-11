namespace Models
{

    public class ArtistObject
    {
        public Artists artists { get; set; }
    }

    public class Artists
    {
        public string href { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
        public Artist[] items { get; set; }
    }

    public class Artist
    {
        public External_Urls external_urls { get; set; }
        public Followers followers { get; set; }
        public object[] genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public Image[] images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
    public class Followers
    {
        public object href { get; set; }
        public int total { get; set; }
    }
}
