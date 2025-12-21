using FirstMAUI.Models;

namespace FirstMAUI.Views;

public partial class CommunityPage : ContentPage
{
    private List<CommunityPost> _allPosts;
    public List<CommunityPost> Posts { get; set; }

    // runtime references to XAML controls (resolved in ctor)
    private Button _btnAll;
    private Button _btnFulbright;
    private Button _btnChevening;
    private Button _btnAustralia;
    private Button _btnAddComment;
    private SearchBar _searchBar;
    private CollectionView _postsCollectionView;
    private Label _countLabel;

    private string _activeFilter; // e.g. "Fulbright", "Chevening", "Australia" or null for all

    public CommunityPage()
    {
        InitializeComponent();

        // resolve controls by name to avoid relying on generated fields
        _btnAll = this.FindByName<Button>("BtnAll");
        _btnFulbright = this.FindByName<Button>("BtnFulbright");
        _btnChevening = this.FindByName<Button>("BtnChevening");
        _btnAustralia = this.FindByName<Button>("BtnAustralia");
        _btnAddComment = this.FindByName<Button>("BtnAddComment");
        _searchBar = this.FindByName<SearchBar>("SearchBarControl");
        _postsCollectionView = this.FindByName<CollectionView>("PostsCollectionView");
        _countLabel = this.FindByName<Label>("CountLabel");

        _allPosts = MockCommunityData.GetAll();
        Posts = new List<CommunityPost>(_allPosts);

        if (_postsCollectionView != null)
            _postsCollectionView.ItemsSource = Posts;

        UpdateCount();
        BindingContext = this;

        // wire up events
        if (_searchBar != null) _searchBar.TextChanged += OnSearchTextChanged;
        if (_btnAll != null) _btnAll.Clicked += OnFilterAllClicked;
        if (_btnFulbright != null) _btnFulbright.Clicked += OnFilterFulbrightClicked;
        if (_btnChevening != null) _btnChevening.Clicked += OnFilterCheveningClicked;
        if (_btnAustralia != null) _btnAustralia.Clicked += OnFilterAustraliaClicked;
        if (_btnAddComment != null) _btnAddComment.Clicked += OnAddCommentClicked;

        // set default active filter if button exists
        if (_btnAll != null)
            SetActiveButton(_btnAll, null);
    }

    private void UpdateCount()
    {
        if (_countLabel != null)
            _countLabel.Text = $"{Posts.Count} thảo luận";
    }

    private void ApplyFilter(string scholarshipTitleFilter, string searchText)
    {
        IEnumerable<CommunityPost> query = _allPosts;

        if (!string.IsNullOrWhiteSpace(scholarshipTitleFilter))
        {
            query = query.Where(p => p.Scholarship != null && p.Scholarship.Title?.Contains(scholarshipTitleFilter, StringComparison.OrdinalIgnoreCase) == true);
        }

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            query = query.Where(p => (p.Title != null && p.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase)) || (p.Content != null && p.Content.Contains(searchText, StringComparison.OrdinalIgnoreCase)) || (p.Scholarship != null && p.Scholarship.Title != null && p.Scholarship.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
        }

        Posts = query.ToList();
        if (_postsCollectionView != null)
            _postsCollectionView.ItemsSource = Posts;

        UpdateCount();
    }

    public void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var filter = e.NewTextValue ?? string.Empty;
        ApplyFilter(_activeFilter, filter);
    }

    private void ResetFilterButtonStyles()
    {
        if (_btnAll != null) { _btnAll.BackgroundColor = Color.FromArgb("#EEF3F8"); _btnAll.TextColor = Color.FromArgb("#1F3358"); }
        if (_btnFulbright != null) { _btnFulbright.BackgroundColor = Color.FromArgb("#EEF3F8"); _btnFulbright.TextColor = Color.FromArgb("#1F3358"); }
        if (_btnChevening != null) { _btnChevening.BackgroundColor = Color.FromArgb("#EEF3F8"); _btnChevening.TextColor = Color.FromArgb("#1F3358"); }
        if (_btnAustralia != null) { _btnAustralia.BackgroundColor = Color.FromArgb("#EEF3F8"); _btnAustralia.TextColor = Color.FromArgb("#1F3358"); }
    }

    private void SetActiveButton(Button btn, string filter)
    {
        if (btn == null) return;
        ResetFilterButtonStyles();
        btn.BackgroundColor = Color.FromArgb("#1F3358");
        btn.TextColor = Colors.White;
        _activeFilter = filter; // set the active filter string
    }

    public void OnFilterAllClicked(object sender, EventArgs e)
    {
        SetActiveButton(_btnAll, null);
        ApplyFilter(null, _searchBar?.Text ?? string.Empty);
    }

    public void OnFilterFulbrightClicked(object sender, EventArgs e)
    {
        SetActiveButton(_btnFulbright, "Fulbright");
        ApplyFilter("Fulbright", _searchBar?.Text ?? string.Empty);
    }

    public void OnFilterCheveningClicked(object sender, EventArgs e)
    {
        SetActiveButton(_btnChevening, "Chevening");
        ApplyFilter("Chevening", _searchBar?.Text ?? string.Empty);
    }

    public void OnFilterAustraliaClicked(object sender, EventArgs e)
    {
        SetActiveButton(_btnAustralia, "Australia");
        ApplyFilter("Australia", _searchBar?.Text ?? string.Empty);
    }

    private async void OnAddCommentClicked(object sender, EventArgs e)
    {
        // open modal AddCommentPage
        var page = new AddCommentPage();
        // subscribe for new comment message
        MessagingCenter.Subscribe<AddCommentPage, CommunityPost>(this, "NewComment", (s, post) =>
        {
            // add to mock data and refresh list
            MockCommunityData.AddPost(post);
            _allPosts.Add(post);
            Posts.Insert(0, post);
            if (_postsCollectionView != null) _postsCollectionView.ItemsSource = null; _postsCollectionView.ItemsSource = Posts;
            UpdateCount();
            // unsubscribe
            MessagingCenter.Unsubscribe<AddCommentPage, CommunityPost>(this, "NewComment");
        });
        await Navigation.PushModalAsync(page);
    }
}