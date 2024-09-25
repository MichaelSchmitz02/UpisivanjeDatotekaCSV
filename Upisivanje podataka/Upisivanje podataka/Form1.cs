using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Upisivanje_podataka
{
    public partial class Form1 : Form
    {
        List<Osoba> listaOsoba = new List<Osoba>();
        Osoba osoba = new Osoba();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_brisanje_Click(object sender, EventArgs e)
        {
            txt_email.Clear();
            txt_godinaRodjenja.Clear(); 
            txt_ime.Clear();
            txt_prezime.Clear();
        }

        private void btn_upis_Click(object sender, EventArgs e)
        {
            // Osoba osoba = new Osoba();
            try
            {
                Osoba osoba = new Osoba(txt_ime.Text, txt_prezime.Text, txt_email.Text, Convert.ToInt16(txt_godinaRodjenja.Text));
                
                     /*osoba.Ime = txt_ime.Text;
                     osoba.Prezime = txt_prezime.Text;
                     osoba.Email = txt_email.Text;
                osoba.GodinaRodjena = Convert.ToUInt16(txt_Godinarodjenja.txt);*/


                txt_email.Clear();
                txt_godinaRodjenja.Clear();
                txt_ime.Clear();
                txt_prezime.Clear();
                txt_ime.Focus();

              DialogResult upit =  MessageBox.Show("Želi teli unesti još podataka", "Upit",
                  MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                switch(upit) { 
                case DialogResult.Yes:
                        {
                            listaOsoba.Add(osoba);
                            break;
                        }
                        case DialogResult.No:
                        {
                            listaOsoba.Add(osoba);
                            txt_ime.Enabled = false;    
                            txt_prezime.Enabled = false;    
                            txt_godinaRodjenja.Enabled = false;
                            txt_email.Enabled = false;
                            break;
                        }
                }
            }
            catch(Exception greska) { 
                MessageBox.Show(greska.Message,"Pogrešan unos"
                  ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }   
        }

        private void txt_godinaRodjenja_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Spremi_Click(object sender, EventArgs e)
        {
            /*
            txtispis.Text = "Ime,Prezime,Email,GodinaRodjenja" + Environment.NewLine;
            foreach (Osoba osoba in listaOsoba)
            {
                txtispis.AppendText(osoba.ToString() + Environment.NewLine);*/
            string putanjaDoDatoteke = "C:\\Users\\Ucenik\\Documents\\testCVS";
            try
            {
                using (StreamWriter sw = new StreamWriter(putanjaDoDatoteke))
                {
                    sw.WriteLine("Ime,Prezime,Email,GodinaRodenja");

                    foreach (Osoba osoba in listaOsoba)
                    {
                        sw.WriteLine(osoba.ToString());
                    }
                }
                MessageBox.Show("Podaci su uspjesno spremljeni u CSV datoteku!", "Uspijeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Doslo je do pogreske prilikom spremanja podataka: " + ex.Message, "Pogreska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            }
            
    
}
