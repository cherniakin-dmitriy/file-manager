namespace Manager
{
    partial class NewFolderName
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewNameLabel = new System.Windows.Forms.Label();
            this.ReadNewName = new System.Windows.Forms.TextBox();
            this.NewFolderNameOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewNameLabel
            // 
            this.NewNameLabel.AutoSize = true;
            this.NewNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewNameLabel.Location = new System.Drawing.Point(67, 22);
            this.NewNameLabel.Name = "NewNameLabel";
            this.NewNameLabel.Size = new System.Drawing.Size(187, 17);
            this.NewNameLabel.TabIndex = 0;
            this.NewNameLabel.Text = "Введіть назву нової папки: ";
            // 
            // ReadNewName
            // 
            this.ReadNewName.Location = new System.Drawing.Point(70, 42);
            this.ReadNewName.Name = "ReadNewName";
            this.ReadNewName.Size = new System.Drawing.Size(176, 20);
            this.ReadNewName.TabIndex = 1;
            // 
            // NewFolderNameOK
            // 
            this.NewFolderNameOK.Location = new System.Drawing.Point(115, 68);
            this.NewFolderNameOK.Name = "NewFolderNameOK";
            this.NewFolderNameOK.Size = new System.Drawing.Size(75, 23);
            this.NewFolderNameOK.TabIndex = 2;
            this.NewFolderNameOK.Text = "OK";
            this.NewFolderNameOK.UseVisualStyleBackColor = true;
            this.NewFolderNameOK.Click += new System.EventHandler(this.NewNameOK_Click);
            // 
            // NewObjectNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 111);
            this.Controls.Add(this.NewFolderNameOK);
            this.Controls.Add(this.ReadNewName);
            this.Controls.Add(this.NewNameLabel);
            this.Name = "NewObjectNameForm";
            this.Text = "NewName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewNameLabel;
        private System.Windows.Forms.TextBox ReadNewName;
        private System.Windows.Forms.Button NewFolderNameOK;
    }
}