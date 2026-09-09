using System.Media;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            PlayGreeting();
            DisplayLogo();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("voice/greeting.wav"); player.Play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("images/logo.png");
        }
    }private void Form1_Load(object sender, EventArgs e) { }
        private void PlayGreeting() { }
        private void DisplayLogo() { }

        private void ChatInput_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
