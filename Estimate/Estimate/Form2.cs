using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimate
{
    public partial class Form2 : Form
    {
        public Form2(int num1, int num2, int num3)
        {
            InitializeComponent();
            mathGrade_num.Value = num1;
            bioGrade_num.Value = num2;
            practiceGrade_num.Value = num3;
            this.AcceptButton = button1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void mathGrade_num_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
