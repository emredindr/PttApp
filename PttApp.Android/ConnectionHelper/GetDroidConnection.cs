using PttApp.Application.Abstractions;
using PttApp.Droid.ConnectionHelper;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(GetDroidConnection))]
namespace PttApp.Droid.ConnectionHelper
{

    public class GetDroidConnection : ISQLiteConnection
    {
        //public const SQLiteOpenFlags Flags =
        //    // open the database in read/write mode
        //    SQLiteOpenFlags.ReadWrite |
        //    // create the database if it doesn't exist
        //    SQLiteOpenFlags.Create;

        public SQLiteConnection GetConnection()
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, App.DbName);
            //var platform = new SQLitePlatformAndroid();

            // var connection = new SQLiteConnection(path, Flags);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }

}