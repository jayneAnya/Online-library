using PioneerOnlineLibrary.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PioneerOnlineLibrary.Domain.Model
{
	public class Book
	{
		public int BookId { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string ISBN { get; set; } = null!;
		public string Author { get; set; } = null!;
		public string Genre { get; set; } = null!;
		public int Pages { get; set; }
		

		[Column(TypeName = "decimal(6,2)")]
		public decimal Price { get; set; }
		public string PublicationDate { get; set; } = null!;
		public string Publisher { get; set; } = null!;
		public bool IsAvailable { get; set; }
		public string Language { get; set; } = null!;

		//book categories e.g Most recent, most popular etc
		public string BookCategory { get; set; } = null!;

		public string ImageURL { get; set; } = null!;


    }
}
