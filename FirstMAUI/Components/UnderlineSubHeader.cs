namespace FirstMAUI.Components;

public partial class UnderlineSubHeader : SubHeader
{
    public UnderlineSubHeader()
    {
        // add underline style
        InnerLabel.TextDecorations = TextDecorations.Underline;
        InnerLabel.TextColor = Colors.MidnightBlue; // optional override
    }
}
