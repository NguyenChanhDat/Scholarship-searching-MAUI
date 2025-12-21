using FirstMAUI.Models;
using System.Collections.Generic;
using System.Linq;

public static class MockCommunityData
{
    public static List<CommunityPost> All { get; } = new List<CommunityPost>();

    static MockCommunityData()
    {
        var scholarships = MockScholarshipData.All;
        All.AddRange(new List<CommunityPost>
        {
            new CommunityPost
            {
                Id =1,
                ScholarshipId =1,
                Scholarship = scholarships.FirstOrDefault(s => s.Id ==1),
                AuthorName = "Minh Hoàng",
                Title = "Chia sẻ kinh nghiệm phỏng vấn Fulbright",
                Content = "Hội đồng rất quan tâm đến kế hoạch quay về đóng góp cho VN. Các bạn nên chuẩn bị kỹ phần này nhé! Mình bị hỏi chi tiết về dự án cụ thể mình sẽ làm sau khi về, không chỉ nói chung chung.\n\nTips: Hãy nghiên cứu về các vấn đề thực tế ở VN trong lĩnh vực của bạn và đề xuất giải pháp cụ thể!",
                CreatedAt = DateTime.Now.AddHours(-2)
            },
            new CommunityPost
            {
                Id =2,
                ScholarshipId =1,
                Scholarship = scholarships.FirstOrDefault(s => s.Id ==1),
                AuthorName = "Lan Anh",
                Title = "Cần mẫu CV cho Chevening",
                Content = "Mình đang tìm mẫu CV phù hợp cho Chevening, ai có mẫu share mình với nhé!",
                CreatedAt = DateTime.Now.AddDays(-1)
            },
            new CommunityPost
            {
                Id =3,
                ScholarshipId =2,
                Scholarship = scholarships.FirstOrDefault(s => s.Id ==2),
                AuthorName = "Nguyễn Minh",
                Title = "Kinh nghiệm xin DAAD",
                Content = "Mình muốn hỏi về kinh nghiệm xin học bổng DAAD cho ngành STEM.",
                CreatedAt = DateTime.Now.AddHours(-5)
            }
        });
    }

    public static List<CommunityPost> GetAll() => new List<CommunityPost>(All);

    public static void AddPost(CommunityPost post)
    {
        All.Insert(0, post);
    }
}