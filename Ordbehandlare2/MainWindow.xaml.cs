using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ordbehandlare2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }


        protected void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Exit the Application";

        }

        protected void ToolSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                //  Build Spelling suggestions
                foreach (string s in error.Suggestions)
                {
                    spellingHints += $"{s}\n";
                }

                //show suggestions
                lblSpellingHints.Content = spellingHints;
                expanderSpelling.IsExpanded = true;
            }
        }

        protected void SpellingHints_MouseEnter(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Show Spelling Suggestions";
        }

        protected void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            statBarText.Text = "Ready";
        }

        protected void FileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }

        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Look, it is not that difficult. Just type something!", "Help");
        }


        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //Create an open File 
            var openDlg = new OpenFileDialog { Filter = "Text Files |*.txt" };

            //Check they did click ok Button 
            if (true == openDlg.ShowDialog())
            {
                //load all the text in the loaded file
                string dataFromFile = File.ReadAllText(openDlg.FileName);
                //show it on the Textbox
                txtData.Text = dataFromFile;
            }
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog { Filter = "Text Files |*.txt" };
            //check that they clicked the OK button 
            if (true == saveDlg.ShowDialog())
            {
                //save data in the textbox in another file
                File.WriteAllText(saveDlg.FileName, txtData.Text);
            }
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
