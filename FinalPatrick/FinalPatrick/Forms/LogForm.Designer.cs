namespace FinalPatrick.Forms
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.pbxBack = new System.Windows.Forms.PictureBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.pbxSearch = new System.Windows.Forms.PictureBox();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBack
            // 
            this.pbxBack.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxBack.BackgroundImage")));
            this.pbxBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBack.Location = new System.Drawing.Point(8, 270);
            this.pbxBack.Name = "pbxBack";
            this.pbxBack.Size = new System.Drawing.Size(45, 40);
            this.pbxBack.TabIndex = 31;
            this.pbxBack.TabStop = false;
            this.pbxBack.Click += new System.EventHandler(this.pbxBack_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeColumns = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLog.Location = new System.Drawing.Point(8, 57);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(560, 207);
            this.dgvLog.TabIndex = 27;
            // 
            // pbxSearch
            // 
            this.pbxSearch.BackgroundImage = global::FinalPatrick.Properties.Resources.search;
            this.pbxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSearch.Location = new System.Drawing.Point(263, 20);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Size = new System.Drawing.Size(40, 25);
            this.pbxSearch.TabIndex = 26;
            this.pbxSearch.TabStop = false;
            this.pbxSearch.Click += new System.EventHandler(this.pbxSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.Location = new System.Drawing.Point(98, 25);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(146, 23);
            this.tbxSearch.TabIndex = 25;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(18, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 18);
            this.lblSearch.TabIndex = 24;
            this.lblSearch.Text = "Pesquisar";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(322, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 31);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbxBack);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.pbxSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "LogForm";
            this.Text = "Log";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBack;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.PictureBox pbxSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button button1;
    }
}