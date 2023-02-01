using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Organization_HW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public int[] Rand_Array = new int[900];

        Random rnd;
        public void Generate900Random()
        {
            rnd = new Random();
            for (int i = 0; i < Rand_Array.Length; i++)
            {
                Rand_Array[i] = rnd.Next(1, 900);
            }
        }

        

        public int[] reischKey = new int[997];
        public int[] reischLink = new int[997];
        public static float reischProbe = 0;
        public void addToREISCH()
        {
            Random reisch = new Random();
            int rand_reisch = reisch.Next(0, 997);
            for (int i = 0; i < Rand_Array.Length; i++)
            {
                int location = Rand_Array[i] % 997;
                if (reischKey[location] == 0)
                {
                    reischKey[location] = Rand_Array[i];
                    reischProbe++;
                }
                else
	            {
                    reischProbe++;
                    if (reischLink[location]!=0)
                    {
                        reischProbe++;
                        while (reischLink[location]==0)
                        {
                            location = reischLink[location];
                        }
                    }

                    while (reischKey[rand_reisch]!=0)
                    {
                        rand_reisch = reisch.Next(0, 997);
                    }
                    reischKey[rand_reisch] = Rand_Array[i];
                    reischLink[location] = rand_reisch;
                    reischProbe++;
                }
            }
        }
      

      
        public static int REISCH = 0;
        public static bool REISCHfindYes = false;
        public void searchREISCH(int searching)
        {
            int location = searching % 997;

            if (reischKey[location] != 0)
            {
                while (REISCHfindYes == false)
                {
                    REISCH++;
                    if (reischKey[location] == searching)
                    {
                        REISCHfindYes = true;
                        break;
                    }
                    else
                    {
                        if (reischLink[location] == 0)
                        {
                            MessageBox.Show("Aranan değer bulunamadı!!");
                            break;
                        }
                        else
                        {
                            location = reischLink[location];
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Aranan değer bulunamadı!!");
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            Generate900Random();
            for (int i = 0; i < Rand_Array.Length; i++)
            {
                RandList.Items.Add(Rand_Array[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            addToREISCH();

            for (int i = 0; i < 900; i++)
            {

                reisch_list.Items.Add(i + ". key = " + reischKey[i]);
                reisch_link.Items.Add(i + ". link = " + reischLink[i]);
            }
        
            label9.Text = (90.2).ToString();


     

            string av_reisch = Convert.ToString(reischProbe / 900);

            label16.Text = av_reisch;
        }



        private void button6_Click(object sender, EventArgs e)
        /*
         hocam düzgün çalışmıyor searchREISCH metodum doğru olmasına rağmen
        REISCH değerini sadece 1 kere güncelliyor sebebini bulamadım ve düzeltemedim
        bu yüzden probe ararken uygulmayı tekrar tekrar çalıştırmak gerekiyor yoksa ilk aranan değerin probe değerini getiriyor
         */
        {
            int searching = Convert.ToInt32(textBox4.Text);
            searchREISCH(searching);
            label35.Text = Convert.ToString(REISCH);
        }

        private void reisch_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RandList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
