namespace AppPathMan
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dropTargetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useUrlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appPathModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.checkBoxSystem = new System.Windows.Forms.CheckBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn9 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn10 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn12 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appPathModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn,
            this.ValueButtonColumn,
            this.PathColumn,
            this.PathButtonColumn,
            this.dropTargetDataGridViewTextBoxColumn,
            this.useUrlDataGridViewTextBoxColumn,
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn});
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.appPathModelBindingSource, "IsEditable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.appPathModelBindingSource, "ReadOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.DataSource = this.listBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(898, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NameColumn.DataPropertyName = "Name";
            this.NameColumn.Frozen = true;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MinimumWidth = 8;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 96;
            // 
            // ValueColumn
            // 
            this.ValueColumn.DataPropertyName = "Value";
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.MinimumWidth = 8;
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 300;
            // 
            // ValueButtonColumn
            // 
            this.ValueButtonColumn.DataPropertyName = "Value";
            this.ValueButtonColumn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ValueButtonColumn.HeaderText = "...";
            this.ValueButtonColumn.MinimumWidth = 8;
            this.ValueButtonColumn.Name = "ValueButtonColumn";
            this.ValueButtonColumn.UseColumnTextForButtonValue = true;
            this.ValueButtonColumn.Width = 20;
            // 
            // PathColumn
            // 
            this.PathColumn.DataPropertyName = "Path";
            this.PathColumn.HeaderText = "Path";
            this.PathColumn.MinimumWidth = 8;
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.Width = 300;
            // 
            // PathButtonColumn
            // 
            this.PathButtonColumn.DataPropertyName = "Path";
            this.PathButtonColumn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PathButtonColumn.HeaderText = "...";
            this.PathButtonColumn.MinimumWidth = 8;
            this.PathButtonColumn.Name = "PathButtonColumn";
            this.PathButtonColumn.Text = "";
            this.PathButtonColumn.UseColumnTextForButtonValue = true;
            this.PathButtonColumn.Visible = false;
            this.PathButtonColumn.Width = 20;
            // 
            // dropTargetDataGridViewTextBoxColumn
            // 
            this.dropTargetDataGridViewTextBoxColumn.DataPropertyName = "DropTarget";
            this.dropTargetDataGridViewTextBoxColumn.HeaderText = "DropTarget";
            this.dropTargetDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dropTargetDataGridViewTextBoxColumn.Name = "dropTargetDataGridViewTextBoxColumn";
            this.dropTargetDataGridViewTextBoxColumn.Width = 150;
            // 
            // useUrlDataGridViewTextBoxColumn
            // 
            this.useUrlDataGridViewTextBoxColumn.DataPropertyName = "UseUrl";
            this.useUrlDataGridViewTextBoxColumn.HeaderText = "UseUrl";
            this.useUrlDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.useUrlDataGridViewTextBoxColumn.Name = "useUrlDataGridViewTextBoxColumn";
            this.useUrlDataGridViewTextBoxColumn.Width = 150;
            // 
            // dontUseDesktopChangeRouterDataGridViewTextBoxColumn
            // 
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn.DataPropertyName = "DontUseDesktopChangeRouter";
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn.HeaderText = "DontUseDesktopChangeRouter";
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn.Name = "dontUseDesktopChangeRouterDataGridViewTextBoxColumn";
            this.dontUseDesktopChangeRouterDataGridViewTextBoxColumn.Width = 150;
            // 
            // appPathModelBindingSource
            // 
            this.appPathModelBindingSource.DataSource = typeof(AppPathMan.AppPathModel);
            // 
            // listBindingSource
            // 
            this.listBindingSource.DataMember = "List";
            this.listBindingSource.DataSource = this.appPathModelBindingSource;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.appPathModelBindingSource, "IsEditable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAdd.Location = new System.Drawing.Point(916, 73);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(143, 37);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.appPathModelBindingSource, "IsEditable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRemove.Location = new System.Drawing.Point(916, 116);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(143, 37);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // checkBoxSystem
            // 
            this.checkBoxSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSystem.AutoSize = true;
            this.checkBoxSystem.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.appPathModelBindingSource, "IsSystem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSystem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxSystem.Location = new System.Drawing.Point(947, 21);
            this.checkBoxSystem.Name = "checkBoxSystem";
            this.checkBoxSystem.Size = new System.Drawing.Size(112, 28);
            this.checkBoxSystem.TabIndex = 3;
            this.checkBoxSystem.Text = "System";
            this.checkBoxSystem.UseVisualStyleBackColor = true;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonQuit.Location = new System.Drawing.Point(916, 314);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(143, 37);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonExport.Location = new System.Drawing.Point(916, 197);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(143, 37);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "reg";
            this.saveFileDialog1.Filter = "reg file|*.reg";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "Executable File|*.exe";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "Value";
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn1.HeaderText = "...";
            this.dataGridViewButtonColumn1.MinimumWidth = 8;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn2.HeaderText = "Path";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.DataPropertyName = "Path";
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn2.HeaderText = "...";
            this.dataGridViewButtonColumn2.MinimumWidth = 8;
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 20;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.DataPropertyName = "Value";
            this.dataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn3.HeaderText = "...";
            this.dataGridViewButtonColumn3.MinimumWidth = 8;
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 20;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn4.HeaderText = "Path";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewButtonColumn4
            // 
            this.dataGridViewButtonColumn4.DataPropertyName = "Path";
            this.dataGridViewButtonColumn4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn4.HeaderText = "...";
            this.dataGridViewButtonColumn4.MinimumWidth = 8;
            this.dataGridViewButtonColumn4.Name = "dataGridViewButtonColumn4";
            this.dataGridViewButtonColumn4.Text = "";
            this.dataGridViewButtonColumn4.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn4.Width = 20;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn5.HeaderText = "Value";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // dataGridViewButtonColumn5
            // 
            this.dataGridViewButtonColumn5.DataPropertyName = "Value";
            this.dataGridViewButtonColumn5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn5.HeaderText = "...";
            this.dataGridViewButtonColumn5.MinimumWidth = 8;
            this.dataGridViewButtonColumn5.Name = "dataGridViewButtonColumn5";
            this.dataGridViewButtonColumn5.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn5.Width = 20;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn6.HeaderText = "Path";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 300;
            // 
            // dataGridViewButtonColumn6
            // 
            this.dataGridViewButtonColumn6.DataPropertyName = "Path";
            this.dataGridViewButtonColumn6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn6.HeaderText = "...";
            this.dataGridViewButtonColumn6.MinimumWidth = 8;
            this.dataGridViewButtonColumn6.Name = "dataGridViewButtonColumn6";
            this.dataGridViewButtonColumn6.Text = "";
            this.dataGridViewButtonColumn6.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn6.Width = 20;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn7.HeaderText = "Value";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 300;
            // 
            // dataGridViewButtonColumn7
            // 
            this.dataGridViewButtonColumn7.DataPropertyName = "Value";
            this.dataGridViewButtonColumn7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn7.HeaderText = "...";
            this.dataGridViewButtonColumn7.MinimumWidth = 8;
            this.dataGridViewButtonColumn7.Name = "dataGridViewButtonColumn7";
            this.dataGridViewButtonColumn7.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn7.Width = 20;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn8.HeaderText = "Path";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 300;
            // 
            // dataGridViewButtonColumn8
            // 
            this.dataGridViewButtonColumn8.DataPropertyName = "Path";
            this.dataGridViewButtonColumn8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn8.HeaderText = "...";
            this.dataGridViewButtonColumn8.MinimumWidth = 8;
            this.dataGridViewButtonColumn8.Name = "dataGridViewButtonColumn8";
            this.dataGridViewButtonColumn8.Text = "";
            this.dataGridViewButtonColumn8.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn8.Visible = false;
            this.dataGridViewButtonColumn8.Width = 20;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn9.HeaderText = "Value";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 300;
            // 
            // dataGridViewButtonColumn9
            // 
            this.dataGridViewButtonColumn9.DataPropertyName = "Value";
            this.dataGridViewButtonColumn9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn9.HeaderText = "...";
            this.dataGridViewButtonColumn9.MinimumWidth = 8;
            this.dataGridViewButtonColumn9.Name = "dataGridViewButtonColumn9";
            this.dataGridViewButtonColumn9.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn9.Width = 20;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn10.HeaderText = "Path";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 300;
            // 
            // dataGridViewButtonColumn10
            // 
            this.dataGridViewButtonColumn10.DataPropertyName = "Path";
            this.dataGridViewButtonColumn10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn10.HeaderText = "...";
            this.dataGridViewButtonColumn10.MinimumWidth = 8;
            this.dataGridViewButtonColumn10.Name = "dataGridViewButtonColumn10";
            this.dataGridViewButtonColumn10.Text = "";
            this.dataGridViewButtonColumn10.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn10.Visible = false;
            this.dataGridViewButtonColumn10.Width = 20;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn11.HeaderText = "Value";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 300;
            // 
            // dataGridViewButtonColumn11
            // 
            this.dataGridViewButtonColumn11.DataPropertyName = "Value";
            this.dataGridViewButtonColumn11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn11.HeaderText = "...";
            this.dataGridViewButtonColumn11.MinimumWidth = 8;
            this.dataGridViewButtonColumn11.Name = "dataGridViewButtonColumn11";
            this.dataGridViewButtonColumn11.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn11.Width = 20;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn12.HeaderText = "Path";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 300;
            // 
            // dataGridViewButtonColumn12
            // 
            this.dataGridViewButtonColumn12.DataPropertyName = "Path";
            this.dataGridViewButtonColumn12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dataGridViewButtonColumn12.HeaderText = "...";
            this.dataGridViewButtonColumn12.MinimumWidth = 8;
            this.dataGridViewButtonColumn12.Name = "dataGridViewButtonColumn12";
            this.dataGridViewButtonColumn12.Text = "";
            this.dataGridViewButtonColumn12.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn12.Visible = false;
            this.dataGridViewButtonColumn12.Width = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1071, 444);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.checkBoxSystem);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "AppPathMan";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appPathModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.CheckBox checkBoxSystem;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.BindingSource appPathModelBindingSource;
        private System.Windows.Forms.BindingSource listBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ValueButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
        private System.Windows.Forms.DataGridViewButtonColumn PathButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dropTargetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn useUrlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dontUseDesktopChangeRouterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn12;
    }
}

