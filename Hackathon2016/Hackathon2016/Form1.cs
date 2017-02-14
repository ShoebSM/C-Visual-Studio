using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CSCI 473 Assign 5
//Ultimate Fortune Telling 
// Uses: Form Application, Exceptions, Random Generator, Graphics, Radio Buttons, Buttons, TextBox, Labels, Hide/Display functionality 
//    for buttons/labels
//Shoeb Mohammed


namespace Hackathon2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //String arrays, i.e possible fortunes 
        String[] causesOfDeath = { "brutal car Accident", "infectious disease", "crippling heart attack", "gruesome fall down the stairs", "a troubling homicide", "nasty infection", "tragic boat accident", "strange sleep disorder", "choking accident" };
        String[] maleMarry = { "the girl next door", "Rihanna", "Ellen Degeneres", "your ex girlfriend", "nobody, you won't love anyone and die alone" };
        String[] femaleMarry = { "the local plumber", "the guy you told your boyfriend not to worry about", "Odell Beckham Jr", "Your high school counselor" };
        String[] home = { "trailer", "apartment", "cardboard box", "mansion", "ranch", "cabin" };
        String[] country = { "America", "England", "China", "Japan", "Russia", "India", "Saudi Arabia", "Kuwait", "Italy" };

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Black;
            label4.BackColor = System.Drawing.Color.Black;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Black;
            label7.BackColor = System.Drawing.Color.Black;
            label8.BackColor = System.Drawing.Color.Black;
            radioButton1.BackColor = System.Drawing.Color.Transparent;
            radioButton2.BackColor = System.Drawing.Color.Transparent;
        }

        private void Reveal_Click(object sender, EventArgs e)
        {

            String Name = textBox1.Text;
            String Age = textBox2.Text;
            //Catches exception to make sure age entered is numeric
            try
            {
                int test = Convert.ToInt32(Age);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Exception caught {0}. Make sure age entered is in number format", ex);
                throw ex;
            }
           
            int Years = Convert.ToInt32(Age);
            Random r = new Random();

            int death = r.Next(Years, 110);
            Random r1 = new Random();

            String cause = causesOfDeath[r1.Next(0, causesOfDeath.Length)];
            Reveal.Hide();//Hides button

            Random r3 = new Random();
            String household = home[r3.Next(0, home.Length)];

            Random r4 = new Random();
            String countryLived = country[r4.Next(0, country.Length)];

            label3.Show(); //Displays values generated
            label4.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            this.label3.Text = string.Format("Greetings, {0} of age {1}. Beware as I fortell your forture", Name, Age);
            this.label4.Text = string.Format("You will die at age {0} due to {1}", death, cause);

            if (death >= 25)
            {
                if (radioButton1.Checked)
                    {
                    Random r2 = new Random();
                    String marriage = maleMarry[r2.Next(0, maleMarry.Length)];
                    this.label6.Text = string.Format("You will marry {0} and live in a {1} in {2}", marriage, household, countryLived);
                    }
                else if (radioButton2.Checked)
                {
                    Random r2 = new Random();
                    String marriage = femaleMarry[r2.Next(0, femaleMarry.Length)];
                    this.label6.Text = string.Format("You will marry {0} and live in a {1} in {2}", marriage, household, countryLived);

                }
            }
            else
            {
                this.label6.Text = "You will die too early to marry. Better install Tinder.";  
            }
            if (death >= 30)
            {
                Random r5 = new Random();
                int kids = r.Next(0, 10);
                int pets = r.Next(0, 5);
                this.label7.Text = string.Format("You will have {0} kids and {1} pet(s).", kids, pets);
            }
            else
            {
                Random r5 = new Random();
                int pets = r.Next(0, 5);
                this.label7.Text = string.Format("You will have {0} pets and no children", pets);
            }

            Random r6 = new Random();
            int funeral = r.Next(0, 1000);
            this.label8.Text = string.Format("{0} people will attend your funeral ", funeral);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label3.Hide();
            label4.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            Reveal.Show();
        }


    }
}
