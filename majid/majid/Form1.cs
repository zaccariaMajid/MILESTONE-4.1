using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace majid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        List<richiesta> eleRichieste = new List<richiesta>();
        private void btnpreinserisci_Click(object sender, EventArgs e)
        {
            eleRichieste.Add(new richiesta("alfa", DateTime.Parse("21/03/20 10:45"), "Giacomo", "Produzione", "Problema incredibile", 90, DateTime.Parse("21/04/20 10:45")));

            eleRichieste.Add(new richiesta("beta", DateTime.Parse("15/06/18 14:50"), "Andrea", "Amministrazione", "Problema critico", 100, DateTime.Parse("16/06/18 10:20")));

            eleRichieste.Add(new richiesta("gamma", DateTime.Parse("05/08/19 08:00"), "Zaccaria", "Vendita", "Problema non urgente", 20, DateTime.Parse("20/05/20 10:20")));

            eleRichieste.Add(new richiesta("delta", DateTime.Parse("14/09/20 15:25"), "Giovanni", "Amministrazione", "Problema urgente ma non troppo", 50, DateTime.Parse("31/12/1000")));

            MessageBox.Show("Precaricati " + (eleRichieste.Count) + " prodotti.");
        }

        private void inserisci_Click(object sender, EventArgs e)
        {
            richiesta nuovoprodotto = default(richiesta);
            try
            {
                if (string.IsNullOrEmpty(txt_dataRis.Text))
                {
                    DateTime defaultdata = default(DateTime);
                    defaultdata = DateTime.Parse("31/12/1000");
                    eleRichieste.Add(nuovoprodotto = new richiesta(txt_codice.Text, DateTime.Parse(txt_dataR.Text), txt_nome.Text, cb_rep.Text, txt_desc.Text, int.Parse(txt_lvl.Text), defaultdata));
                    MessageBox.Show("Prodotto inserito con successo.");

                    txt_codice.Clear();
                    txt_dataR.Clear();
                    cb_rep.ResetText();
                    txt_nome.Clear();
                    txt_desc.Clear();
                    txt_lvl.Clear();
                    txt_dataRis.Clear();
                    return;
                }

                eleRichieste.Add(nuovoprodotto = new richiesta(txt_codice.Text, DateTime.Parse(txt_dataR.Text), txt_nome.Text, cb_rep.Text, txt_desc.Text, int.Parse(txt_lvl.Text), DateTime.Parse(txt_dataRis.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txt_codice.Clear();
                txt_dataR.Clear();
                cb_rep.ResetText();
                txt_nome.Clear();
                txt_desc.Clear();
                txt_lvl.Clear();
                txt_dataRis.Clear();
                return;
            }

            MessageBox.Show("Prodotto inserito con successo.");

            txt_codice.Clear();
            txt_dataR.Clear();
            cb_rep.ResetText();
            txt_nome.Clear();
            txt_desc.Clear();
            txt_lvl.Clear();
            txt_dataRis.Clear();
        }

        private void btnvisualizza_Click(object sender, EventArgs e)
        {


            dgvvisualizza.DataSource = eleRichieste.ToList();

            if (rb_prod.Checked)
            {
                var elen3 = eleRichieste.Where(p => p.rep == "Produzione" && p.dataRis == DateTime.Parse("31/12/1000")).OrderByDescending(p => p.lvl);

                dgvvisualizza.DataSource = elen3.ToList();
            }

            if (rb_amm.Checked)
            {
                var elen3 = eleRichieste.Where(p => p.rep == "Amministrazione" && p.dataRis == DateTime.Parse("31/12/1000")).OrderByDescending(p => p.lvl);

                dgvvisualizza.DataSource = elen3.ToList();
            }

            if (rb_vendita.Checked)
            {
                var elen3 = eleRichieste.Where(p => p.rep == "Vendita" && p.dataRis == DateTime.Parse("31/12/1000")).OrderByDescending(p => p.lvl);

                dgvvisualizza.DataSource = elen3.ToList();
            }

            rb_prod.Checked = false;
            rb_amm.Checked = false;
            rb_vendita.Checked = false;
        }

        private void btnvisualizzacategoria_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text))
            {
                return;
            }

            var richcercato = eleRichieste.Where(s => s.codice == textBox7.Text).FirstOrDefault();
            if (richcercato == null)
            {
                MessageBox.Show("Richiesta con codice " + (textBox7.Text) + " inesistente.");
                return;
            }
            textBox6.Text = richcercato.codice;
            textBox5.Text = richcercato.dataR.ToString("dd/MM/yyyy HH:mm");
            textBox4.Text = richcercato.nome;
            comboBox1.Text = richcercato.rep;
            textBox3.Text = richcercato.desc;
            textBox1.Text = richcercato.lvl.ToString();
            textBox2.Text = richcercato.dataRis.ToString("dd/MM/yyyy HH:mm");

            button1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var richcercato = eleRichieste.Where(s => s.codice == textBox7.Text).FirstOrDefault();

            eleRichieste.Remove(richcercato);

            richcercato.dataR = DateTime.Parse(textBox5.Text);
            richcercato.nome = textBox4.Text;
            richcercato.rep = comboBox1.Text;
            richcercato.desc = textBox3.Text;
            richcercato.lvl = int.Parse(textBox1.Text);
            richcercato.dataRis = DateTime.Parse(textBox2.Text);

            eleRichieste.Add(richcercato);

            dataGridView1.DataSource = eleRichieste.ToList();

            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            dataGridView1.DataSource = eleRichieste.ToList();
        }

        private void rb_prod_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btncancella_Click(object sender, EventArgs e)
        {
            var nomeC = eleRichieste.RemoveAll(n => n.nome == textBox8.Text);

            dgvcancella.DataSource = eleRichieste.ToList();

            textBox8.Clear();
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            btncancella.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var lvl1 = numericUpDown1.Value;
            var lvl2 = numericUpDown2.Value;
            int range = (int)Math.Round((eleRichieste[2].dataRis - eleRichieste[2].dataR).TotalHours);

            var data1g = eleRichieste.Where(p => (p.lvl <= lvl2 && p.lvl >= lvl1)).Select(s => new {
                range = (int)Math.Round((s.dataRis - s.dataR).TotalHours)
            });


            var media = data1g.Average(a => a.range);

            label2.Text = media.ToString();

            label2.Visible = true;

        }
    }
}
