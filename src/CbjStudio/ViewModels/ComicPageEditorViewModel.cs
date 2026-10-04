using CommunityToolkit.Mvvm.ComponentModel;
using CbjSdk;

namespace CbjStudio.ViewModels;

public partial class ComicPageEditorViewModel : ObservableObject
{
    [ObservableProperty] private int index;
    [ObservableProperty] private string fileName = string.Empty;
    [ObservableProperty] private ImageSource? preview;
    [ObservableProperty] private bool doublePage;
    [ObservableProperty] private string pageType = "Story";

    public PageElement Model { get; }

    public ComicPageEditorViewModel(PageElement model, string fileName, ImageSource preview, int index)
    {
        Model = model;
        this.index = index;
        this.fileName = fileName;
        this.preview = preview;
        doublePage = model.DoublePage ?? false;
        pageType = model.Type?.FirstOrDefault()?.ToString() ?? "Story";
    }

    partial void OnDoublePageChanged(bool value) => Model.DoublePage = value;

    partial void OnPageTypeChanged(string value)
    {
        if (Enum.TryParse<TypeElement>(value, out var type))
            Model.Type = [type];
    }
}
