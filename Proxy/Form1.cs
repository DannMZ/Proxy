namespace Proxy
{
    public partial class Start : Form
    {
        Form2 f2;
        public Start()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int a) && int.TryParse(textBox2.Text, out int b) && int.TryParse(textBox3.Text, out int c))
            {
                if (MathF.Abs(Int32.Parse(textBox1.Text)) < 1000 && MathF.Abs(Int32.Parse(textBox2.Text)) < 1000 &&
                    MathF.Abs(Int32.Parse(textBox3.Text)* Int32.Parse(textBox3.Text))<
                    MathF.Abs(Int32.Parse(textBox2.Text)* Int32.Parse(textBox1.Text))/5)
                {
                    f2 = new Form2(new Point(Math.Abs(Int32.Parse(textBox2.Text)), Math.Abs(Int32.Parse(textBox2.Text)) ), Math.Abs(Int32.Parse(textBox3.Text)),this);
                    f2.Show();
                    this.Visible = false;
                }
            }
        }
    }
}