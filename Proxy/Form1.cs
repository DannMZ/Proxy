namespace Proxy
{
    public partial class Form1 : Form
    {
        ProxyDeminer still_alive;
        public Form1()
        {
            InitializeComponent();
            still_alive=new ProxyDeminer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(still_alive.demine());
        }
    }
}