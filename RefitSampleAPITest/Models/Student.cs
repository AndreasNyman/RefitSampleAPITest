namespace RefitSampleAPITest.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Course { get; set; }
        public int Points { get; set; }

        public Student() { }

        // Optional: internal method to set ID from your service
        internal void SetId(int id) => Id = id;
    }
}

