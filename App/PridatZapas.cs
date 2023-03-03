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
using VolejbalovaLigaORM.ORM.DAO.mssql;
using VolejbalovaLigaORM.ORM;

namespace VolejbalovaLigaORM
{
    public partial class PridatZapas : Form
    {
        public PridatZapas()
        {
            InitializeComponent();
            Collection<Klub> domaci = KlubTable.Select();
            Collection<Klub> hoste = KlubTable.Select();
            Collection<Rozhodci> rozhodci = RozhodciTable.Select();
           
            comboBoxDomaci.DataSource = domaci;
            comboBoxDomaci.DisplayMember = "nazev";
            comboBoxDomaci.ValueMember = "id_klub";
            comboBoxHoste.DataSource = hoste;
            comboBoxHoste.DisplayMember = "nazev";
            comboBoxHoste.ValueMember = "id_klub";
            comboBoxRozhodci.DataSource = rozhodci;
            comboBoxRozhodci.DisplayMember = "cele_jmeno";
            comboBoxRozhodci.ValueMember = "id_rozhodci";
        }

        private void buttonVlozit_Click(object sender, EventArgs e)
        {
            int domaci = (int)comboBoxDomaci.SelectedValue;
            int hoste = (int)comboBoxHoste.SelectedValue;
            int rozhodci = (int)comboBoxRozhodci.SelectedValue;
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text.ToString());
            int kolo;
            int domSety;
            int hosteSety;
            int divaci;
            int.TryParse(textBoxKolo.Text, out kolo);
            int.TryParse(textBoxSetyDom.Text, out domSety);
            int.TryParse(textBoxSetyHoste.Text, out hosteSety);
            int.TryParse(textBoxDivaci.Text, out divaci);

            
            
           
            

            if (textBoxKolo.Text.Length < 1)
            {
                MessageBox.Show("Vložte hrací kolo!");
            }
            else if (kolo < 1 || kolo > 25)
            {
                MessageBox.Show("Neplatny vstup hracího kola!");
            }
            else if (textBoxSetyDom.Text.Length < 1)
            {
                MessageBox.Show("Vložte sety domácím!");
            }
            else if (domSety != 0)
            {
                MessageBox.Show("Neplatny vstup damácí sety!");
            }
            else if (textBoxSetyHoste.Text.Length < 1)
            {
                MessageBox.Show("Vložte sety hostům!");
            }
            else if (hosteSety != 0)
            {
                MessageBox.Show("Neplatny vstup hosté sety!");
            }
            else if (textBoxDivaci.Text.Length < 1)
            {
                MessageBox.Show("Vložte počet divíků!");
            }
            else if (divaci != 0)
            {
                MessageBox.Show("Neplatny vstup počtu diváků!");
            }
            else {
                Zapas z = new Zapas();
                z.id_domaci = domaci;
                z.id_hoste = hoste;
                z.kolo = kolo;
                z.domaci_sety = domSety;
                z.hoste_sety = hosteSety;
                z.id_rozhodci = rozhodci;
                z.pocet_divaku = divaci;
                z.datum_zapasu = date;
                ZapasTable.Insert(z);
                textBoxKolo.Clear();
                textBoxSetyDom.Clear();
                textBoxSetyHoste.Clear();
                textBoxDivaci.Clear();
                MessageBox.Show("Zápas byl úspěšně vložen!");

            }

        }
    }
}
