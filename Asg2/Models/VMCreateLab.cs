namespace Asg2.Models
{
    public class VMCreateLab
    {
        public int SubjectId { get; set; }
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
     
        public string Curricula { get; set; }

        public string Description { get; set; }
        public string? AsgName { get; set; }
        public DateTime? AsgDl { get; set; }
        public string? AsgDescription { get; set; }

    }
}
