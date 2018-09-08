namespace FinalPatrick.Forms
{
    partial class UserAllForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAllForm));
            this.pbxBack = new System.Windows.Forms.PictureBox();
            this.pbxDelete = new System.Windows.Forms.PictureBox();
            this.pbxEdit = new System.Windows.Forms.PictureBox();
            this.pbxAdd = new System.Windows.Forms.PictureBox();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.pbxSearch = new System.Windows.Forms.PictureBox();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
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
            this.pbxBack.TabIndex = 15;
            this.pbxBack.TabStop = false;
            this.pbxBack.Click += new System.EventHandler(this.pbxBack_Click);
            // 
            // pbxDelete
            // 
            this.pbxDelete.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxDelete.BackgroundImage = global::FinalPatrick.Properties.Resources.delete;
            this.pbxDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDelete.Location = new System.Drawing.Point(531, 270);
            this.pbxDelete.Name = "pbxDelete";
            this.pbxDelete.Size = new System.Drawing.Size(45, 40);
            this.pbxDelete.TabIndex = 14;
            this.pbxDelete.TabStop = false;
            this.pbxDelete.Click += new System.EventHandler(this.pbxDelete_Click);
            // 
            // pbxEdit
            // 
            this.pbxEdit.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxEdit.BackgroundImage = global::FinalPatrick.Properties.Resources.edit;
            this.pbxEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEdit.Location = new System.Drawing.Point(480, 270);
            this.pbxEdit.Name = "pbxEdit";
            this.pbxEdit.Size = new System.Drawing.Size(45, 40);
            this.pbxEdit.TabIndex = 13;
            this.pbxEdit.TabStop = false;
            this.pbxEdit.Click += new System.EventHandler(this.pbxEdit_Click);
            // 
            // pbxAdd
            // 
            this.pbxAdd.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxAdd.BackgroundImage = global::FinalPatrick.Properties.Resources.Add;
            this.pbxAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxAdd.Location = new System.Drawing.Point(425, 270);
            this.pbxAdd.Name = "pbxAdd";
            this.pbxAdd.Size = new System.Drawing.Size(45, 40);
            this.pbxAdd.TabIndex = 12;
            this.pbxAdd.TabStop = false;
            this.pbxAdd.Click += new System.EventHandler(this.pbxAdd_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AllowUserToResizeRows = false;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUser.Location = new System.Drawing.Point(8, 57);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(560, 207);
            this.dgvUser.TabIndex = 11;
            // 
            // pbxSearch
            // 
            this.pbxSearch.BackgroundImage = global::FinalPatrick.Properties.Resources.search;
            this.pbxSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSearch.Location = new System.Drawing.Point(263, 20);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Size = new System.Drawing.Size(40, 25);
            this.pbxSearch.TabIndex = 10;
            this.pbxSearch.TabStop = false;
            this.pbxSearch.Click += new System.EventHandler(this.pbxSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.Location = new System.Drawing.Point(98, 25);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(146, 23);
            this.tbxSearch.TabIndex = 9;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(18, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 18);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Pesquisar";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(328, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 31);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserAllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbxBack);
            this.Controls.Add(this.pbxDelete);
            this.Controls.Add(this.pbxEdit);
            this.Controls.Add(this.pbxAdd);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.pbxSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "UserAllForm";
            this.Text = "Usuário";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxBack;
        private System.Windows.Forms.PictureBox pbxDelete;
        private System.Windows.Forms.PictureBox pbxEdit;
        private System.Windows.Forms.PictureBox pbxAdd;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.PictureBox pbxSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button button1;
    }
}