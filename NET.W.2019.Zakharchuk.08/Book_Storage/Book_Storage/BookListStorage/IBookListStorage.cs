using System.Collections.Generic;

namespace Book_Storage
{
    internal interface IBookListStorage
    {
        void SaveToStorage(IEnumerable<Book> books);

        IEnumerable<Book> ReadStorage();
    }
}
