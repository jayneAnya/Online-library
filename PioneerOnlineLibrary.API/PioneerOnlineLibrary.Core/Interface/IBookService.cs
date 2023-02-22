using PioneerOnlineLibrary.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerOnlineLibrary.Core.Interface
{
    public interface IBookService
    {
        Book GetByISBN(string ISBN);

        Book GetByTitle(string title);
        Book GetByAuthor(string author);
        Book GetByPublisher(string publisher);
        Book GetByDatePublished(string datePublished);
    }
}
