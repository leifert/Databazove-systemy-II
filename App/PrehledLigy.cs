using VolejbalovaLigaORM.ORM.DAO.mssql;
using VolejbalovaLigaORM.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolejbalovaLigaORM
{
    public partial class PrehledLigy : Form
    {
        public PrehledLigy()
        {
            InitializeComponent();
            InitKola();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitKola() {
            Collection<Zapas> zap = ZapasTable.Seznam_kol();
            comboBoxKolo.DataSource = zap;
            comboBoxKolo.DisplayMember = "kolo";
            comboBoxKolo.ValueMember = "kolo";
            comboBoxKolo.SelectedIndex = -1;
        }

        private void PrehledLigy_Load(object sender, EventArgs e)
        {
            Collection<Tabulka> tymy = TabulkaTable.Vysledna_tabulka();
            dataGridTabulka.Rows.Clear();
            foreach (Tabulka tab in tymy) {
                DataGridViewRow row = (DataGridViewRow)dataGridTabulka.Rows[0].Clone(); ;
                row.Cells[0].Value = tab.nazev;
                row.Cells[1].Value = tab.zapasy_celkem;
                row.Cells[2].Value = tab.vyhry;
                row.Cells[3].Value = tab.prohry;
                row.Cells[4].Value = tab.vyhrane_sety;
                row.Cells[5].Value = tab.prohrane_sety;
                row.Cells[6].Value = tab.body;
                dataGridTabulka.Rows.Add(row);
            }
         
           

        }

        private void comboBoxKolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKolo.SelectedItem != null)
            {
               int kolo = int.Parse(((Zapas)comboBoxKolo.SelectedItem).kolo.ToString());
                zapasyKola(kolo);
            }

        }

        private void zapasyKola(int kolo) {
            Collection<Zapas> zap = ZapasTable.Zapasy_kola(kolo);
            dataGridZapasy.Rows.Clear();
            foreach (Zapas z in zap)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridZapasy.Rows[0].Clone(); ;
                row.Cells[0].Value = z.domaci;
                row.Cells[1].Value = z.domaci_sety;
                row.Cells[2].Value = z.hoste_sety;
                row.Cells[3].Value = z.hoste;
                dataGridZapasy.Rows.Add(row);
            }
            dataGridZapasy.Refresh();
        }

        private void dataGridZapasy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPridatZapas_Click(object sender, EventArgs e)
        {
            Form pridatZapas = new PridatZapas();
            pridatZapas.Show();
        }
    }
}
