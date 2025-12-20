namespace FirstMAUI.Models
{
    public class CommunityPost
    {
        public int Id { get; set; }
        public int ScholarshipId { get; set; }
        public Scholarship Scholarship { get; set; }
        public string AuthorName { get; set; }
        public string AuthorInitials => GetInitials(AuthorName);
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        private string GetInitials(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "NN";

            var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
                return parts[0].Substring(0, 1).ToUpperInvariant();

            return (parts[0].Substring(0, 1) + parts[^1].Substring(0, 1)).ToUpperInvariant();
        }

        public string TimeAgo
        {
            get
            {
                var span = DateTime.Now - CreatedAt;
                if (span.TotalDays >= 1) return $"{(int)span.TotalDays} ngày trước";
                if (span.TotalHours >= 1) return $"{(int)span.TotalHours} giờ trước";
                if (span.TotalMinutes >= 1) return $"{(int)span.TotalMinutes} phút trước";
                return "vừa xong";
            }
        }
    }
}