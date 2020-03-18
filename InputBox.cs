using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPathMan
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public bool AllowEmpty
        {
            get;
            set;
        } = true;

        public string Value
        {
            get;
            set;
        } = "";

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Value = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
            => button1.Enabled = AllowEmpty || textBox1.TextLength > 0;

        private void InputBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1_TextChanged(this, e);

        }
    }
}
