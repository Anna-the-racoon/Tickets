using BusinesLogic;

namespace WinFormsUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private TxtService FileService { get; set; }
        
        private string FileName { get; set; }

        public Form()
        {
            InitializeComponent();

            FileService = new TxtService();
            openFileDialog1 = new OpenFileDialog();
        }

        private async void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = openFileDialog1.FileName;

            try
            {
                richTextBox1.Text = await FileService.SearchFile(FileName);
                toolStripButtonSave.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
               await FileService.Save(FileName, richTextBox1.Text.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}