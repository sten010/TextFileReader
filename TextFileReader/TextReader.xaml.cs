using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace TextFileReader
{
    /// <summary>
    /// Логика взаимодействия для TextReader.xaml
    /// </summary>
    public partial class TextReader : Window
    {
        public string Folder { get; set; }
        public TextReader(string folder,string fileName)
        {
            InitializeComponent();
            Folder = folder;
            this.Title = fileName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReaderText.Document.Blocks.Clear();
            using (var sr = new StreamReader(Folder))
            {
                ReaderText.Document.Blocks.Add(new Paragraph(new Run(sr.ReadToEnd())));
            }

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveText_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(
            // TextPointer to the start of content in the RichTextBox.
             ReaderText.Document.ContentStart,
            // TextPointer to the end of content in the RichTextBox.
            ReaderText.Document.ContentEnd
            );
            File.WriteAllText(Folder, textRange.Text.Replace("/n","").Trim());
            Close();
        }
    }
}
