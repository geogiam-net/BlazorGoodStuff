namespace BlazorWeb.Components;

public partial class ColorAlert
{
    protected string Color = "red";

    public void Dismiss()
    {
        Color = "blue";
        this.StateHasChanged();
    }
}