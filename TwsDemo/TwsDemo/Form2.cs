using System.Collections.Generic;
using System.Windows.Forms;
using IBApi;
using TwsDLL;

namespace TwsDemo
{
    public partial class Form2 : Form
    {
        private Tws tws;
        List<Contract> _contracts = new List<Contract>(); 
        
        public Form2(Tws tws)
        {
            this.tws = tws;
            FormClosed += Form2_FormClosed;
            _contracts.Add(Static.CreateContract("AAPL"));
            _contracts.Add(Static.CreateContract("MSFT"));
            _contracts.Add(Static.CreateContract("S"));
            _contracts.Add(Static.CreateContract("BBY"));
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            foreach (Contract contract in _contracts)
            {
                comboBox1.Items.Add(contract.Symbol);
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }
    }
}