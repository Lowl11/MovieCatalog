using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Models
{
    public class Movie : DbModel
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public int? PublishYear { get; set; }

        public string Producer { get; set; }

        public string CoverUrl { get; set; }

        public int AuthorId { get; set; }

        public Viewer Author { get; set; }

    }
}
