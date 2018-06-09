using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChurchAddIn
{
    public partial class BibleForm : Form
    {
        private BibleVersion version;
        private Bible bible = null;
        private Book currentBook = null;
        private Chapter currentChapter = null;
        private int fromBook;
        private int toBook;
        public BibleForm(BibleVersion version)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.version = version;
            GetBibleName();
            LoadBibleOnForm();
            bibleTextBox.ContextMenuStrip = contextMenuStrip1;
            searchBox.ContextMenuStrip = contextMenuStrip2;
            fromComboBox.Items.AddRange(bible.Books.Select(book => book.Name).ToArray());
            fromComboBox.SelectedIndex = 0;
            toComboBox.Items.AddRange(bible.Books.Select(book => book.Name).ToArray());
            toComboBox.SelectedIndex = bible.Books.Count - 1;
        }

        [DllImport("user32.dll")]
        public static extern int SetCursor(IntPtr cursor);

        private const int WM_SETCURSOR = 0x20;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (IsCursorInControl(bibleTextBox) || IsCursorInControl(searchBox))
            {

                if (m.Msg == WM_SETCURSOR)
                {
                    SetCursor(Cursors.IBeam.Handle);
                    m.Result = new IntPtr(1); //Signify that we dealt with the message. We should be returning "true", but I can't figure out how to do that.
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private bool IsCursorInControl(Control control)
        {
            var cursPos = PointToClient(Cursor.Position);

            return cursPos.X >= control.Location.X &&
                   cursPos.X <= control.Location.X + control.Size.Width &&
                   cursPos.Y >= control.Location.Y &&
                   cursPos.Y <= control.Location.Y + control.Size.Height;
        }

        private void TitleName(string book = null, string chapter = null)
        {
            label2.Text = book + ": " + chapter;
            if (version == BibleVersion.RusianNew)
            {
                this.Text = "Новый русский перевод ";
            }
            else if (version == BibleVersion.RusianSynodal)
            {
                this.Text = "Синодальный перевод ";
            }
            else if (version == BibleVersion.UkranianOgiyenko)
            {
                this.Text = "Переклад І.Огієнка ";
            }
            else if (version == BibleVersion.EnglishKJV)
            {
                this.Text = "English KJV ";
            }
            else if (version == BibleVersion.EnglishASV)
            {
                this.Text = "English ASV ";
            }
            else if (version == BibleVersion.EnglishNIV)
            {
                this.Text = "English NIV ";
            }
            else if (version == BibleVersion.EnglishESV)
            {
                this.Text = "English ESV ";
            }
            else
            {
                this.Text = "English NIV ";
            }
            if (book != null)
            {
                this.Text += book;
                if (chapter != null)
                {
                    this.Text += ": " + chapter;
                }
            }
        }

        private void GetBibleName()
        {
            var content = "";
            if (version == BibleVersion.EnglishESV)
            {
                Text = "English ESV";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/ESV.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.RusianNew)
            {
                Text = "Новый русский перевод";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/NRT.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.RusianSynodal)
            {
                Text = "Синодальный перевод";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/Synodal.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.UkranianOgiyenko)
            {
                Text = "Переклад І.Огієнка";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/UKR.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.EnglishKJV)
            {
                Text = "English KJV";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/KJV.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.EnglishASV)
            {
                Text = "English ASV";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/ASV.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }
            if (version == BibleVersion.EnglishNIV)
            {
                Text = "English NIV";
                using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/NIV.json", Encoding.UTF8))
                {
                    content = stream.ReadToEnd();
                }
                bible = JsonConvert.DeserializeObject<Bible>(content);
                return;
            }

            Text = "English NIV";
            using (var stream = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"/Bibles.min/NIV.json", Encoding.UTF8))
            {
                content = stream.ReadToEnd();
            }
            bible = JsonConvert.DeserializeObject<Bible>(content);
        }

        private void LoadBibleOnForm()
        {
            if (bible != null)
            {
                treeChapterView.Nodes.Clear();
                foreach (var book in bible.Books)
                {
                    var node = new TreeNode(book.Name);
                    foreach (var chapter in book.Chapters)
                    {
                        var childNode = new TreeNode(chapter.Number.ToString());
                        //foreach (var verse in chapter.Verses)
                        //{
                        //    childNode.Nodes.Add(verse.Number.ToString());
                        //}
                        node.Nodes.Add(childNode);
                    }
                    treeChapterView.Nodes.Add(node);
                }
            }
        }

        private void treeChapterView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                WriteChapterOnForm(e.Node.Parent, e.Node);
                return;
            }

            if (e.Node.Level == 2)
            {
                WriteChapterOnForm(e.Node.Parent.Parent, e.Node.Parent, e.Node);
                return;
            }
        }

        private void WriteChapterOnForm(TreeNode book, TreeNode chapter, TreeNode verse = null)
        {
            WriteChapterOnForm(book.Text, chapter.Text, verse?.Text);
        }

        private void WriteChapterOnForm(string book, string chapter, string verse = null)
        {
            TitleName(book, chapter);
            currentBook = bible.Books.FirstOrDefault(bk => bk.Name.Equals(book));
            if (currentBook != null)
            {
                currentChapter = currentBook.Chapters.FirstOrDefault(ch => ch.Number.ToString().Equals(chapter));
                if (currentChapter != null)
                {
                    if (currentChapter.Number == 1 && currentBook.Number == 1)
                    {
                        prevButton.Enabled = false;
                    }
                    else
                    {
                        prevButton.Enabled = true;
                    }

                    if (currentChapter.Number == currentBook.Chapters.Count && currentBook.Number == 66)
                    {
                        nextButton.Enabled = false;
                    }
                    else
                    {
                        nextButton.Enabled = true;
                    }

                    bibleTextBox.Text = "";
                    foreach (var ver in currentChapter.Verses)
                    {
                        var tempVerse = ver.Text + " ";
                        if (verseNumberCheckBox.Checked && ver.Number > 0)
                        {
                            if (ver.Number < 10 && paragrapgCheckBox.Checked)
                                tempVerse = " " + ver.Number.ToString() + ". ";
                            else
                                tempVerse = ver.Number.ToString() + ". ";
                            tempVerse += ver.Text[0].ToString().ToUpper() + ver.Text.Substring(1) + " ";
                        }
                        if (paragrapgCheckBox.Checked)
                        {
                            tempVerse += Environment.NewLine;
                        }
                        bibleTextBox.Text += tempVerse;
                    }
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var node = treeChapterView.SelectedNode;
            if (node == null)
                return;
            if (node.Level == 1)
            {
                WriteChapterOnForm(node.Parent, node);
                return;
            }
            if (node.Level == 2)
            {
                WriteChapterOnForm(node.Parent.Parent, node.Parent, node);
                return;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bibleTextBox.SelectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bibleTextBox.Copy();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bibleTextBox.SelectAll();
            bibleTextBox.Copy();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentChapter.Number == currentBook.Chapters.Count)
            {
                var newBook = bible.Books.FirstOrDefault(book => book.Number == currentBook.Number + 1);
                if (newBook != null)
                {
                    WriteChapterOnForm(newBook.Name, "1");
                }
            }
            else
            {
                WriteChapterOnForm(currentBook.Name, (currentChapter.Number + 1).ToString());
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (currentChapter.Number == 1)
            {
                var newBook = bible.Books.FirstOrDefault(book => book.Number == currentBook.Number - 1);
                if (newBook != null)
                {
                    WriteChapterOnForm(newBook.Name, newBook.Chapters.Count.ToString());
                }
            }
            else
            {
                WriteChapterOnForm(currentBook.Name, (currentChapter.Number - 1).ToString());
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            searchBox.SelectAll();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            searchBox.Copy();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            searchBox.SelectAll();
            searchBox.Copy();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                return;
            }
            GetBibleName();
            label2.Text = searchBox.Text;
            bibleTextBox.Clear();
            treeChapterView.SelectedNode = null;
            nextButton.Enabled = false;
            prevButton.Enabled = false;
            searchButton.Enabled = false;
            paragrapgCheckBox.Enabled = false;
            verseNumberCheckBox.Enabled = false;
            treeChapterView.Enabled = false;
            fromComboBox.Enabled = false;
            toComboBox.Enabled = false;
            var str = searchBox.Text.Trim().ToUpper();
            var strBuilder = new StringBuilder();
            var startBook = fromComboBox.Text;
            var endBook = toComboBox.Text;
            await Task.Factory.StartNew(() =>
            {
                bool isInBooksRange = false;
                foreach (var book in bible.Books)
                {
                    if (book.Name == startBook)
                    {
                        isInBooksRange = true;
                    }
                    if (isInBooksRange)
                    {
                        foreach (var chapter in book.Chapters)
                        {
                            foreach (var verse in chapter.Verses)
                            {
                                if (verse.Text.ToUpper().Contains(str))
                                {
                                    strBuilder.Append(book.Name + " " + chapter.Number + ":" + verse.Number + Environment.NewLine);
                                    strBuilder.Append(verse.Text + Environment.NewLine + Environment.NewLine);
                                }
                            }
                        }
                    }
                    if (book.Name == endBook)
                    {
                        break;
                    }
                }
            });
            bibleTextBox.Text = strBuilder.ToString();
            if (string.IsNullOrWhiteSpace(bibleTextBox.Text))
            {
                bibleTextBox.Text = "No results.";
            }
            fromComboBox.Enabled = true;
            toComboBox.Enabled = true;
            searchButton.Enabled = true;
            paragrapgCheckBox.Enabled = true;
            verseNumberCheckBox.Enabled = true;
            treeChapterView.Enabled = true;
        }
    }
}
