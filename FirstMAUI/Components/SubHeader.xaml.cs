namespace FirstMAUI.Components;

public partial class SubHeader : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(SubHeader), string.Empty, propertyChanged: OnTextChanged);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // expose the label for subclasses
    protected Label InnerLabel => LabelText;

    private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (SubHeader)bindable;
        control.LabelText.Text = newValue?.ToString();
    }

    public SubHeader()
    {
        InitializeComponent();
    }
}
