namespace WorkTrackr
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AssignedUserId { get; set; } // Nullable if not assigned
        public DateTime DueDate { get; set; }
        public string Status { get; set; } // Backlog, In Progress, In Review, Completed
        public string Priority { get; set; } // Low, Medium, High

        public Task(int taskId, string title, string description)
        {
            TaskId = taskId;
            Title = title ?? "";
            Description = description ?? "";
            Status = "Backlog";
            Priority = "Medium";
            DueDate = DateTime.Now.AddDays(7);
            AssignedUserId = null;
        }

        public string GetSummary()
        {
            string assigned = AssignedUserId.HasValue ? AssignedUserId.Value.ToString() : "None";
            return $"Task #{TaskId} - {Title} | Priority: {Priority} | Status: {Status} | Assigned: {assigned} | Due: {DueDate:yyyy-MM-dd}";
        }

        /*public override string ToString()
        {
            string assigned = AssignedUserId.HasValue ? AssignedUserId.Value.ToString() : "None";
            return $"[{TaskId}] {Title} (Priority: {Priority}, Status: {Status}, Assigned to: {assigned}, Due: {DueDate:yyyy-MM-dd})";
        }*/
    }
}