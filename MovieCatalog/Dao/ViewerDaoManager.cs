using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalog.Dao
{
    public class ViewerDaoManager : BaseDaoManager<Viewer>
    {

        public ViewerDaoManager(MovieCatalogContext context)
            : base(context)
        {}

        public Viewer Login(string username, string password)
        {
            var viewer = FindViewerByUsername(username);
            if (viewer.Password != password)
                return null;
            return viewer;
        }

        public Viewer Register(string username, string password)
        {
            Viewer viewer = new Viewer();
            viewer.Username = username;
            viewer.Password = password;
            Add(viewer);
            return viewer;
        }

        public Viewer FindViewerByUsername(string username)
        {
            return GetAll()
                .SingleOrDefault(viewer => viewer.Username.Equals(username.ToLower()));
        }

    }
}
