namespace Models
{
    public class TracksObject
    {
        public Tracks tracks { get; set; }
    }

    public class Tracks
    {
        public string href { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
        public Track[] items { get; set; }
    }

    public class Track
    {
        public Album album { get; set; }
        public Artist[] artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public External_Ids external_ids { get; set; }
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public object preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
    public class External_Urls
    {
        public string spotify { get; set; }
    }
    public class Image
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }

    public class External_Ids
    {
        public string isrc { get; set; }
    }
}
