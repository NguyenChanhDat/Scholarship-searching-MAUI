using FirstMAUI.Models;
using Microsoft.Maui.Controls.Shapes;

namespace FirstMAUI.Views;

[QueryProperty(nameof(Scholarship), "Scholarship")]
public partial class ScholarshipDetail : ContentPage
{
    private Scholarship _scholarship;
    public Scholarship Scholarship
    {
        get => _scholarship;
        set
        {
            _scholarship = value;
            OnPropertyChanged();
            LoadScholarship();
        }
    }

    public ScholarshipDetail()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void LoadScholarship()
    {
        var scholarship = MockScholarshipData.GetAll().FirstOrDefault(s => s.Id == this._scholarship.Id);
        if (scholarship == null)
            return;

        TitleLabel.Text = scholarship.Title;
        DescriptionLabel.Text = scholarship.Description;
        CountryLabel.Text = scholarship.Country;

        // clear existing badges
        BadgesLayout.Children.Clear();

        // IsVerified badge
        var verifiedBorder = new Border
        {
            Padding = new Thickness(5, 2),
            Stroke = Colors.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = 5 },
            BackgroundColor = scholarship.IsVerified ? Colors.LightGreen : Colors.LightCoral,
            Content = new Label
            {
                Text = scholarship.IsVerified ? "Đã xác thực" : "Chưa xác thực",
                TextColor = Colors.Black
            }
        };
        BadgesLayout.Children.Add(verifiedBorder);

        // IsFullScholarship badge
        var fullScholarBorder = new Border
        {
            Padding = new Thickness(5, 2),
            Stroke = Colors.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = 5 },
            BackgroundColor = scholarship.IsFullScholarship ? Colors.LightGreen : Colors.LightYellow,
            Content = new Label
            {
                Text = scholarship.IsFullScholarship ? "Học bổng toàn phần" : "Học bổng một phần",
                TextColor = Colors.Black
            }
        };
        BadgesLayout.Children.Add(fullScholarBorder);

        // IsDeadlineSoon badge
        var deadlineBorder = new Border
        {
            Padding = new Thickness(5, 2),
            Stroke = Colors.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = 5 },
            BackgroundColor = scholarship.IsDeadlineSoon ? Colors.LightCoral : Colors.LightGreen,
            Content = new Label
            {
                Text = $"⏰ {scholarship.Deadline:dd/MM/yyyy}",
                TextColor = Colors.Black
            }
        };
        BadgesLayout.Children.Add(deadlineBorder);


        // clear previous spans
        PrivilegesLabel.FormattedText = new FormattedString();

        var lines = scholarship.Priviledges.Split('\n');
        foreach (var line in lines)
        {
            // split line at the first colon
            var parts = line.Split(new[] { ':' }, 2);

            if (parts.Length == 2)
            {
                // bold part before colon
                PrivilegesLabel.FormattedText.Spans.Add(new Span
                {
                    Text = "• " + parts[0] + ": ",
                    FontAttributes = FontAttributes.Bold
                });

                // normal part after colon
                PrivilegesLabel.FormattedText.Spans.Add(new Span
                {
                    Text = parts[1] + "\n"
                });
            }
            else
            {
                // no colon in line, just normal
                PrivilegesLabel.FormattedText.Spans.Add(new Span
                {
                    Text = "• " + line + "\n"
                });
            }
        }

    }

}