using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppPathMan
{
    public partial class MainForm : Form
    {
        AppPathModel _Model;
        public MainForm()
        {

            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

        }

        private void Model_AppPathKeyNotFoundEvent(object sender, AppPathKeyNotFoundEventArgs e)
        {
            if (MessageBox.Show(this, "`App Paths` key not found. Create Key?\n" + e.KeyName, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.DoCreateKey = true;
            }
            else
                this.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = $"{_Model.RootKeyName}_AppPaths-{DateTime.Now:yyyy'-'MM'-'dd}.reg";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var msg = _Model.Export(saveFileDialog1.FileName);
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(this, msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
            => Close();

        private void button1_Click(object sender, EventArgs e)
        {
            using var inputBox = new InputBox()
            {
                Text = "Please enter a new alias name.",
                AllowEmpty = false,
            };
            if (inputBox.ShowDialog(this) != DialogResult.OK || string.IsNullOrEmpty(inputBox.Value))
            {
                return;
            }
            var item = AppPathInfo.Create(_Model.IsSystem, inputBox.Value);
            _Model.List.Add(item);
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (e.ColumnIndex == PathColumn.Index || e.ColumnIndex == ValueColumn.Index)
            {
                if (e.Value is string value)
                {
                    e.Value = string.IsNullOrEmpty(value) ? new RegSz() : new RegSz(value, value.Contains("%"));
                    e.ParsingApplied = true;
                }
                else
                {
                    dataGridView.CancelEdit();
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (e.ColumnIndex == ValueButtonColumn.Index)
            {
                string expandedString = _Model.List[e.RowIndex].Value.ExpandedString;
                openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(expandedString);
                openFileDialog1.FileName = expandedString;
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _Model.List[e.RowIndex].Value = openFileDialog1.FileName;
                }
            }
        }


        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedCells[0].RowIndex;
            if (MessageBox.Show(this, $"Are you want to permanently delete this entry?\n\n{_Model.List[index].Name}", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Model.Delete(index);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _Model = new AppPathModel(Model_AppPathKeyNotFoundEvent);
            appPathModelBindingSource.DataSource = _Model;

        }
    }
}
