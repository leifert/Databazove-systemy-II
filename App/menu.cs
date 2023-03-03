using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolejbalovaLigaORM
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void btn_liga_Click(object sender, EventArgs e)
        {
            Form prehled = new PrehledLigy();
            prehled.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form prestup = new PrestupHrace();
            prestup.Show();
        }
    }
}
