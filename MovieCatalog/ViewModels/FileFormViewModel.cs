using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public class FileFormViewModel : BaseFormViewModel
    {

        public IEnumerable<CoverFile> Files { get; set; }

    }

    public class CoverFile
    {

        public string Url { get; set; }

        public string Name { get; set; }

    }
}
