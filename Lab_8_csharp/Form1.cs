using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8_csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BookCollection collection = new BookCollection();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            collection.AddBook(new Book("Book1", "Publisher1", 2018, 200, 10m));
            collection.AddBook(new Book("Book2", "Publisher2", 2022, 300, 15m));
            collection.AddBook(new Book("Book3", "Publisher1", 2019, 150, 8m));
            richTextBox1.Text = collection.DisplayBooks();
        }
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            collection.SaveToFile(saveFileDialog1.FileName);
        }
        private void відкритиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            collection.LoadFromFile(openFileDialog1.FileName);
            richTextBox1.Text += ("Openned:\n");
            richTextBox1.Text += collection.DisplayBooks();
        }
        private void button2_Click_1(object sender, EventArgs e)
        { 
           collection.Clearbooks();
           richTextBox1.Text = "";
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            collection.SortBy(b => b.Publisher);
            richTextBox1.Text += ("Sorted by publisher:\n");
            richTextBox1.Text += collection.DisplayBooks();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            collection.ApplyDiscount(book => DateTime.Now.Year - book.Year > 2);
            richTextBox1.Text += ("Changed Price:\n");
            richTextBox1.Text += collection.DisplayBooks();
        }

    }
}
