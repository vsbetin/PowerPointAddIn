using System;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace ChurchAddIn
{
    public partial class ThisAddIn
    {
        private static object _locker = new object();

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Globals.ThisAddIn.Application.SlideShowNextSlide += Application_SlideShowNextSlide;
        }

        private void Application_SlideShowNextSlide(PowerPoint.SlideShowWindow Wn)
        {
            try
            {
                Wn.Activate();
                var text = new StringBuilder();

                foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in Wn.View.Slide.Shapes)
                {
                    if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
                    {
                        var textFrame = shape.TextFrame;
                        if (textFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
                        {
                            text.Append(textFrame.TextRange.Text);
                        }
                    }
                }

                lock (_locker)
                {
                    File.WriteAllText(@"slide-text", text.ToString().Replace("", "").Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                lock (_locker)
                {
                    File.AppendAllText(
                        @"power-point-error.log",
                        $"Error occured: {DateTimeOffset.UtcNow}" + Environment.NewLine + JsonConvert.SerializeObject(ex));
                }
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
           
        }

        

        

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
