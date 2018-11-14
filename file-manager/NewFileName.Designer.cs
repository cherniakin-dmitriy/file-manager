namespace Manager
{
    partial class NewFileName
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReadNewName = new System.Windows.Forms.TextBox();
            this.NewFileNameOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введіть ім\'я новому файлу:";
            // 
            // ReadNewName
            // 
            this.ReadNewName.Location = new System.Drawing.Point(74, 43);
            this.ReadNewName.Name = "ReadNewName";
            this.ReadNewName.Size = new System.Drawing.Size(176, 20);
            this.ReadNewName.TabIndex = 1;
            // 
            // NewFileNameOK
            // 
            this.NewFileNameOK.Location = new System.Drawing.Point(119, 69);
            this.NewFileNameOK.Name = "NewFileNameOK";
            this.NewFileNameOK.Size = new System.Drawing.Size(75, 23);
            this.NewFileNameOK.TabIndex = 2;
            this.NewFileNameOK.Text = "OK";
            this.NewFileNameOK.UseVisualStyleBackColor = true;
            this.NewFileNameOK.Click += new System.EventHandler(this.NewFileNameOK_Click);
            // 
            // NewFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 111);
            this.Controls.Add(this.NewFileNameOK);
            this.Controls.Add(this.ReadNewName);
            this.Controls.Add(this.label1);
            this.Name = "NewFileName";
            this.Text = "NewFileName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ReadNewName;
        private System.Windows.Forms.Button NewFileNameOK;
    }
}