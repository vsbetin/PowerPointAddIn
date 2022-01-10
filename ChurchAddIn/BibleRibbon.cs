using System;
using Microsoft.Office.Tools.Ribbon;

namespace ChurchAddIn
{
    public partial class BibleRibbon
    {
        private BibleForm bibleForm = null;

        private void Bible_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void ukrButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.UkranianOgiyenko);
            bibleForm.Show();
        }

        private void rusNewButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.RusianNew);
            bibleForm.Show();
        }

        private void rusSinButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.RusianSynodal);
            bibleForm.Show();
        }

        private void engESVButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.EnglishESV);
            bibleForm.Show();
        }

        private void engKJVButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.EnglishKJV);
            bibleForm.Show();
        }

        private void engASVButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.EnglishASV);
            bibleForm.Show();
        }
        
        private void engNIVButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (bibleForm != null)
                bibleForm.Close();
            bibleForm = new BibleForm(BibleVersion.EnglishNIV);
            bibleForm.Show();
        }

        private void addSlidesButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (Globals.ThisAddIn.Application.ActivePresentation.Slides.Count > 0 &&
                        Globals.ThisAddIn.Application.ActiveWindow.View.Slide != null)
                    {
                        Globals.ThisAddIn.Application.ActivePresentation.Slides.InsertFromFile(
                            openFileDialog1.FileName,
                            Globals.ThisAddIn.Application.ActiveWindow.View.Slide.SlideIndex,
                            1);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
