
namespace VolejbalovaLigaORM
{
    partial class menu
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
            this.btn_liga = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_liga
            // 
            this.btn_liga.Location = new System.Drawing.Point(95, 106);
            this.btn_liga.Name = "btn_liga";
            this.btn_liga.Size = new System.Drawing.Size(132, 23);
            this.btn_liga.TabIndex = 0;
            this.btn_liga.Text = "Přehled ligy";
            this.btn_liga.UseVisualStyleBackColor = true;
            this.btn_liga.Click += new System.EventHandler(this.btn_liga_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Přestup hráče";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_liga);
            this.Name = "menu";
            this.Text = "menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_liga;
        private System.Windows.Forms.Button button1;
    }
}