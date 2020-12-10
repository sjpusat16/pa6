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
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;
        public frmEdit(Object tempbook, string tempmode, string tempcwid)
        {
            myBook = (Book)tempbook;
            cwid = tempcwid;
            mode = tempmode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitle.Text = myBook.title;
                txtAuthor.Text = myBook.author;
                txtGenre.Text = myBook.genre;
                txtCopies.Text = myBook.copies.ToString();
                txtISBN.Text = myBook.isbn.ToString();
                txtCoverURL.Text = myBook.cover;
                txtLength.Text = myBook.length.ToString();

                pbCover.Load(myBook.cover);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitle.Text;
            myBook.author = txtAuthor.Text;
            myBook.genre = txtGenre.Text;
            myBook.copies = int.Parse(txtCopies.Text);
            myBook.isbn = txtISBN.Text;
            myBook.cover = txtCoverURL.Text;
            myBook.length = int.Parse(txtLength.Text);
            myBook.cwid = cwid;

            BookFile.SaveBook(myBook, cwid, mode);
            MessageBox.Show("Content was saved", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
