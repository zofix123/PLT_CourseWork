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
        private readonly TranslatorViewModel _viewModel;
        public MainForm()
        {
            InitializeComponent();
            _viewModel = new TranslatorViewModel();

            RunBtn.Click += RunBtn_Click;
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            _viewModel.InputText = textBox1.Text;
            _viewModel.ExecuteParsing();
            OutputBox.Text = _viewModel.OutputText;
        }
    }
}
