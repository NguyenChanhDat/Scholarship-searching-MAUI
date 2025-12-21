using FirstMAUI.Mocks;
using FirstMAUI.Models;

namespace FirstMAUI.Views;

public partial class AddCommentPage : ContentPage
{

    private Picker _scholarshipPicker;
    private Editor _commentEditor;
    private Entry _titleEntry;

    public AddCommentPage()
    {
        // Load XAML at runtime
        Microsoft.Maui.Controls.Xaml.Extensions.LoadFromXaml(this, typeof(AddCommentPage));

        // resolve controls
        _scholarshipPicker = this.FindByName<Picker>("ScholarshipPicker");
        _commentEditor = this.FindByName<Editor>("CommentEditor");
        _titleEntry = this.FindByName<Entry>("TitleEntry");

        var scholarships = MockScholarshipData.All;
        if (_scholarshipPicker != null)
        {
            _scholarshipPicker.ItemsSource = scholarships;
            _scholarshipPicker.ItemDisplayBinding = new Binding("Title");
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var selected = _scholarshipPicker?.SelectedItem as Scholarship;
        if (selected == null)
        {
            await DisplayAlert("Lỗi", "Vui lòng chọn một học bổng.", "OK");
            return;
        }
        var content = _commentEditor?.Text?.Trim();
        if (string.IsNullOrWhiteSpace(content))
        {
            await DisplayAlert("Lỗi", "Nội dung bình luận rỗng.", "OK");
            return;
        }
        var title = _titleEntry?.Text?.Trim() ?? "Bình luận mới";

        var post = new CommunityPost
        {
            Id = new Random().Next(1000, 9999),
            ScholarshipId = selected.Id,
            Scholarship = selected,
            AuthorName = MockUserPersonalInfor.GetAll().Find(user => user.Id == 1).Name,
            Title = title,
            Content = content,
            CreatedAt = DateTime.Now
        };

        // send message to CommunityPage to add the post
        MessagingCenter.Send(this, "NewComment", post);
        await Navigation.PopModalAsync();
    }}