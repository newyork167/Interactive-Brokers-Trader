using System;
using System.Windows.Forms;
using TwsDLL;

namespace TwsDemo
{
    public partial class Form1 : Form
    {
        private EWrapperImpl _ibClient;
        private bool _connected = false;
        private Tws tws;
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ibClient = new EWrapperImpl();
            tws = new Tws(_ibClient);

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(@"One or more required fields are empty", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                var continueCode = DialogResult.Retry;

                while (!_connected && continueCode == DialogResult.Retry)
                {
                    try
                    {
                        _connected = true;
                        tws.Connect(textBox1.Text, Convert.ToInt32(textBox2.Text), 0);
                        //_connected = tws.IsConnected();
                    }
                    catch (Exception ex)
                    {
                        continueCode = MessageBox.Show(ex.ToString(), @"Connection Failed", MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error);
                    }
                }
            }

            if (!_connected) return;

            form2 = new Form2(tws);
            Visible = false;
            form2.Visible = true;
        }
    }
}