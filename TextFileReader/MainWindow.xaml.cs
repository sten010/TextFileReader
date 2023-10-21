using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace TextFileReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SetText(string filefolder, string fileName)
        {
            ListView.Items.Add(filefolder);
            OpenDialog(filefolder, fileName);
        }
        private void OpenDialog(string filefolder, string fileName)
        {
            TextReader textReader = new TextReader(filefolder, fileName);
            textReader.ShowDialog();
        }

        private string GetFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            CommonFileDialogStandardFilters.TextFiles.ShowExtensions = true;
            CommonFileDialogFilter txtFilter = new CommonFileDialogFilter("Text files", ".txt");
            txtFilter.ShowExtensions = true;
            dialog.Filters.Add(txtFilter);
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = false;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var file = GetFile();
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("Ошибка");
                return;
            }
            var onlyFileName = System.IO.Path.GetFileName(file);
            SetText(file, onlyFileName);
        }
        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.ListBox listView = (System.Windows.Controls.ListBox)sender;
            var onlyFileName = System.IO.Path.GetFileName(listView.SelectedItem.ToString());
            OpenDialog(listView.SelectedItem.ToString(), onlyFileName);
        }
    }

}
