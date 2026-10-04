using CbjStudio.ViewModels;

namespace CbjStudio.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Shell creates MainPage from the ShellContent DataTemplate. Explicitly
        // assign the view model so compiled bindings and generated commands are
        // available to every button on the page.
        BindingContext = new MainViewModel();
    }
}
