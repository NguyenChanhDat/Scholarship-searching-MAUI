using FirstMAUI.Models;

public static class MockScholarshipSuggestionData
{
    public static List<ScholarshipSuggestion> GetAll() =>
    [
        new ScholarshipSuggestion
        {
            Id = 1,
            Title = "Fulbright Master's Program",
            Country = "Hoa Kỳ",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng toàn phần cho sinh viên Việt Nam theo học chương trình thạc sĩ tại Hoa Kỳ.",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            SuitableLevel=52,
            DetailDescription="Chương trình Học bổng Fulbright là một trong những học bổng danh giá nhất dành cho sinh viên Việt Nam muốn theo học chương trình thạc sĩ tại các trường đại học hàng đầu của Hoa Kỳ.\r\n\r\nĐược tài trợ bởi Chính phủ Hoa Kỳ, học bổng này không chỉ hỗ trợ toàn bộ chi phí học tập mà còn mở ra cơ hội networking quốc tế và trải nghiệm môi trường học thuật đẳng cấp thế giới.\r\n\r\n",
        },
        new ScholarshipSuggestion
        {
            Id = 2,
            Title = "Chevening Scholarship",
            Country = "Vương quốc Anh",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng của Chính phủ Anh dành cho các nhà lãnh đạo tương lai.",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            SuitableLevel=80,
            DetailDescription="detail description for Chevening Scholarship",
        },
        new ScholarshipSuggestion
        {
            Id = 3,
            Title = "DAAD Scholarship",
            Country = "Đức",
            Level = "Thạc sĩ / Tiến sĩ",
            Field = "STEM",
            Description = "Được đăng bởi: Nguyễn Minh • Đang chờ kiểm duyệt",
            IsVerified = false,
            IsFullScholarship = false,
            Status = "pending",
            PostedBy = "Nguyễn Minh",
            SuitableLevel=35,
            DetailDescription="detail description for DAAD Scholarship",
        }
    ];
}
