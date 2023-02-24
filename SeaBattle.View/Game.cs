using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SeaBattle.View
{
    public partial class Game : Form
    {
        public Game(bool isHost, string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (isHost)
            {
                PlayerChar = 'X';
                OpponentChar = 'O';
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
            }
            else
            {
                PlayerChar = 'O';
                OpponentChar = 'X';
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CheckState())
                return;
            FreezeBoardY();
            UnfreezeBoardO();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            label1.Text = "Your Trun!";
            if (!CheckState())
                UnfreezeBoardY();
                FreezeBoardO(); 
        }

        private char PlayerChar;
        private char OpponentChar;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        #region Freeze&Unfrees board
        private void FreezeBoardY()
        {
            Btn1Y.Enabled = false;
            Btn2Y.Enabled = false;
            Btn3Y.Enabled = false;
            Btn4Y.Enabled = false;
            Btn5Y.Enabled = false;
            Btn6Y.Enabled = false;
            Btn7Y.Enabled = false;
            Btn8Y.Enabled = false;
            Btn9Y.Enabled = false;
            Btn10Y.Enabled = false;
            Btn11Y.Enabled = false;
            Btn12Y.Enabled = false;
            Btn13Y.Enabled = false;
            Btn14Y.Enabled = false;
            Btn15Y.Enabled = false;
            Btn16Y.Enabled = false;
            Btn17Y.Enabled = false;
            Btn18Y.Enabled = false;
            Btn19Y.Enabled = false;
            Btn20Y.Enabled = false;
            Btn21Y.Enabled = false;
            Btn22Y.Enabled = false;
            Btn23Y.Enabled = false;
            Btn24Y.Enabled = false;
            Btn25Y.Enabled = false;
        }
        private void FreezeBoardO()
        {
            Btn1O.Enabled = false;
            Btn2O.Enabled = false;
            Btn3O.Enabled = false;
            Btn4O.Enabled = false;
            Btn5O.Enabled = false;
            Btn6O.Enabled = false;
            Btn7O.Enabled = false;
            Btn8O.Enabled = false;
            Btn9O.Enabled = false;
            Btn10O.Enabled = false;
            Btn11O.Enabled = false;
            Btn12O.Enabled = false;
            Btn13O.Enabled = false;
            Btn14O.Enabled = false;
            Btn15O.Enabled = false;
            Btn16O.Enabled = false;
            Btn17O.Enabled = false;
            Btn18O.Enabled = false;
            Btn19O.Enabled = false;
            Btn20O.Enabled = false;
            Btn21O.Enabled = false;
            Btn22O.Enabled = false;
            Btn23O.Enabled = false;
            Btn24O.Enabled = false;
            Btn25O.Enabled = false;
        }
        private void UnfreezeBoardY()
        {
            if (Btn1Y.Text == "")
                Btn1Y.Enabled = true;
            if (Btn2Y.Text == "")
                Btn2Y.Enabled = true;
            if (Btn3Y.Text == "")
                Btn3Y.Enabled = true;
            if (Btn4Y.Text == "")
                Btn4Y.Enabled = true;
            if (Btn5Y.Text == "")
                Btn5Y.Enabled = true;
            if (Btn6Y.Text == "")
                Btn6Y.Enabled = true;
            if (Btn7Y.Text == "")
                Btn7Y.Enabled = true;
            if (Btn8Y.Text == "")
                Btn8Y.Enabled = true;
            if (Btn9Y.Text == "")
                Btn9Y.Enabled = true;
            if (Btn10Y.Text == "")
                Btn10Y.Enabled = true;
            if (Btn11Y.Text == "")
                Btn11Y.Enabled = true;
            if (Btn12Y.Text == "")
                Btn12Y.Enabled = true;
            if (Btn13Y.Text == "")
                Btn13Y.Enabled = true;
            if (Btn14Y.Text == "")
                Btn14Y.Enabled = true;
            if (Btn15Y.Text == "")
                Btn15Y.Enabled = true;
            if (Btn16Y.Text == "")
                Btn16Y.Enabled = true;
            if (Btn17Y.Text == "")
                Btn17Y.Enabled = true;
            if (Btn18Y.Text == "")
                Btn18Y.Enabled = true;
            if (Btn19Y.Text == "")
                Btn19Y.Enabled = true;
            if (Btn20Y.Text == "")
                Btn20Y.Enabled = true;
            if (Btn21Y.Text == "")
                Btn21Y.Enabled = true;
            if (Btn22Y.Text == "")
                Btn22Y.Enabled = true;
            if (Btn23Y.Text == "")
                Btn23Y.Enabled = true;
            if (Btn24Y.Text == "")
                Btn24Y.Enabled = true;
            if (Btn25Y.Text == "")
                Btn25Y.Enabled = true;
        }
        private void UnfreezeBoardO()
        {
            if (Btn1O.Text == "")
                Btn1O.Enabled = true;
            if (Btn2O.Text == "")
                Btn2O.Enabled = true;
            if (Btn3O.Text == "")
                Btn3O.Enabled = true;
            if (Btn4O.Text == "")
                Btn4O.Enabled = true;
            if (Btn5O.Text == "")
                Btn5O.Enabled = true;
            if (Btn6O.Text == "")
                Btn6O.Enabled = true;
            if (Btn7O.Text == "")
                Btn7O.Enabled = true;
            if (Btn8O.Text == "")
                Btn8O.Enabled = true;
            if (Btn9O.Text == "")
                Btn9O.Enabled = true;
            if (Btn10O.Text == "")
                Btn10O.Enabled = true;
            if (Btn11O.Text == "")
                Btn11O.Enabled = true;
            if (Btn12O.Text == "")
                Btn12O.Enabled = true;
            if (Btn13O.Text == "")
                Btn13O.Enabled = true;
            if (Btn14O.Text == "")
                Btn14O.Enabled = true;
            if (Btn15O.Text == "")
                Btn15O.Enabled = true;
            if (Btn16O.Text == "")
                Btn16O.Enabled = true;
            if (Btn17O.Text == "")
                Btn17O.Enabled = true;
            if (Btn18O.Text == "")
                Btn18O.Enabled = true;
            if (Btn19O.Text == "")
                Btn19O.Enabled = true;
            if (Btn20O.Text == "")
                Btn20O.Enabled = true;
            if (Btn21O.Text == "")
                Btn21O.Enabled = true;
            if (Btn22O.Text == "")
                Btn22O.Enabled = true;
            if (Btn23O.Text == "")
                Btn23O.Enabled = true;
            if (Btn24O.Text == "")
                Btn24O.Enabled = true;
            if (Btn25O.Text == "")
                Btn25O.Enabled = true;
        }
        #endregion

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }
    }

}
