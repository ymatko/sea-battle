using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle.View
{
    public partial class Game : Form
    {
        public Game(bool isServer, string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;

            if (isServer)
            {
                label1.Text = "Pick your ships";
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
                FreezeBoardO();
                UnfreezeBoardY();
            }
            else
            {
                FreezeBoardO();
                UnfreezeBoardY();
                label1.Text = "Pick your ships";
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
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
            if (CheckGameStatus())
                return;
            FreezeBoardO();
            label1.Text = "Opponent's Turn!";
            ReceiveMove();
            label1.Text = "Your Turn!";
            if (!CheckGameStatus())
                UnfreezeBoardO();
        }

        private Socket sock;
        private TcpListener server = null;
        private TcpClient client;
        List<string> ships = new List<string>();
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        int shipsCount = 0;
        string shipsY;
        int gameStatus = 0;
        int shipInGame = 4;

        private void StartGame(Button button)
        {
            if (shipsCount >= shipInGame)
            {
                SendShipsForOpponent();
            }
            else
            {
                CreateShip(button);
                if (shipsCount == shipInGame)
                    StartGame(button);
            }
        }

        private void SendShipsForOpponent()
        {
            FreezeBoardY();
            UnfreezeBoardO();
            byte[] ship = Encoding.UTF8.GetBytes(string.Join(" ", ships));
            sock.Send(ship);
            MessageReceiver.RunWorkerAsync();
        }


        private void CreateShip(Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.RoyalBlue;
            string shipName = button.Name.Substring(0, button.Name.Length - 1) + "O"; 
            ships.Add(shipName);
            shipsCount++;
        }

        private void ButtonRecive(Button button)
        {
            if (button.BackColor == Color.RoyalBlue)
            {
                button.BackColor = Color.Red; 
            }
            else
            {
                button.Text = "X";
            }
        }

        private void CheckShip(Button button)
        {
            int isShips = shipsY.IndexOf(button.Name);
            if(isShips != -1)
            {
                button.BackColor = Color.Red;
                gameStatus++;
            }
            else
                button.Text = "X";
        }

        private bool CheckGameStatus()
        {
            if(gameStatus == shipInGame)
            {
                FreezeBoardO();
                FreezeBoardY();
                MessageBox.Show("You Win!");
                byte[] num = { 26 };
                sock.Send(num);
                MessageReceiver.RunWorkerAsync();
                return true;
            }
            else
                return false;
        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[2024];
            sock.Receive(buffer);
            switch (buffer[0])
            {
                case 1:
                    ButtonRecive(Btn1Y);
                    break;
                case 2:
                    ButtonRecive(Btn2Y);
                    break;
                case 3:
                    ButtonRecive(Btn3Y);
                    break;
                case 4:
                    ButtonRecive(Btn4Y);
                    break;
                case 5:
                    ButtonRecive(Btn5Y);
                    break;
                case 6:
                    ButtonRecive(Btn6Y);
                    break;
                case 7:
                    ButtonRecive(Btn7Y);
                    break;
                case 8:
                    ButtonRecive(Btn8Y);
                    break;
                case 9:
                    ButtonRecive(Btn9Y);
                    break;
                case 10:
                    ButtonRecive(Btn10Y);
                    break;
                case 11:
                    ButtonRecive(Btn11Y);
                    break;
                case 12:
                    ButtonRecive(Btn12Y);
                    break;
                case 13:
                    ButtonRecive(Btn13Y);
                    break;
                case 14:
                    ButtonRecive(Btn14Y);
                    break;
                case 15:
                    ButtonRecive(Btn15Y);
                    break;
                case 16:
                    ButtonRecive(Btn16Y);
                    break;
                case 17:
                    ButtonRecive(Btn17Y);
                    break;
                case 18:
                    ButtonRecive(Btn18Y);
                    break;
                case 19:
                    ButtonRecive(Btn19Y);
                    break;
                case 20:
                    ButtonRecive(Btn20Y);
                    break;
                case 21:
                    ButtonRecive(Btn21Y);
                    break;
                case 22:
                    ButtonRecive(Btn22Y);
                    break;
                case 23:
                    ButtonRecive(Btn23Y);
                    break;
                case 24:
                    ButtonRecive(Btn24Y);
                    break;
                case 25:
                    ButtonRecive(Btn25Y);
                    break;
                case 26:
                    FreezeBoardO();
                    FreezeBoardY();
                    MessageBox.Show("You Lose", "SeaBattle");
                    break;
                default:
                    shipsY = Encoding.UTF8.GetString(buffer);
                    break;
            }
        }
        #region BtnY
        private void Btn1Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn1Y);
        }

        private void Btn2Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn2Y);

        }

        private void Btn3Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn3Y);

        }

        private void Btn4Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn4Y);

        }

        private void Btn5Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn5Y);

        }

        private void Btn6Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn6Y);
        }

        private void Btn7Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn7Y);
        }

        private void Btn8Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn8Y);
        }

        private void Btn9Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn9Y);
        }

        private void Btn10Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn10Y);
        }

        private void Btn11Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn11Y);
        }

        private void Btn12Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn12Y);
        }

        private void Btn13Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn13Y);
        }

        private void Btn14Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn14Y);
        }

        private void Btn15Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn15Y);
        }

        private void Btn16Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn16Y);
        }

        private void Btn17Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn17Y);
        }

        private void Btn18Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn18Y);
        }

        private void Btn19Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn19Y);
        }

        private void Btn20Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn20Y);
        }

        private void Btn21Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn21Y);
        }

        private void Btn22Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn22Y);
        }

        private void Btn23Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn23Y);
        }

        private void Btn24Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn24Y);
        }

        private void Btn25Y_Click(object sender, EventArgs e)
        {
            StartGame(Btn25Y);
        }
        #endregion
        #region BtnO
        private void Btn1O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn1O);
            byte[] num = { 1 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn2O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn2O);
            byte[] num = { 2 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn3O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn3O);
            byte[] num = { 3 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn4O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn4O);
            byte[] num = { 4 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn5O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn5O);
            byte[] num = { 5 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn6O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn6O);
            byte[] num = { 6 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn7O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn7O);
            byte[] num = { 7 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn8O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn8O);
            byte[] num = { 8 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn9O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn9O);
            byte[] num = { 9 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn10O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn10O);
            byte[] num = { 10 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn11O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn11O);
            byte[] num = { 11 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn12O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn12O);
            byte[] num = { 12 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn13O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn13O);
            byte[] num = { 13 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn14O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn14O);
            byte[] num = { 14 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn15O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn15O);
            byte[] num = { 15 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn16O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn16O);
            byte[] num = { 16 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn17O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn17O);
            byte[] num = { 17 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn18O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn18O);
            byte[] num = { 18 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn19O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn19O);
            byte[] num = { 19 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn20O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn20O);
            byte[] num = { 20 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn21O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn21O);
            byte[] num = { 21 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn22O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn22O);
            byte[] num = { 22 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn23O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn23O);
            byte[] num = { 23 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        private void Btn24O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn24O);
            byte[] num = { 24 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }
        private void Btn25O_Click(object sender, EventArgs e)
        {
            CheckShip(Btn25O);
            byte[] num = { 25 };
            sock.Send(num);
            MessageReceiver.RunWorkerAsync();
            FreezeBoardO();
        }

        #endregion
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
