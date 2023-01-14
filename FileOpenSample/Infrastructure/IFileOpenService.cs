using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileOpenSample.Infrastructure;

public interface IFileOpenService
{
    Task<string?> PickFile(IDictionary<string, IEnumerable<string>> filters);
}