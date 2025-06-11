namespace RefitSampleAPITest.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        //// Override ToString() for easier debugging and logging
        //public override string ToString()
        //{
        //    return $"Post(Id: {Id}, Title: {Title}, Body: {Body}, UserId: {UserId})";
        //}
    }
}
