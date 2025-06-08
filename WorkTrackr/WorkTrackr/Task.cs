namespace WorkTrackr
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedUser { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } // Backlog, In Progress, In Review, Completed
        public string Priority { get; set; } // Low, Medium, High
    }
}
