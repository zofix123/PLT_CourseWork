using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Translator.ViewModel;

namespace Translator
{
    public partial class MainForm : Form
    {
        public event Action<string>? CodeExecuted;


        public MainForm()
        {
            InitializeComponent();
        }

        public void SetOutput(string output)
        {
            OutputBox.Text = output;

        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            CodeExecuted?.Invoke(textBox1.Text);
        }
    }
}
