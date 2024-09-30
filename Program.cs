using System;
using System.Drawing;
using System.Windows.Forms;

namespace winform
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            this.pictureBox1 = new PictureBox();

            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.Text = "captcha"; 

            this.button1.Location = new System.Drawing.Point(220, 12);
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Text = "Tạo Captcha";
            this.button1.Click += new System.EventHandler(this.button1_Click);

            this.pictureBox1.Location = new Point(15, 50);
            this.pictureBox1.Size = new System.Drawing.Size(283, 100);
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle; 

            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.textBox1); 
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Text = "Captcha ";
        }

        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = this.textBox1.Text;
            CaptchaGenerator captcha = new CaptchaGenerator();
            Image captchaImage = captcha.GenerateCaptchaImage(inputText);
            this.pictureBox1.Image = captchaImage;
        }
    }

    internal class CaptchaGenerator
    {
        public Image GenerateCaptchaImage(string text)
        {
            Bitmap bitmap = new Bitmap(300, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", 24, FontStyle.Bold))
                {
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        g.DrawString(text, font, brush, new PointF(10, 30));
                    }
                }
                return bitmap;
            }
        }
    }
}
