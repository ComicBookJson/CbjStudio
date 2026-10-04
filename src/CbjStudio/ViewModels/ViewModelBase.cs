using CommunityToolkit.Mvvm.ComponentModel;

namespace CbjStudio.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] public partial string Title { get; set; } = string.Empty;
}
