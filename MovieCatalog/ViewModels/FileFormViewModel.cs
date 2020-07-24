using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModels
{
    public class FileFormViewModel
    {

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        public string FormPostUrl { get; set; }

        public IEnumerable<CoverFile> Files { get; set; }

    }

    public class CoverFile
    {

        public string Url { get; set; }

        public string Name { get; set; }

    }
}
