using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace praktek1
{
    public class Barang
    {
        private int berat;
        private int isi;
        private DateTime kadaluarsa;
        private String nama;
        private int id;

        public int Berat { get => berat; }
        public int Isi { get => isi; }
        public DateTime Kadaluarsa { get => kadaluarsa;  }
        public string Nama { get => nama;  }
        public int Id { get => id; }

        public void CheckKadaluarsa()
        {
            throw new System.NotImplementedException();
        }

        public void IsiBarang(int getId, string getNama, int getBerat, int getIsi, DateTime getKadaluarsa)
        {
            this.id = getId;
            this.nama = getNama;
            this.berat = getBerat;
            this.isi = getIsi;
            this.kadaluarsa = getKadaluarsa;
        }

        public void EditBarang(string getNama, int getBerat, int getIsi, DateTime getKadaluarsa)
        {
            this.nama = getNama;
            this.berat = getBerat;
            this.isi = getIsi;
            this.kadaluarsa = getKadaluarsa;
        }
    }
}