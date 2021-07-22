using SQLite;
using System;

namespace ContactAppDesktop
{
    internal class SQlLiteConnection
    {
        public SQlLiteConnection(string dataBasePath)
        {
        }

        public static implicit operator SQlLiteConnection(SQLiteConnection v)
        {
            throw new NotImplementedException();
        }
    }
}