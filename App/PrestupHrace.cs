using System;
using System.Collections.Generic;
using VolejbalovaLigaORM.ORM.DAO.mssql;
using VolejbalovaLigaORM.ORM;
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
    public partial class PrestupHrace : Form
    {
        public PrestupHrace()
        {
            InitializeComponent();
            Collection<Hrac> hrac = HracTable.Select();
            Collection<Klub> klub = KlubTable.Select();
            

            comboBoxHrac.DataSource = hrac;
            comboBoxHrac.DisplayMember = "cele_jmeno";
            comboBoxHrac.ValueMember = "id_hrac";
            comboBoxKam.DataSource = klub;
            comboBoxKam.DisplayMember = "nazev";
            comboBoxKam.ValueMember = "id_klub";
            
        }

        private void buttonPrestup_Click(object sender, EventArgs e)
        {
            int hrac = (int)comboBoxHrac.SelectedValue;
            int kam = (int)comboBoxKam.SelectedValue;
            int cena;
            int.TryParse(textBoxCena.Text, out cena);
            if (textBoxCena.Text.Length < 1)
            {
                MessageBox.Show("Vložte cenu přestupu!");
            }
            else {
                Historie_prestupuTable.Prestup(hrac,kam,cena);
                MessageBox.Show("Přestup hráče byl úspěšný!");
            }
        }
    }
}
