namespace Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LeftList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RightList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuHead = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftCBox = new System.Windows.Forms.ComboBox();
            this.RightCBox = new System.Windows.Forms.ComboBox();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Rename = new System.Windows.Forms.Button();
            this.Copy = new System.Windows.Forms.Button();
            this.Paste = new System.Windows.Forms.Button();
            this.NewFile = new System.Windows.Forms.Button();
            this.SuperPaste = new System.Windows.Forms.Button();
            this.Filter = new System.Windows.Forms.Button();
            this.FilterBox = new System.Windows.Forms.TextBox();
            this.NewXML = new System.Windows.Forms.Button();
            this.menuHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftList
            // 
            this.LeftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LeftList.Location = new System.Drawing.Point(9, 94);
            this.LeftList.Name = "LeftList";
            this.LeftList.Size = new System.Drawing.Size(493, 385);
            this.LeftList.TabIndex = 0;
            this.LeftList.UseCompatibleStateImageBehavior = false;
            this.LeftList.View = System.Windows.Forms.View.Details;
            this.LeftList.SelectedIndexChanged += new System.EventHandler(this.LeftList_SelectedIndexChanged);
            this.LeftList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 116;
            // 
            // RightList
            // 
            this.RightList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.RightList.Location = new System.Drawing.Point(508, 94);
            this.RightList.Name = "RightList";
            this.RightList.Size = new System.Drawing.Size(266, 385);
            this.RightList.TabIndex = 1;
            this.RightList.UseCompatibleStateImageBehavior = false;
            this.RightList.View = System.Windows.Forms.View.Details;
            this.RightList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RightList_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 114;
            // 
            // menuHead
            // 
            this.menuHead.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuHead.Location = new System.Drawing.Point(0, 0);
            this.menuHead.Name = "menuHead";
            this.menuHead.Size = new System.Drawing.Size(784, 24);
            this.menuHead.TabIndex = 2;
            this.menuHead.Text = "menuStrip1";
            this.menuHead.Visible = false;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиToolStripMenuItem,
            this.відкритиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // створитиToolStripMenuItem
            // 
            this.створитиToolStripMenuItem.Name = "створитиToolStripMenuItem";
            this.створитиToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.створитиToolStripMenuItem.Text = "Створити";
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            // 
            // LeftCBox
            // 
            this.LeftCBox.FormattingEnabled = true;
            this.LeftCBox.Items.AddRange(new object[] {
            "C:\\",
            "D:\\"});
            this.LeftCBox.Location = new System.Drawing.Point(9, 69);
            this.LeftCBox.Name = "LeftCBox";
            this.LeftCBox.Size = new System.Drawing.Size(121, 21);
            this.LeftCBox.TabIndex = 4;
            this.LeftCBox.SelectedIndexChanged += new System.EventHandler(this.LeftCBox_SelectedIndexChanged);
            this.LeftCBox.SelectionChangeCommitted += new System.EventHandler(this.LeftCBox_SelectionChangeCommitted);
            // 
            // RightCBox
            // 
            this.RightCBox.FormattingEnabled = true;
            this.RightCBox.Items.AddRange(new object[] {
            "C:\\",
            "D:\\"});
            this.RightCBox.Location = new System.Drawing.Point(508, 67);
            this.RightCBox.Name = "RightCBox";
            this.RightCBox.Size = new System.Drawing.Size(121, 21);
            this.RightCBox.TabIndex = 5;
            this.RightCBox.SelectionChangeCommitted += new System.EventHandler(this.RightCBox_SelectionChangeCommitted);
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftLabel.Location = new System.Drawing.Point(139, 67);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(98, 20);
            this.LeftLabel.TabIndex = 6;
            this.LeftLabel.Text = "Current path";
            // 
            // RightLabel
            // 
            this.RightLabel.AutoSize = true;
            this.RightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightLabel.Location = new System.Drawing.Point(635, 67);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(98, 20);
            this.RightLabel.TabIndex = 7;
            this.RightLabel.Text = "Current path";
            this.RightLabel.Click += new System.EventHandler(this.RightLabel_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.jpg");
            this.imageList.Images.SetKeyName(1, "file.jpg");
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Enabled = false;
            this.CreateFolderButton.Location = new System.Drawing.Point(12, 7);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(105, 25);
            this.CreateFolderButton.TabIndex = 8;
            this.CreateFolderButton.Text = "Створити папку";
            this.CreateFolderButton.UseVisualStyleBackColor = true;
            this.CreateFolderButton.Click += new System.EventHandler(this.NewFolderName_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(354, 7);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(105, 25);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "Видалити";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Rename
            // 
            this.Rename.Location = new System.Drawing.Point(243, 7);
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(105, 25);
            this.Rename.TabIndex = 10;
            this.Rename.Text = "Переіменувати";
            this.Rename.UseVisualStyleBackColor = true;
            this.Rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // Copy
            // 
            this.Copy.Location = new System.Drawing.Point(123, 36);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(114, 25);
            this.Copy.TabIndex = 11;
            this.Copy.Text = "Скопіювати";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Paste
            // 
            this.Paste.Location = new System.Drawing.Point(243, 36);
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(105, 25);
            this.Paste.TabIndex = 12;
            this.Paste.Text = "Вставити";
            this.Paste.UseVisualStyleBackColor = true;
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // NewFile
            // 
            this.NewFile.Enabled = false;
            this.NewFile.Location = new System.Drawing.Point(12, 38);
            this.NewFile.Name = "NewFile";
            this.NewFile.Size = new System.Drawing.Size(105, 25);
            this.NewFile.TabIndex = 13;
            this.NewFile.Text = "Створити txt";
            this.NewFile.UseVisualStyleBackColor = true;
            this.NewFile.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // SuperPaste
            // 
            this.SuperPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SuperPaste.Location = new System.Drawing.Point(354, 36);
            this.SuperPaste.Name = "SuperPaste";
            this.SuperPaste.Size = new System.Drawing.Size(221, 25);
            this.SuperPaste.TabIndex = 14;
            this.SuperPaste.Text = "Вставити без повторів рядків";
            this.SuperPaste.UseVisualStyleBackColor = true;
            this.SuperPaste.Click += new System.EventHandler(this.SuperPaste_Click);
            // 
            // Filter
            // 
            this.Filter.Location = new System.Drawing.Point(465, 7);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(110, 25);
            this.Filter.TabIndex = 15;
            this.Filter.Text = "Фільтрувати за ->";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // FilterBox
            // 
            this.FilterBox.Location = new System.Drawing.Point(581, 10);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(100, 20);
            this.FilterBox.TabIndex = 16;
            // 
            // NewXML
            // 
            this.NewXML.Enabled = false;
            this.NewXML.Location = new System.Drawing.Point(123, 7);
            this.NewXML.Name = "NewXML";
            this.NewXML.Size = new System.Drawing.Size(114, 25);
            this.NewXML.TabIndex = 17;
            this.NewXML.Text = "Створити таблицю";
            this.NewXML.UseVisualStyleBackColor = true;
            this.NewXML.Click += new System.EventHandler(this.NewXML_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 489);
            this.Controls.Add(this.NewXML);
            this.Controls.Add(this.FilterBox);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.SuperPaste);
            this.Controls.Add(this.NewFile);
            this.Controls.Add(this.Paste);
            this.Controls.Add(this.Copy);
            this.Controls.Add(this.Rename);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CreateFolderButton);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.RightCBox);
            this.Controls.Add(this.LeftCBox);
            this.Controls.Add(this.RightList);
            this.Controls.Add(this.LeftList);
            this.Controls.Add(this.menuHead);
            this.MainMenuStrip = this.menuHead;
            this.Name = "MainForm";
            this.Text = "Manager";
            this.menuHead.ResumeLayout(false);
            this.menuHead.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LeftList;
        private System.Windows.Forms.ListView RightList;
        private System.Windows.Forms.MenuStrip menuHead;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ComboBox LeftCBox;
        private System.Windows.Forms.ComboBox RightCBox;
        private System.Windows.Forms.ToolStripMenuItem створитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button Rename;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Button Paste;
        private System.Windows.Forms.Button NewFile;
        private System.Windows.Forms.Button SuperPaste;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.TextBox FilterBox;
        private System.Windows.Forms.Button NewXML;
    }
}

