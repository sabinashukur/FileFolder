namespace FileFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                string[] dirs = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
                foreach (string file in files)
                {
                    listBox1.Items.Add(file);

                }
                foreach (string dir in dirs)
                {
                    listBox1.Items.Add(dir);

                }
            }
            DirectoryInfo folder = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            label1.Text = folderSize(folder).ToString();
            label3.Text = (folderSize(folder) * 0.000001).ToString();

        }
        static long folderSize(DirectoryInfo folder)
        {
            long totalSizeOfDir = 0;

            FileInfo[] allFiles = folder.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                totalSizeOfDir += file.Length;
            }

            DirectoryInfo[] subFolders = folder.GetDirectories();

            foreach (DirectoryInfo dir in subFolders)
            {
                totalSizeOfDir += folderSize(dir);
            }

            return totalSizeOfDir;
        }
    }
}