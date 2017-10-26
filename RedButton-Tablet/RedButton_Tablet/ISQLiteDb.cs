using SQLite;

namespace RedButton_Tablet
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

