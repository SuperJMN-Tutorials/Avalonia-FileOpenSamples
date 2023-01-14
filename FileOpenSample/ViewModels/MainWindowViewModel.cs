using System;
using System.Collections.Generic;
using System.Reactive;
using FileOpenSample.Infrastructure;
using ReactiveUI;

namespace FileOpenSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IFileOpenService fileOpenService)
        {
            var filters = new Dictionary<string, IEnumerable<string>>
            {
                ["Images"] = new[] { "jpg", "bmp", "gif", "png", "jpeg" },
                ["Documents"] = new[] { "doc", "docx", "pdf", "txt" },
            };

            OpenFile = ReactiveCommand.CreateFromTask(() => fileOpenService.PickFile(filters));

            SelectedFile = OpenFile.WhereNotNull();
        }

        public IObservable<string> SelectedFile { get; }

        public ReactiveCommand<Unit, string?> OpenFile { get; }
    }
}
