using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayıt_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-ES0PS9NQ;Initial Catalog=DbNotKayit;Integrated Security=True");

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara); // komuta parametre olarak değer ekle
            SqlDataReader rd = komut.ExecuteReader(); // veri okuyucu
            while (rd.Read()) // okuduğu müdetçe döndür
            {
                LblAdSoayd.Text = rd[2].ToString() + " " + rd[3].ToString(); // 2. ve 3. index, ad ve soyadı temsil ediyor.
                LblSinav1.Text = rd[4].ToString();
                LblSinav2.Text = rd[5].ToString();
                LblSinav3.Text = rd[6].ToString(); 
                LblOrtalama.Text = rd[7].ToString();    
                LblDurum.Text = rd[8].ToString();

            }

            baglanti.Close();


        }
    }
}
