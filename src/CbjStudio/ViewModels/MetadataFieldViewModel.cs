using CommunityToolkit.Mvvm.ComponentModel;

namespace CbjStudio.ViewModels;

public partial class MetadataFieldViewModel : ObservableObject
{
    [ObservableProperty] private string name;
    [ObservableProperty] private string label;
    [ObservableProperty] private string value;

    public IReadOnlyList<string> Options { get; }
    public bool IsChoice => Options.Count > 0;

    public MetadataFieldViewModel(string name, string value, IEnumerable<string>? options = null)
    {
        this.name = name;
        label = name;
        this.value = value;
        Options = options?.ToArray() ?? [];
    }
}
