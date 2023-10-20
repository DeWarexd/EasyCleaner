using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EasyCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        void clearFolder(DirectoryInfo dirInfo)
        {
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    listBox1.Items.Add(dir.Name + " deleted.");
                }
                catch
                {
                    listBox1.Items.Add(dir.Name + " failed to delete.");
                }
            }
        }

        void clearFiles(DirectoryInfo dirInfo)
        {
            long finalSize = 0;
            foreach (FileInfo f in dirInfo.GetFiles())
            {
                try
                {
                    long fileMB = f.Length / 1024 / 1024;
                    f.Delete();
                    listBox1.Items.Add(f.Name + "  deleted. | " + (fileMB).ToString()  + "mb");
                    finalSize += fileMB;
                }
                catch
                {
                    listBox1.Items.Add(f.Name + " failed to delete.");
                }
            }

            MessageBox.Show("Total of " + (finalSize).ToString() + "mb data cleaned.", "EasyCleaner");
        }

        string username = System.Windows.Forms.SystemInformation.UserName;

        void clearTemp(bool folder, bool files)
        {
            string temppath = @"C:\Users\" + username + @"\AppData\Local\Temp";

            DirectoryInfo dirInfo = new DirectoryInfo(temppath);
            if (folder)
            {
                clearFolder(dirInfo);
            }
            if (files)
            {
                clearFiles(dirInfo);
            }
        }

        void clearTemp2(bool folder, bool files)
        {
            string temppath = @"C:\Windows\Temp";

            DirectoryInfo dirInfo = new DirectoryInfo(temppath);
            if (folder)
            {
                clearFolder(dirInfo);
            }
            if (files)
            {
                clearFiles(dirInfo);
            }
        }

        void clearPrefetch(bool folder, bool files)
        {
            string temppath = @"C:\Windows\Prefetch";

            DirectoryInfo dirInfo = new DirectoryInfo(temppath);
            if (folder)
            {
                clearFolder(dirInfo);
            }
            if (files)
            {
                clearFiles(dirInfo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearTemp(checkBox1.Checked, checkBox2.Checked);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearPrefetch(checkBox4.Checked, checkBox3.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearTemp2(checkBox6.Checked, checkBox5.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearTemp(true, true);
            clearTemp2(true, true);
            clearPrefetch(true, true);
        }

        private void tempCleanerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearTemp2(true, true);
        }

        private void tempCleanerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            clearTemp(true, true);

        }

        private void tempCleanerToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            clearTemp2(true, true);

        }

        private void prefetchCleanerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearPrefetch(true, true);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/DeWarexd");
        }
    }
}