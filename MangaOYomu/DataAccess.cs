using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaOYomu
{
    class DataAccess
    {
        public static List<MangaTitle> GetMangaTitles()
        {
            List<MangaTitle> mangaTitles = new List<MangaTitle>(DBConnection.connection.MangaTitle);
            List<MangaTitle> manga = new List<MangaTitle>();
            foreach (var item in mangaTitles)
            {
                manga.Add(
                    new MangaTitle
                    {
                        MangaTitleID = item.MangaTitleID,
                        Name = item.Name,
                        Description = item.Description,
                        ReleaseYear = item.ReleaseYear,
                        Rating = item.Rating,
                        Cover = item.Cover,
                        MangaTypeID = item.MangaTypeID,
                        TitleStatusID = item.TitleStatusID,
                        PublisherID = item.PublisherID,
                        AuthorID = item.AuthorID,
                        ArtistID = item.ArtistID,
                        AgeStatusID = item.AgeStatusID
                    });
            }
            return manga;
        }

        public static bool AddNewMangaTitle(string newName, string newDescription, int newReleaseYear, decimal newRating,
            string newCover, int newMangaTypeID, int newTitleStatusID, int newPublisherID, int newAuthorID, int newArtistID, int newAgeStatusID)
        {
            try
            {
                MangaTitle mangaTitle = new MangaTitle()
                {
                    Name = newName,
                    Description = newDescription,
                    ReleaseYear = newReleaseYear,
                    Rating = newRating,
                    Cover = newCover,
                    MangaTypeID = newMangaTypeID,
                    TitleStatusID = newTitleStatusID,
                    PublisherID = newPublisherID,
                    AuthorID = newAuthorID,
                    ArtistID = newArtistID,
                    AgeStatusID = newAgeStatusID
                };

                DBConnection.connection.MangaTitle.Add(mangaTitle);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewMangaTitle(MangaTitle mangaTitle)
        {
            try
            {
                DBConnection.connection.MangaTitle.Add(mangaTitle);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static MangaTitle GetMangaTitle(int id)
        {
            List<MangaTitle> mangaTitles = GetMangaTitles();
            return mangaTitles.FirstOrDefault(t => t.MangaTitleID == id);
        }

        public static MangaTitle GetMangaTitle(string name)
        {
            List<MangaTitle> mangaTitles = GetMangaTitles();
            return mangaTitles.FirstOrDefault(t => t.Name == name);
        }

        public static void DeleteMangaTitle(MangaTitle mangaTitle)
        {
            DBConnection.connection.MangaTitle.Remove(mangaTitle);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteMangaTitle(int id)
        {
            List<MangaTitle> mangaTitles = GetMangaTitles();
            var mangaTitle = mangaTitles.FirstOrDefault(t => t.MangaTitleID == id);

            DBConnection.connection.MangaTitle.Remove(mangaTitle);
            DBConnection.connection.SaveChanges();
        }

        //?
        public static void UpdateMangaTitle(int id, MangaTitle mangaTitle)
        {
            DBConnection.connection.MangaTitle.SingleOrDefault(t => t.MangaTitleID == id);
            DBConnection.connection.SaveChanges();
        }


        //////////////////////////////////////////////////////////
        public static List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>(DBConnection.connection.Author);
            List<Author> author = new List<Author>();
            foreach (var item in authors)
            {
                author.Add(
                    new Author
                    {
                        AuthorID = item.AuthorID,
                        Name = item.Name
                    });
            }
            return author;
        }

        public static bool AddNewAuthor(Author author)
        {
            try
            {
                DBConnection.connection.Author.Add(author);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewAuthor(string newName)
        {
            try
            {
                Author author = new Author()
                {
                    Name = newName
                };

                DBConnection.connection.Author.Add(author);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Author GetAuthor(int id)
        {
            List<Author> authors = GetAuthors();
            return authors.FirstOrDefault(t => t.AuthorID == id);
        }

        public static Author GetAuthor(string name)
        {
            List<Author> authors = GetAuthors();
            return authors.FirstOrDefault(t => t.Name == name);
        }

        public static void DeleteAuthor(Author author)
        {
            DBConnection.connection.Author.Remove(author);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteAuthor(int id)
        {
            List<Author> authors = GetAuthors();
            var author = authors.FirstOrDefault(t => t.AuthorID == id);

            DBConnection.connection.Author.Remove(author);
            DBConnection.connection.SaveChanges();
        }

        public static void UpdateAuthor(int id, Author author)
        {
            DBConnection.connection.Author.SingleOrDefault(t => t.AuthorID == id);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<MangaType> GetMangaTypes()
        {
            List<MangaType> mangaTypes = new List<MangaType>(DBConnection.connection.MangaType);
            List<MangaType> mangaType = new List<MangaType>();
            foreach (var item in mangaTypes)
            {
                mangaType.Add(
                    new MangaType
                    {
                        MangaTypeID = item.MangaTypeID,
                        Name = item.Name
                    });
            }
            return mangaType;
        }

        public static MangaType GetMangaType(int id)
        {
            List<MangaType> mangaTypes = GetMangaTypes();
            return mangaTypes.FirstOrDefault(t => t.MangaTypeID == id);
        }

        public static MangaType GetMangaType(string name)
        {
            List<MangaType> mangaTypes = GetMangaTypes();
            return mangaTypes.FirstOrDefault(t => t.Name == name);
        }

        //////////////////////////////////////////////////////////
        public static List<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>(DBConnection.connection.Artist);
            List<Artist> artist = new List<Artist>();
            foreach (var item in artists)
            {
                artist.Add(
                    new Artist
                    {
                        ArtistID = item.ArtistID,
                        Name = item.Name
                    });
            }
            return artist;
        }

        public static bool AddNewArtist(string newName)
        {
            try
            {
                Artist artist = new Artist()
                {
                    Name = newName
                };

                DBConnection.connection.Artist.Add(artist);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewArtist(Artist artist)
        {
            try
            {
                DBConnection.connection.Artist.Add(artist);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Artist GetArtist(int id)
        {
            List<Artist> artists = GetArtists();
            return artists.FirstOrDefault(t => t.ArtistID == id);
        }

        public static Artist GetArtist(string name)
        {
            List<Artist> artists = GetArtists();
            return artists.FirstOrDefault(t => t.Name == name);
        }

        public static void UpdateArtist(int id, Artist artist)
        {
            DBConnection.connection.Artist.SingleOrDefault(t => t.ArtistID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteArtist(Artist artist)
        {
            DBConnection.connection.Artist.Remove(artist);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteArtist(int id)
        {
            List<Artist> artists = GetArtists();
            var artist = artists.FirstOrDefault(t => t.ArtistID == id);

            DBConnection.connection.Artist.Remove(artist);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<Publisher> GetPublishers()
        {
            List<Publisher> publishers = new List<Publisher>(DBConnection.connection.Publisher);
            List<Publisher> publisher = new List<Publisher>();
            foreach (var item in publishers)
            {
                publisher.Add(
                    new Publisher
                    {
                        PublisherID = item.PublisherID,
                        Name = item.Name
                    });
            }
            return publisher;
        }

        public static bool AddNewPublisher(string newName)
        {
            try
            {
                Publisher publisher = new Publisher()
                {
                    Name = newName
                };

                DBConnection.connection.Publisher.Add(publisher);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewPublisher(Publisher publisher)
        {
            try
            {
                DBConnection.connection.Publisher.Add(publisher);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Publisher GetPublisher(int id)
        {
            List<Publisher> publishers = GetPublishers();
            return publishers.FirstOrDefault(t => t.PublisherID == id);
        }

        public static Publisher GetPublisher(string name)
        {
            List<Publisher> publishers = GetPublishers();
            return publishers.FirstOrDefault(t => t.Name == name);
        }

        public static void UpdatePublisher(int id, Publisher publisher)
        {
            DBConnection.connection.Publisher.SingleOrDefault(t => t.PublisherID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeletePublisher(Publisher publisher)
        {
            DBConnection.connection.Publisher.Remove(publisher);
            DBConnection.connection.SaveChanges();
        }

        public static void DeletePublisher(int id)
        {
            List<Publisher> publishers = GetPublishers();
            var publisher = publishers.FirstOrDefault(t => t.PublisherID == id);

            DBConnection.connection.Publisher.Remove(publisher);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<AgeStatus> GetAgeStatuses()
        {
            List<AgeStatus> ageStatuses = new List<AgeStatus>(DBConnection.connection.AgeStatus);
            List<AgeStatus> ageStatus = new List<AgeStatus>();
            foreach (var item in ageStatuses)
            {
                ageStatus.Add(
                    new AgeStatus
                    {
                        AgeStatusID = item.AgeStatusID,
                        Name = item.Name
                    });
            }
            return ageStatus;
        }

        public static AgeStatus GetAgeStatus(int id)
        {
            List<AgeStatus> ageStatuses = GetAgeStatuses();
            return ageStatuses.FirstOrDefault(t => t.AgeStatusID == id);
        }

        public static AgeStatus GetAgeStatus(string name)
        {
            List<AgeStatus> ageStatuses = GetAgeStatuses();
            return ageStatuses.FirstOrDefault(t => t.Name == name);
        }

        //////////////////////////////////////////////////////////
        public static List<TitleStatus> GetTitleStatuses()
        {
            List<TitleStatus> titleStatuses = new List<TitleStatus>(DBConnection.connection.TitleStatus);
            List<TitleStatus> titleStatus = new List<TitleStatus>();
            foreach (var item in titleStatuses)
            {
                titleStatus.Add(
                    new TitleStatus
                    {
                        TitleStatusID = item.TitleStatusID,
                        Name = item.Name
                    });
            }
            return titleStatus;
        }

        public static TitleStatus GetTitleStatus(int id)
        {
            List<TitleStatus> titleStatuses = GetTitleStatuses();
            return titleStatuses.FirstOrDefault(t => t.TitleStatusID == id);
        }

        public static TitleStatus GetTitleStatus(string name)
        {
            List<TitleStatus> titleStatuses = GetTitleStatuses();
            return titleStatuses.FirstOrDefault(t => t.Name == name);
        }

        //////////////////////////////////////////////////////////
        public static List<Chapters> GetChapters()
        {
            List<Chapters> chapters = new List<Chapters>(DBConnection.connection.Chapters);
            List<Chapters> chapter = new List<Chapters>();
            foreach (var item in chapters)
            {
                chapter.Add(
                    new Chapters
                    {
                        ChaptersID = item.ChaptersID,
                        Name = item.Name,
                        MangaTitleID = item.MangaTitleID
                    });
            }
            return chapter;
        }

        public static bool AddNewChapter(string newName, int newMangaTitleID)
        {
            try
            {
                Chapters chapter = new Chapters()
                {
                    Name = newName,
                    MangaTitleID = newMangaTitleID
                };

                DBConnection.connection.Chapters.Add(chapter);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewChapter(Chapters chapter)
        {
            try
            {
                DBConnection.connection.Chapters.Add(chapter);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Chapters GetChapter(int id)
        {
            List<Chapters> chapters = GetChapters();
            return chapters.FirstOrDefault(t => t.ChaptersID == id);
        }

        public static Chapters GetChapter(string name)
        {
            List<Chapters> chapters = GetChapters();
            return chapters.FirstOrDefault(t => t.Name == name);
        }

        public static void UpdateChapter(int id, Chapters chapter)
        {
            DBConnection.connection.Chapters.SingleOrDefault(t => t.ChaptersID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteChapters(Chapters chapter)
        {
            DBConnection.connection.Chapters.Remove(chapter);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteChapters(int id)
        {
            List<Chapters> chapters = GetChapters();
            var chapter = chapters.FirstOrDefault(t => t.ChaptersID == id);

            DBConnection.connection.Chapters.Remove(chapter);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<Pages> GetPages()
        {
            List<Pages> pages = new List<Pages>(DBConnection.connection.Pages);
            List<Pages> page = new List<Pages>();
            foreach (var item in pages)
            {
                page.Add(
                    new Pages
                    {
                        PagesID = item.PagesID,
                        Image = item.Image,
                        ChaptersID = item.ChaptersID
                    });
            }
            return page;
        }

        public static bool AddNewPage(string newImage, int newChaptersID)
        {
            try
            {
                Pages page = new Pages()
                {
                    Image = newImage,
                    ChaptersID = newChaptersID
                };

                DBConnection.connection.Pages.Add(page);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewPage(Pages page)
        {
            try
            {
                DBConnection.connection.Pages.Add(page);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Pages GetPage(int id)
        {
            List<Pages> pages = GetPages();
            return pages.FirstOrDefault(t => t.PagesID == id);
        }

        public static void UpdatePage(int id, Pages page)
        {
            DBConnection.connection.Pages.SingleOrDefault(t => t.PagesID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeletePage(Pages page)
        {
            DBConnection.connection.Pages.Remove(page);
            DBConnection.connection.SaveChanges();
        }

        public static void DeletePage(int id)
        {
            List<Pages> pages = GetPages();
            var page = pages.FirstOrDefault(t => t.PagesID == id);

            DBConnection.connection.Pages.Remove(page);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<Genres> GetGenres()
        {
            List<Genres> genres = new List<Genres>(DBConnection.connection.Genres);
            List<Genres> genre = new List<Genres>();
            foreach (var item in genres)
            {
                genre.Add(
                    new Genres
                    {
                        GenresID = item.GenresID,
                        Name = item.Name,
                        Description = item.Description
                    });
            }
            return genre;
        }

        public static bool AddNewGenre(string newName, string newDescription)
        {
            try
            {
                Genres genre = new Genres()
                {
                    Name = newName,
                    Description = newDescription
                };

                DBConnection.connection.Genres.Add(genre);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewGenre(Genres genre)
        {
            try
            {
                DBConnection.connection.Genres.Add(genre);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Genres GetGenre(int id)
        {
            List<Genres> genres = GetGenres();
            return genres.FirstOrDefault(t => t.GenresID == id);
        }
        public static Genres GetGenre(string name)
        {
            List<Genres> genres = GetGenres();
            return genres.FirstOrDefault(t => t.Name == name);
        }

        public static void UpdateGenres(int id, Genres genre)
        {
            DBConnection.connection.Genres.SingleOrDefault(t => t.GenresID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteGenre(Genres genre)
        {
            DBConnection.connection.Genres.Remove(genre);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteGenre(int id)
        {
            List<Genres> genres = GetGenres();
            var genre = genres.FirstOrDefault(t => t.GenresID == id);

            DBConnection.connection.Genres.Remove(genre);
            DBConnection.connection.SaveChanges();
        }

        //////////////////////////////////////////////////////////
        public static List<MangaTitleGenres> GetMangaTitleGenres()
        {
            List<MangaTitleGenres> mangaTitleGenres = new List<MangaTitleGenres>(DBConnection.connection.MangaTitleGenres);
            List<MangaTitleGenres> mangaTitleGenre = new List<MangaTitleGenres>();
            foreach (var item in mangaTitleGenres)
            {
                mangaTitleGenre.Add(
                    new MangaTitleGenres
                    {
                        MangaTitleGenresID = item.MangaTitleGenresID,
                        MangaTitleID = item.MangaTitleID,
                        GenresID = item.GenresID
                    });
            }
            return mangaTitleGenre;
        }

        public static bool AddNewMangaTitleGenre(int newMangaTitleID, int newGenresID)
        {
            try
            {
                MangaTitleGenres mangaTitleGenre = new MangaTitleGenres()
                {
                    MangaTitleID = newMangaTitleID,
                    GenresID = newGenresID
                };

                DBConnection.connection.MangaTitleGenres.Add(mangaTitleGenre);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewMangaTitleGenre(MangaTitleGenres mangaTitleGenre)
        {
            try
            {
                DBConnection.connection.MangaTitleGenres.Add(mangaTitleGenre);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static MangaTitleGenres GetMangaTitleGenre(int id)
        {
            List<MangaTitleGenres> mangaTitleGenres = GetMangaTitleGenres();
            return mangaTitleGenres.FirstOrDefault(t => t.MangaTitleGenresID == id);
        }

        public static void UpdateMangaTitleGenre(int id, MangaTitleGenres mangaTitleGenre)
        {
            DBConnection.connection.MangaTitleGenres.SingleOrDefault(t => t.MangaTitleGenresID == id);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteMangaTitleGenre(MangaTitleGenres mangaTitleGenre)
        {
            DBConnection.connection.MangaTitleGenres.Remove(mangaTitleGenre);
            DBConnection.connection.SaveChanges();
        }

        public static void DeleteMangaTitleGenres(int id)
        {
            List<MangaTitleGenres> mangaTitleGenres = GetMangaTitleGenres();
            var mangaTitleGenre = mangaTitleGenres.FirstOrDefault(t => t.MangaTitleGenresID == id);

            DBConnection.connection.MangaTitleGenres.Remove(mangaTitleGenre);
            DBConnection.connection.SaveChanges();
        }
    }
}
