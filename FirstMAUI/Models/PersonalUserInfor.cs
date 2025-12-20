namespace FirstMAUI.Models;

public class PersonalUserInfor
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public required string Address { get; set; }

    public required string PreferredStudyLevel { get; set; }

    public required string PreferredFieldOfStudy { get; set; }

    public required string PreferredCountry { get; set; }

    public required double GPA { get; set; }
}