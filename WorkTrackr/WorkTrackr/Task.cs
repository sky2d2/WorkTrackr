namespace WorkTrackr
{
    public class Task
    {
        public int TaskId { get; set; }              // Unique Task ID
        public string Title { get; set; }            // Task title
        public string Description { get; set; }      // Task description
        public int? AssignedUserId { get; set; }     // Nullable user ID (no assignment means null)
        public DateTime DueDate { get; set; }        // Due date
        public string Status { get; set; }            // Backlog, In Progress, In Review, Completed
        public string Priority { get; set; }          // Low, Medium, High

        // Constructor to ensure non-nullable properties have values
        public Task(int taskId, string title, string description)
        {
            TaskId = taskId;
            Title = title ?? "";
            Description = description ?? "";
            Status = "Backlog";         // default status
            Priority = "Medium";        // default priority
            DueDate = DateTime.Now.AddDays(7);  // default due date one week from now
            AssignedUserId = null;      // default: no assigned user
        }

        public override string ToString()
        {
            string assigned = AssignedUserId.HasValue ? AssignedUserId.Value.ToString() : "None";
            return $"[{TaskId}] {Title} (Priority: {Priority}, Status: {Status}, Assigned to: {assigned}, Due: {DueDate:d})";
        }
    }
}
