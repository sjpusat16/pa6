using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
	public partial class frmMain : Form
	{

		string cwid;
		List<Book> myBooks;
		public frmMain(string tempCwid)
		{
			this.cwid = tempCwid;
			InitializeComponent();
			pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadList()
		{
			myBooks = BookFile.GetAllBooks(cwid);
			listBooks.DataSource = myBooks;
		}

		private void button1_Click_3(object sender, EventArgs e)
		{
			this.Close();
		}

		private void listBooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			Book myBook = (Book)listBooks.SelectedItem;

			txtTitle.Text = myBook.title;
			txtAuthor.Text = myBook.author;
			txtGenre.Text = myBook.genre;
			txtCopies.Text = myBook.copies.ToString();
			txtLength.Text = myBook.length.ToString();
			txtISBN.Text = myBook.isbn;

			try
			{
				pbCover.Load(myBook.cover);
			}
			catch
			{

			}
		}

        private void btnRent_Click(object sender, EventArgs e)
        {
			Book myBook = (Book)listBooks.SelectedItem;
			myBook.copies--;
			BookFile.SaveBook(myBook, cwid, "edit");
			LoadList();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
			Book myBook = (Book)listBooks.SelectedItem;
			myBook.copies++;
			BookFile.SaveBook(myBook, cwid, "edit");
			LoadList();
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
			Book myBook = (Book)listBooks.SelectedItem;
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this", "Delete", MessageBoxButtons.YesNo); 

			if(dialogResult == DialogResult.Yes)
            {
				BookFile.DeleteBook(myBook, cwid);
				LoadList();
            }
		}

        private void btnEdit_Click(object sender, EventArgs e)
        {
			Book myBook = (Book)listBooks.SelectedItem;
			frmEdit myForm = new frmEdit(myBook, "edit", cwid);
			if(myForm.ShowDialog() == DialogResult.OK)
            {

            }
			else
            {
				LoadList();

            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
			Book myBook = new Book();
			frmEdit myForm = new frmEdit(myBook, "new", cwid);
			if (myForm.ShowDialog() == DialogResult.OK)
			{

			}
			else
			{
				LoadList();

			}
		}
    }
}
