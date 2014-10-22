using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IBApi;
using TwsDLL;

namespace TwsDemo
{

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public partial class Form2 : Form
    {
        private EWrapperImpl _ibClient;
        private readonly List<Contract> _contracts = new List<Contract>();
        private int idCounter;

        public Form2(EWrapperImpl IbClient)
        {
            _ibClient = IbClient;
            FormClosed += Form2_FormClosed;
            _contracts.Add(Tws.CreateContract("AAPL"));
            _contracts.Add(Tws.CreateContract("S"));
            _contracts.Add(Tws.CreateContract("BBY"));
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tws.CancelMarketData(_ibClient, idCounter);
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (Contract contract in _contracts)
            {
                comboBox1.Items.Add(new ComboboxItem {Text = contract.Symbol, Value = counter++});
            }

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idCounter > 0) Tws.CancelMarketData(_ibClient, idCounter - 1);
            Tws.StartMarketData(_ibClient, idCounter,
                _contracts[Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).Value.ToString())]);
            idCounter++;
        }
    }
}