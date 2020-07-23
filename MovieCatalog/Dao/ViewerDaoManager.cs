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

        public (Viewer, Exception) Login(string username, string password)
        {
            var viewer = FindViewerByUsername(username);
            if (viewer == null)
                return (null, new Exception($"Пользователь под именем {username} не найден."));

            if (viewer.Password != password)
                return (null, new Exception("Введенный вами пароль и логин не удалось авторизовать."));
            return (viewer, null);
        }

        public (Viewer, Exception) Register(string username, string password)
        {
            Viewer viewer = FindViewerByUsername(username);
            if (viewer != null)
                return (viewer, new Exception("Пользователь с таким именем уже существует."));

            viewer = new Viewer();
            viewer.Username = username;
            viewer.Password = password;
            Add(viewer);
            return (viewer, null);
        }

        public Viewer FindViewerByUsername(string username)
        {
            return GetAll()
                .SingleOrDefault(viewer => viewer.Username.Equals(username.ToLower()));
        }

    }
}
