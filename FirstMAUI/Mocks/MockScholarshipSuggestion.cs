using FirstMAUI.Models;

public static class MockScholarshipSuggestionData
{
    public static List<ScholarshipSuggestion> GetAll() =>
    [
        new ScholarshipSuggestion
        {
            Title = "Fulbright Master's Program",
            Country = "Hoa Kỳ",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng toàn phần cho sinh viên Việt Nam theo học chương trình thạc sĩ tại Hoa Kỳ.",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            SuitableLevel=52
        },
        new ScholarshipSuggestion
        {
            Title = "Chevening Scholarship",
            Country = "Vương quốc Anh",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng của Chính phủ Anh dành cho các nhà lãnh đạo tương lai.",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            SuitableLevel=80
        },
        new ScholarshipSuggestion
        {
            Title = "DAAD Scholarship",
            Country = "Đức",
            Level = "Thạc sĩ / Tiến sĩ",
            Field = "STEM",
            Description = "Được đăng bởi: Nguyễn Minh • Đang chờ kiểm duyệt",
            IsVerified = false,
            IsFullScholarship = false,
            Status = "pending",
            PostedBy = "Nguyễn Minh",
            SuitableLevel=35
        }
    ];
}
