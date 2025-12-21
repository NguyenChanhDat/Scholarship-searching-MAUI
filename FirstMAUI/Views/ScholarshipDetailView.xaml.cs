using FirstMAUI.Models;
using Microsoft.Maui.Controls.Shapes;
using System.Linq;

namespace FirstMAUI.Views;

[QueryProperty(nameof(Scholarship), "Scholarship")]
public partial class ScholarshipDetailView : ContentView
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

    public ScholarshipDetailView()
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
        DetailDescriptionLabel.Text = scholarship.DetailDescription;
        CountryLabel.Text = scholarship.Country;
        ScholarshipUrlLabel.Text = scholarship.ScholarshipUrl;
        ApplicationUrlLabel.Text = scholarship.ApplicationUrl;

        // update Save button text from model
        if (SaveButton != null)
        {
            SaveButton.Text = scholarship.IsSaved ? "💜 Đã lưu" : "💜 Lưu";
        }

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
                Text = scholarship.Deadline != null ? $"⏰ {scholarship.Deadline}" : string.Empty,
                TextColor = Colors.Black
            }
        };
        BadgesLayout.Children.Add(deadlineBorder);


        // Country badge
        var countryBorder = new Border
        {
            Padding = new Thickness(10, 5),
            Stroke = Colors.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = 8 },
            BackgroundColor = Colors.LightBlue,
            Content = new Label
            {
                Text = $"🌍 {scholarship.Country}",
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold
            }
        };
        InfoBadgesLayout.Children.Add(countryBorder);

        // Degree / Bậc học badge
        var degreeBorder = new Border
        {
            Padding = new Thickness(10, 5),
            Stroke = Colors.Transparent,
            StrokeShape = new RoundRectangle { CornerRadius = 8 },
            BackgroundColor = Colors.LightYellow,
            Content = new Label
            {
                Text = $"🎓 {scholarship.Title}", // or a separate Degree property if you have
                TextColor = Colors.Black,
                FontAttributes = FontAttributes.Bold
            }
        };
        InfoBadgesLayout.Children.Add(degreeBorder);


        // only populate the privileges label if privileges text exists
        if (!string.IsNullOrWhiteSpace(scholarship.Priviledges))
        {
            PrivilegesLabel.IsVisible = true;
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
        else
        {
            // hide or clear the label when no privileges are present
            PrivilegesLabel.IsVisible = false;
            PrivilegesLabel.Text = string.Empty;
            PrivilegesLabel.FormattedText = null;
        }

        // === Comments ===
        CommentsLayout.Children.Clear();
        if (scholarship.Comments != null && scholarship.Comments.Any())
        {
            foreach (var c in scholarship.Comments)
            {
                var commentFrame = new Frame
                {
                    Padding = new Thickness(10),
                    CornerRadius = 10,
                    BackgroundColor = Colors.WhiteSmoke,
                    HasShadow = true,
                    Content = new VerticalStackLayout
                    {
                        Spacing = 2,
                        Children =
                        {
                            new Label
                            {
                                Text = $"{c.PersonName} ({c.ApplyYear})",
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.MidnightBlue
                            },
                            new Label
                            {
                                Text = c.Comment,
                                FontSize = 14,
                                TextColor = Colors.Black
                            }
                        }
                    }
                };
                CommentsLayout.Children.Add(commentFrame);
            }
        }
        else
        {
            CommentsLayout.Children.Add(new Label
            {
                Text = "Chưa có bình luận nào.",
                FontAttributes = FontAttributes.Italic,
                TextColor = Colors.Gray
            });
        }

    }

    private void OnUrlTapped(object sender, TappedEventArgs e)
    {
        if (sender is Label label && !string.IsNullOrWhiteSpace(label.Text))
        {
            try
            {
                Launcher.OpenAsync(new Uri(label.Text));
            }
            catch (Exception)
            {
                // optional: handle invalid url
            }
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (Scholarship == null)
            return;

        // toggle the view/model instance
        Scholarship.IsSaved = !Scholarship.IsSaved;

        // persist to the shared in-memory list (use All for persistence)
        var item = MockScholarshipData.All.FirstOrDefault(s => s.Id == Scholarship.Id);
        if (item != null)
        {
            item.IsSaved = Scholarship.IsSaved; // set to the new value (do not invert)
        }

        if (SaveButton != null)
        {
            SaveButton.Text = Scholarship.IsSaved ? "💜 Đã lưu" : "💜 Lưu";
        }
    }

    private async void OnShareClicked(object sender, EventArgs e)
    {
        var url = ScholarshipUrlLabel?.Text;
        if (!string.IsNullOrWhiteSpace(url))
        {
            await Share.Default.RequestAsync(new ShareTextRequest { Uri = url, Title = "Chia sẻ học bổng" });
        }
    }

    private async void OnApplyClicked(object sender, EventArgs e)
    {
        var url = ApplicationUrlLabel?.Text ?? ScholarshipUrlLabel?.Text;
        if (!string.IsNullOrWhiteSpace(url))
        {
            try
            {
                await Launcher.OpenAsync(new Uri(url));
            }
            catch { }
        }
    }

}