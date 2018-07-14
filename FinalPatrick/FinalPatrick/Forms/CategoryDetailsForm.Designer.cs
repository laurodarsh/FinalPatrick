﻿namespace FinalPatrick.Forms
{
    partial class CategoryDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryDetailsForm));
            this.lblName = new System.Windows.Forms.Label();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.cbxAcitve = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.pbxBack = new System.Windows.Forms.PictureBox();
            this.pbxDelete = new System.Windows.Forms.PictureBox();
            this.pbxSave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSave)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(9, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nome";
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.Location = new System.Drawing.Point(77, 85);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(15, 14);
            this.cbxActive.TabIndex = 1;
            this.cbxActive.UseVisualStyleBackColor = true;
            // 
            // cbxAcitve
            // 
            this.cbxAcitve.AutoSize = true;
            this.cbxAcitve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAcitve.Location = new System.Drawing.Point(9, 77);
            this.cbxAcitve.Name = "cbxAcitve";
            this.cbxAcitve.Size = new System.Drawing.Size(51, 24);
            this.cbxAcitve.TabIndex = 2;
            this.cbxAcitve.Text = "Ativo";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(77, 51);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(100, 20);
            this.tbxName.TabIndex = 3;
            // 
            // pbxBack
            // 
            this.pbxBack.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxBack.BackgroundImage")));
            this.pbxBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBack.Location = new System.Drawing.Point(12, 279);
            this.pbxBack.Name = "pbxBack";
            this.pbxBack.Size = new System.Drawing.Size(45, 40);
            this.pbxBack.TabIndex = 16;
            this.pbxBack.TabStop = false;
            // 
            // pbxDelete
            // 
            this.pbxDelete.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxDelete.BackgroundImage = global::FinalPatrick.Properties.Resources.delete;
            this.pbxDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDelete.Location = new System.Drawing.Point(534, 279);
            this.pbxDelete.Name = "pbxDelete";
            this.pbxDelete.Size = new System.Drawing.Size(45, 40);
            this.pbxDelete.TabIndex = 22;
            this.pbxDelete.TabStop = false;
            // 
            // pbxSave
            // 
            this.pbxSave.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pbxSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxSave.BackgroundImage")));
            this.pbxSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSave.Location = new System.Drawing.Point(473, 279);
            this.pbxSave.Name = "pbxSave";
            this.pbxSave.Size = new System.Drawing.Size(45, 40);
            this.pbxSave.TabIndex = 21;
            this.pbxSave.TabStop = false;
            // 
            // CategoryDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.pbxDelete);
            this.Controls.Add(this.pbxSave);
            this.Controls.Add(this.pbxBack);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.cbxAcitve);
            this.Controls.Add(this.cbxActive);
            this.Controls.Add(this.lblName);
            this.Name = "CategoryDetailsForm";
            this.Text = "Formulário de Categoria";
            ((System.ComponentModel.ISupportInitialize)(this.pbxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox cbxActive;
        private System.Windows.Forms.Label cbxAcitve;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.PictureBox pbxBack;
        private System.Windows.Forms.PictureBox pbxDelete;
        private System.Windows.Forms.PictureBox pbxSave;
    }
}