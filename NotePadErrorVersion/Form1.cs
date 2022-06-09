using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotePadErrorVersion
{
    public partial class NotePadName : Form
    {
        string path = "NotePad *";
        public NotePadName()
        {
            InitializeComponent();
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Information.Text))
            {
                exitPrompt();
                if (DialogResult == DialogResult.Yes)
                {
                    saveFile_Click(sender, e);
                    Information.Text = String.Empty;
                    path = "NotePad *";
                }
                else if (DialogResult == DialogResult.No)
                {
                    Information.Text = String.Empty;
                    path = "NotePad *";
                }
                this.Text = "NotePad *";
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Information.Text))
            {
                newFile_Click(sender, e);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Information.Text = File.ReadAllText(path = openFileDialog1.FileName);
                string[] fullPath = path.Split("\\");
                path = fullPath[fullPath.Length - 1];
                this.Text = path;
             }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Information.Text))
            {

                File.WriteAllText(openFileDialog1.FileName,Information.Text);
            }
            if (path.CompareTo("NotePad *") == 0)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, Information.Text);
                }
            }
            
        }
        private void exitFile_Click(object sender, EventArgs e)
        {
            exitPrompt();
        }

        private void exitPrompt()
        {
            DialogResult = MessageBox.Show("Do you want to save file?",
                "NotePad Error Version",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }
    }
}
