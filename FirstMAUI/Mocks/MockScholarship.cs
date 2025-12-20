using FirstMAUI.Models;

public static class MockScholarshipData
{
    public static List<Scholarship> GetAll() => new List<Scholarship>
    {
        new Scholarship
        {
            Id =1,
            Title = "Fulbright Master's Program",
            Country = "Hoa Kỳ",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng toàn phần cho sinh viên Việt Nam theo học chương trình thạc sĩ tại Hoa Kỳ.",
            DetailDescription="Chương trình Học bổng Fulbright là một trong những học bổng danh giá nhất dành cho sinh viên Việt Nam muốn theo học chương trình thạc sĩ tại các trường đại học hàng đầu của Hoa Kỳ.\r\n\r\nĐược tài trợ bởi Chính phủ Hoa Kỳ, học bổng này không chỉ hỗ trợ toàn bộ chi phí học tập mà còn mở ra cơ hội networking quốc tế và trải nghiệm môi trường học thuật đẳng cấp thế giới.\r\n\r\n",
            Deadline = "15/05/2026",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            Priviledges = "Học phí toàn phần: Chi trả 100% học phí cho toàn bộ chương trình thạc sĩ (2 năm)\n" +
                    "Sinh hoạt phí: Khoảng $1,500-2,000/tháng tùy theo thành phố\n" +
                    "Vé máy bay: Vé khứ hồi Việt Nam - Hoa Kỳ\n" +
                    "Bảo hiểm y tế: Bảo hiểm y tế toàn diện trong suốt thời gian học\n" +
                    "Chi phí sách vở: Hỗ trợ mua sách và tài liệu học tập\n" +
                    "Hỗ trợ nghiên cứu: Kinh phí cho các hoạt động nghiên cứu và hội thảo",
            Comments=new List<CommentAttached>
            {
                new() {
                    PersonName="Lê Thị Hồng",
                    Comment="Mình đã nhận học bổng này năm ngoái và trải nghiệm thật tuyệt vời! Môi trường học tập rất chuyên nghiệp và mình đã có cơ hội kết nối với nhiều bạn bè quốc tế.",
                    ApplyYear="2023"
                },
                new() {
                    PersonName="Trần Văn Nam",
                    Comment="Học bổng Fulbright thực sự đã thay đổi cuộc đời mình. Mình khuyến khích các bạn hãy nộp đơn nếu có cơ hội!",
                    ApplyYear="2022"
                }
            },
            ScholarshipUrl="https://fulbright.org.vn/scholarships/masters-program/",
            ApplicationUrl="https://apply.fulbright.org.vn/",
            IsSaved = true
        },
        new Scholarship
        {
            Id =2,
            Title = "Chevening Scholarship",
            Country = "Vương quốc Anh",
            Level = "Thạc sĩ",
            Field = "Tất cả ngành",
            Description = "Học bổng của Chính phủ Anh dành cho các nhà lãnh đạo tương lai.",
            DetailDescription="Detail Desc",
            Deadline = "07/11/2025",
            IsVerified = true,
            IsFullScholarship = true,
            Status = "verified",
            PostedBy = null,
            IsSaved = false
        },
        new Scholarship
        {
            Id =3,
            Title = "DAAD Scholarship",
            Country = "Đức",
            Level = "Thạc sĩ / Tiến sĩ",
            Field = "STEM",
            Description = "Được đăng bởi: Nguyễn Minh • Đang chờ kiểm duyệt",
            DetailDescription="Detail Desc",
            Deadline = null,
            IsVerified = false,
            IsFullScholarship = false,
            Status = "pending",
            PostedBy = "Nguyễn Minh",
            IsSaved = false
        }
    };
}
