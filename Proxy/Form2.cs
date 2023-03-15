using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    public partial class Form2 : Form
    {
        ProxyDeminer Game_;
        Point grid_size;
        Form parr;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Point grid, int mines_in_game, Form Parent)
        {
            InitializeComponent();
            grid_size = new Point(grid.X, grid.Y);
            Game_ = new ProxyDeminer(grid, mines_in_game);

            parr = Parent;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // for (int i = 0; dataGridView1.ColumnCount < grid_size.X; i++){dataGridView1.Columns.Add("Column" + i.ToString(), i.ToString());}dataGridView1.Rows.Add(grid_size.Y);
            // dataGridView1.Columns.Add(new DataGridViewColumn());
            // dataGridView1.AutoResizeColumnHeadersHeight(); dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            // Resize all the row heights to fit the contents of all non-header cells.


            dataGridView1.ColumnCount = grid_size.X; dataGridView1.RowCount = grid_size.Y;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parr.Close();
        }

        private void Form2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Value =
                Game_.demine(dataGridView1.CurrentCellAddress);
            int a = 0;
            a = 1;
        }
    }
}
