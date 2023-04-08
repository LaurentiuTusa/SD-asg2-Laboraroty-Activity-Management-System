namespace Asg2.Models
{
    public class VMLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
        public bool StudentDot { get; set; }
        public bool TeacherDot { get; set; }
    }
}
