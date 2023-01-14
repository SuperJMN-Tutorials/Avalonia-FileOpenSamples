using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace FileOpenSample.Infrastructure;

public class AvaloniaDesktopOpenFileService : IFileOpenService
{
    public async Task<string?> PickFile(IDictionary<string, IEnumerable<string>> filters)
    {
        var openFileDialog = new OpenFileDialog
        {
            AllowMultiple = false,
            Filters = ToAvaloniaFilters(filters)
        };

        var mainWindow = GetMainWindow();
        var selection = await openFileDialog.ShowAsync(mainWindow);

        return selection?.FirstOrDefault();
    }

    private static Window GetMainWindow()
    {
        if (Application.Current is { ApplicationLifetime: ClassicDesktopStyleApplicationLifetime l })
        {
            return l.MainWindow;
        }

        throw new NotSupportedException("This service is designed to work with an application with ApplicationLifetime=ClassicDesktopStyleApplicationLifetime");
    }

    private static List<FileDialogFilter> ToAvaloniaFilters(IDictionary<string, IEnumerable<string>> filters)
    {
        return filters.Select(f => new FileDialogFilter { Name = f.Key, Extensions = f.Value.ToList() }).ToList();
    }
}