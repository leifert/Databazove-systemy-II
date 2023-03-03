
namespace VolejbalovaLigaORM
{
    partial class PrehledLigy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTabulka = new System.Windows.Forms.Label();
            this.dataGridTabulka = new System.Windows.Forms.DataGridView();
            this.labelZapasy = new System.Windows.Forms.Label();
            this.labelKolo = new System.Windows.Forms.Label();
            this.comboBoxKolo = new System.Windows.Forms.ComboBox();
            this.ColKlub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridZapasy = new System.Windows.Forms.DataGridView();
            this.btnPridatZapas = new System.Windows.Forms.Button();
            this.ColDom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHoste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAkce = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabulka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridZapasy)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTabulka
            // 
            this.labelTabulka.AutoSize = true;
            this.labelTabulka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTabulka.Location = new System.Drawing.Point(12, 9);
            this.labelTabulka.Name = "labelTabulka";
            this.labelTabulka.Size = new System.Drawing.Size(89, 25);
            this.labelTabulka.TabIndex = 0;
            this.labelTabulka.Text = "Tabulka";
            // 
            // dataGridTabulka
            // 
            this.dataGridTabulka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTabulka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColKlub,
            this.ColZ,
            this.ColV,
            this.ColP,
            this.ColVS,
            this.ColPS,
            this.ColB});
            this.dataGridTabulka.Location = new System.Drawing.Point(17, 37);
            this.dataGridTabulka.Name = "dataGridTabulka";
            this.dataGridTabulka.Size = new System.Drawing.Size(545, 192);
            this.dataGridTabulka.TabIndex = 1;
            this.dataGridTabulka.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelZapasy
            // 
            this.labelZapasy.AutoSize = true;
            this.labelZapasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZapasy.Location = new System.Drawing.Point(13, 293);
            this.labelZapasy.Name = "labelZapasy";
            this.labelZapasy.Size = new System.Drawing.Size(83, 25);
            this.labelZapasy.TabIndex = 2;
            this.labelZapasy.Text = "Zápasy";
            // 
            // labelKolo
            // 
            this.labelKolo.AutoSize = true;
            this.labelKolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKolo.Location = new System.Drawing.Point(18, 336);
            this.labelKolo.Name = "labelKolo";
            this.labelKolo.Size = new System.Drawing.Size(44, 20);
            this.labelKolo.TabIndex = 3;
            this.labelKolo.Text = "Kolo:";
            // 
            // comboBoxKolo
            // 
            this.comboBoxKolo.FormattingEnabled = true;
            this.comboBoxKolo.Location = new System.Drawing.Point(68, 338);
            this.comboBoxKolo.Name = "comboBoxKolo";
            this.comboBoxKolo.Size = new System.Drawing.Size(50, 21);
            this.comboBoxKolo.TabIndex = 4;
            this.comboBoxKolo.SelectedIndexChanged += new System.EventHandler(this.comboBoxKolo_SelectedIndexChanged);
            // 
            // ColKlub
            // 
            this.ColKlub.DataPropertyName = "Klub";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColKlub.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColKlub.HeaderText = "Klub";
            this.ColKlub.Name = "ColKlub";
            this.ColKlub.Width = 200;
            // 
            // ColZ
            // 
            this.ColZ.DataPropertyName = "Z";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColZ.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColZ.HeaderText = "Z";
            this.ColZ.Name = "ColZ";
            this.ColZ.Width = 50;
            // 
            // ColV
            // 
            this.ColV.DataPropertyName = "V";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColV.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColV.HeaderText = "V";
            this.ColV.Name = "ColV";
            this.ColV.Width = 50;
            // 
            // ColP
            // 
            this.ColP.DataPropertyName = "P";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColP.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColP.HeaderText = "P";
            this.ColP.Name = "ColP";
            this.ColP.Width = 50;
            // 
            // ColVS
            // 
            this.ColVS.DataPropertyName = "VS";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColVS.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColVS.HeaderText = "VS";
            this.ColVS.Name = "ColVS";
            this.ColVS.Width = 50;
            // 
            // ColPS
            // 
            this.ColPS.DataPropertyName = "PS";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColPS.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColPS.HeaderText = "PS";
            this.ColPS.Name = "ColPS";
            this.ColPS.Width = 50;
            // 
            // ColB
            // 
            this.ColB.DataPropertyName = "B";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColB.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColB.HeaderText = "B";
            this.ColB.Name = "ColB";
            this.ColB.Width = 50;
            // 
            // dataGridZapasy
            // 
            this.dataGridZapasy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridZapasy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDom,
            this.ColVSD,
            this.ColVSH,
            this.ColHoste,
            this.ColAkce});
            this.dataGridZapasy.Location = new System.Drawing.Point(13, 395);
            this.dataGridZapasy.Name = "dataGridZapasy";
            this.dataGridZapasy.Size = new System.Drawing.Size(583, 150);
            this.dataGridZapasy.TabIndex = 5;
            this.dataGridZapasy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridZapasy_CellContentClick);
            // 
            // btnPridatZapas
            // 
            this.btnPridatZapas.BackColor = System.Drawing.SystemColors.Control;
            this.btnPridatZapas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPridatZapas.Location = new System.Drawing.Point(13, 588);
            this.btnPridatZapas.Name = "btnPridatZapas";
            this.btnPridatZapas.Size = new System.Drawing.Size(121, 29);
            this.btnPridatZapas.TabIndex = 6;
            this.btnPridatZapas.Text = "Přidat zápas";
            this.btnPridatZapas.UseVisualStyleBackColor = false;
            this.btnPridatZapas.Click += new System.EventHandler(this.btnPridatZapas_Click);
            // 
            // ColDom
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.ColDom.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColDom.HeaderText = "Domácí";
            this.ColDom.Name = "ColDom";
            this.ColDom.Width = 180;
            // 
            // ColVSD
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColVSD.DefaultCellStyle = dataGridViewCellStyle20;
            this.ColVSD.HeaderText = "VSD";
            this.ColVSD.Name = "ColVSD";
            this.ColVSD.Width = 50;
            // 
            // ColVSH
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColVSH.DefaultCellStyle = dataGridViewCellStyle21;
            this.ColVSH.HeaderText = "VSH";
            this.ColVSH.Name = "ColVSH";
            this.ColVSH.Width = 50;
            // 
            // ColHoste
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColHoste.DefaultCellStyle = dataGridViewCellStyle22;
            this.ColHoste.HeaderText = "Hosté";
            this.ColHoste.Name = "ColHoste";
            this.ColHoste.Width = 180;
            // 
            // ColAkce
            // 
            this.ColAkce.HeaderText = "Akce";
            this.ColAkce.Name = "ColAkce";
            this.ColAkce.Text = "Detail";
            this.ColAkce.UseColumnTextForButtonValue = true;
            this.ColAkce.Width = 80;
            // 
            // PrehledLigy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 650);
            this.Controls.Add(this.btnPridatZapas);
            this.Controls.Add(this.dataGridZapasy);
            this.Controls.Add(this.comboBoxKolo);
            this.Controls.Add(this.labelKolo);
            this.Controls.Add(this.labelZapasy);
            this.Controls.Add(this.dataGridTabulka);
            this.Controls.Add(this.labelTabulka);
            this.Name = "PrehledLigy";
            this.Text = "PrehledLigy";
            this.Load += new System.EventHandler(this.PrehledLigy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabulka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridZapasy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTabulka;
        private System.Windows.Forms.DataGridView dataGridTabulka;
        private System.Windows.Forms.Label labelZapasy;
        private System.Windows.Forms.Label labelKolo;
        private System.Windows.Forms.ComboBox comboBoxKolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKlub;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColB;
        private System.Windows.Forms.DataGridView dataGridZapasy;
        private System.Windows.Forms.Button btnPridatZapas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHoste;
        private System.Windows.Forms.DataGridViewButtonColumn ColAkce;
    }
}