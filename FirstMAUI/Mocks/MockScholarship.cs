using FirstMAUI.Models;

public static class MockScholarshipData
{
    public static List<Scholarship> GetAll() =>
    [
        new Scholarship
        {
            Title = "Fulbright Master's Program",
            Country = "Hoa Kỳ",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng toàn phần cho sinh viên Việt Nam theo học chương trình thạc sĩ tại Hoa Kỳ.",
            Deadline = "15/05/2026",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null
        },
        new Scholarship
        {
            Title = "Chevening Scholarship",
            Country = "Vương quốc Anh",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng của Chính phủ Anh dành cho các nhà lãnh đạo tương lai.",
            Deadline = "07/11/2025",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null
        },
        new Scholarship
        {
            Title = "DAAD Scholarship",
            Country = "Đức",
            Level = "Thạc sĩ / Tiến sĩ",
            Field = "STEM",
            Description = "Được đăng bởi: Nguyễn Minh • Đang chờ kiểm duyệt",
            Deadline = null,
            IsVerified = false,
            IsFullScholarship = true,
            Status = "pending",
            PostedBy = "Nguyễn Minh"
        }
    ];
}
