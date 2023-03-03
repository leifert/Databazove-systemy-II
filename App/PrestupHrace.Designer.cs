
namespace VolejbalovaLigaORM
{
    partial class PrestupHrace
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
            this.labelHrac = new System.Windows.Forms.Label();
            this.labelPrestup = new System.Windows.Forms.Label();
            this.labelKam = new System.Windows.Forms.Label();
            this.labelCena = new System.Windows.Forms.Label();
            this.comboBoxHrac = new System.Windows.Forms.ComboBox();
            this.comboBoxKam = new System.Windows.Forms.ComboBox();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.buttonPrestup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHrac
            // 
            this.labelHrac.AutoSize = true;
            this.labelHrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHrac.Location = new System.Drawing.Point(27, 54);
            this.labelHrac.Name = "labelHrac";
            this.labelHrac.Size = new System.Drawing.Size(55, 24);
            this.labelHrac.TabIndex = 0;
            this.labelHrac.Text = "Hráč:";
            // 
            // labelPrestup
            // 
            this.labelPrestup.AutoSize = true;
            this.labelPrestup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrestup.Location = new System.Drawing.Point(12, 9);
            this.labelPrestup.Name = "labelPrestup";
            this.labelPrestup.Size = new System.Drawing.Size(146, 25);
            this.labelPrestup.TabIndex = 1;
            this.labelPrestup.Text = "Přestup hráče";
            // 
            // labelKam
            // 
            this.labelKam.AutoSize = true;
            this.labelKam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKam.Location = new System.Drawing.Point(27, 92);
            this.labelKam.Name = "labelKam";
            this.labelKam.Size = new System.Drawing.Size(53, 24);
            this.labelKam.TabIndex = 2;
            this.labelKam.Text = "Kam:";
            // 
            // labelCena
            // 
            this.labelCena.AutoSize = true;
            this.labelCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCena.Location = new System.Drawing.Point(27, 130);
            this.labelCena.Name = "labelCena";
            this.labelCena.Size = new System.Drawing.Size(60, 24);
            this.labelCena.TabIndex = 3;
            this.labelCena.Text = "Cena:";
            // 
            // comboBoxHrac
            // 
            this.comboBoxHrac.FormattingEnabled = true;
            this.comboBoxHrac.Location = new System.Drawing.Point(89, 56);
            this.comboBoxHrac.Name = "comboBoxHrac";
            this.comboBoxHrac.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHrac.TabIndex = 4;
            // 
            // comboBoxKam
            // 
            this.comboBoxKam.FormattingEnabled = true;
            this.comboBoxKam.Location = new System.Drawing.Point(89, 94);
            this.comboBoxKam.Name = "comboBoxKam";
            this.comboBoxKam.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKam.TabIndex = 5;
            // 
            // textBoxCena
            // 
            this.textBoxCena.Location = new System.Drawing.Point(89, 135);
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(100, 20);
            this.textBoxCena.TabIndex = 6;
            // 
            // buttonPrestup
            // 
            this.buttonPrestup.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonPrestup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrestup.ForeColor = System.Drawing.Color.White;
            this.buttonPrestup.Location = new System.Drawing.Point(31, 190);
            this.buttonPrestup.Name = "buttonPrestup";
            this.buttonPrestup.Size = new System.Drawing.Size(97, 31);
            this.buttonPrestup.TabIndex = 7;
            this.buttonPrestup.Text = "Přestoupit";
            this.buttonPrestup.UseVisualStyleBackColor = false;
            this.buttonPrestup.Click += new System.EventHandler(this.buttonPrestup_Click);
            // 
            // PrestupHrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 261);
            this.Controls.Add(this.buttonPrestup);
            this.Controls.Add(this.textBoxCena);
            this.Controls.Add(this.comboBoxKam);
            this.Controls.Add(this.comboBoxHrac);
            this.Controls.Add(this.labelCena);
            this.Controls.Add(this.labelKam);
            this.Controls.Add(this.labelPrestup);
            this.Controls.Add(this.labelHrac);
            this.Name = "PrestupHrace";
            this.Text = "PrestupHrace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHrac;
        private System.Windows.Forms.Label labelPrestup;
        private System.Windows.Forms.Label labelKam;
        private System.Windows.Forms.Label labelCena;
        private System.Windows.Forms.ComboBox comboBoxHrac;
        private System.Windows.Forms.ComboBox comboBoxKam;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.Button buttonPrestup;
    }
}