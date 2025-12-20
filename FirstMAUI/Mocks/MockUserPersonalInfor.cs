using FirstMAUI.Models;

namespace FirstMAUI.Mocks;

public static class MockUserPersonalInfor
{
    public static List<PersonalUserInfor> GetAll() =>
    [
        new PersonalUserInfor
        {
            Id = 1,
            Name = "First User",
            Email = "nguyenvana@example.com",
            Phone = "0987654321",
            Address = "123 Nguyen Trai, Ha Noi",
            PreferredStudyLevel = "Bachelor",
            PreferredFieldOfStudy = "Computer Science",
            PreferredCountry = "Australia",
            GPA = 3.6
        },
        new PersonalUserInfor
        {
            Id = 2,
            Name = "Tran Thi B",
            Email = "tranthib@example.com",
            Phone = "0912345678",
            Address = "45 Le Loi, Da Nang",
            PreferredStudyLevel = "Master",
            PreferredFieldOfStudy = "Business Administration",
            PreferredCountry = "France",
            GPA = 3.9
        },
        new PersonalUserInfor
        {
            Id = 3,
            Name = "Le Van C",
            Email = "levanc@example.com",
            Phone = "0909123456",
            Address = "67 Pham Van Dong, Ho Chi Minh City",
            PreferredStudyLevel = "PhD",
            PreferredFieldOfStudy = "Electrical Engineering",
            PreferredCountry = "Japan",
            GPA = 3.7
        },
        new PersonalUserInfor
        {
            Id = 4,
            Name = "Pham Thi D",
            Email = "phamthid@example.com",
            Phone = "0933456789",
            Address = "89 Tran Hung Dao, Hue",
            PreferredStudyLevel = "Bachelor",
            PreferredFieldOfStudy = "Environmental Science",
            PreferredCountry = "Canada",
            GPA = 3.5
        },
        new PersonalUserInfor
        {
            Id = 5,
            Name = "Hoang Van E",
            Email = "hoangvane@example.com",
            Phone = "0978123456",
            Address = "12 Le Duan, Can Tho",
            PreferredStudyLevel = "Master",
            PreferredFieldOfStudy = "Data Science",
            PreferredCountry = "USA",
            GPA = 3.85
        }
    ];
}
