using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;
using Domain.ValueObjects;

namespace Presentation.Forms
{
    public partial class Test : Form
    {
        private PiezasModel piezas = new PiezasModel();
        public Test()
        {
            InitializeComponent();
        }

        private void ListPiezas()
        {
            try
            {
                dataGridView1.DataSource= piezas.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            ListPiezas();
        }
    }
}
