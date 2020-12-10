using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA6
{
	class Book
	{
		public Book(string cwid, string isbn, string title, string author, string genre, string cover, int length, int copies, string id)
		{
			this.cwid = cwid;
			this.isbn = isbn;
			this.title = title;
			this.author = author;
			this.genre = genre;
			this.cover = cover;
			this.length = length;
			this.copies = copies;
			_id = id;
		}

		public String cwid { get; set; }
		public String isbn { get; set; }
		public String title { get; set; }
		public String author { get; set; }
		public String genre { get; set; }
		public String cover { get; set; }
		public int length { get; set; }
		public int copies { get; set; }
		public String _id { get; set; }

		public Book()
		{

		}

		public override string ToString()
		{
			return this.title;
		}
	}
}
