using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktek1
{
    public partial class Form1 : Form
    {
        List<Barang> listBarang = new List<Barang>();
        public int barangID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int GetFreeID()
        {
            int nowID = 0;
            while (true)
            {
                bool adaYgSama = false;
                foreach (Barang checkBarang in listBarang)
                {
                    if (checkBarang.Id == nowID)
                        adaYgSama = true;
                }
                if (adaYgSama)
                    nowID += 1;
                else
                    break;

            }
            return nowID;
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Barang getBarang in listBarang)
            {
                string[] newRow = { "", "", "", "", "" };
                newRow[0] = getBarang.Id.ToString();
                newRow[1] = getBarang.Nama;
                newRow[2] = getBarang.Berat.ToString();
                newRow[3] = getBarang.Isi.ToString();
                newRow[4] = getBarang.Kadaluarsa.ToString();
                dataGridView1.Rows.Add(newRow);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Barang barangBaru = new Barang();
            barangBaru.IsiBarang(barangID, textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value, dateTimePicker1.Value);

            listBarang.Add(barangBaru);
            barangID = GetFreeID();
            RefreshDataGrid();
        }

        private Barang SelectBarang()
        {
            int getID = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i += 1)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    getID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    break;
                }
            }
            Barang getBarang = new Barang();
            foreach (Barang checkBarang in listBarang)
            {
                if (checkBarang.Id == getID)
                {
                    getBarang = checkBarang;
                }
            }

            if (listBarang.Contains(getBarang))
            {
                listBarang.Remove(getBarang);
            }
            return getBarang;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Barang getBarang = SelectBarang();
            if(listBarang.Contains(getBarang))
                listBarang.Remove(getBarang);
            RefreshDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Barang getBarang = SelectBarang();
            groupBox2.Enabled = true;
            textBox2.Text = getBarang.Nama;
            numericUpDown4.Value = getBarang.Berat;
            numericUpDown3.Value = getBarang.Isi;
            dateTimePicker2.Value = getBarang.Kadaluarsa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Barang getBarang = SelectBarang();
            getBarang.EditBarang(textBox2.Text, (int) numericUpDown4.Value, (int)numericUpDown3.Value, dateTimePicker2.Value);
            RefreshDataGrid();
            groupBox2.Enabled = false;
        }
    }
}
