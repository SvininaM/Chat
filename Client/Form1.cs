using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonNet;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSend.Enabled = false;
        }
        private string sHost = "LAPTOP-A8CMBCCM";
        private string usHost = "";
        private Socket cSocket;
        private int port = 8034;
        private NetMessaging net;
        private Thread t = null;
        ThreadStart th;


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Подключить")
            {
                if (!(usHost.Length > 0))
                {
                    usHost = sHost;
                    txtHost.Text = usHost;
                }
                    
                if (txtUserName.Text.Length > 0)
                {
                    btnConnect.Text = "Отключить";
                    txtUserName.Enabled = false;
                    txtHost.Enabled = false;
                    //проверить имя непустое
                    Connecting();
                }
                else
                {
                    txtUserName.Text = "Введите имя!!!";
                }
                
            }
            else
            {
                Stop();
                btnConnect.Text = "Подключить";
                txtUserName.Enabled = true;
                txtHost.Enabled = true;
                btnSend.Enabled = false;
            }
        }

        private void Connecting()
        {
            try
            {
                //Console.WriteLine("Подключение к {0}", this.sHost);
                txtChat.AppendText("Подключение к " + usHost.ToString() + Environment.NewLine);
                cSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                cSocket.Connect(usHost, port);
                net = new NetMessaging(cSocket);
                net.LoginCmdReceived += OnLogin;
                //net.SendData("LOGIN", txtUserName.Text);
                net.UserListCmdReceived += OnUserList;
                net.StartCmdReceived += OnStart;
                net.MessageCmdReceived += OnMessage;
                net.CheckNameCmdReceived += OnCheckName;
                new Thread(() =>
                {
                    try
                    {
                        net.Communicate();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Не удалось получить данные. Завершение соединения...");
                        //txtChat.AppendText("Не удалось получить данные. Завершение соединения...");
                    }
                }).Start();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Что-то пошло не так... :(");
                txtChat.AppendText("Что-то пошло не так... :(");
                Stop();
                btnConnect.Text = "Подключить";
                txtUserName.Enabled = true;
                txtHost.Enabled = true;
                btnSend.Enabled = false;
            }
        }


        private void OnMessage(string command, string data)
        {
            //Console.WriteLine("{0}", data);
            //txtChat.AppendText(data + Environment.NewLine);
            if (!txtChat.InvokeRequired) 
                txtChat.AppendText(data + Environment.NewLine);
            else
            {
                //object[] value = { command, data };
                NetMessaging.SetTextCallback d = new NetMessaging.SetTextCallback(OnMessage);
                Invoke(d, new object[] { command, data });
                //Invoke(new NetMessaging.ReceiveData(OnMessage), value);
            }
        }

        private void OnStart(string command, string data)
        {
           
            //Console.WriteLine("Вы можете писать сообщения!");
            if (!txtChat.InvokeRequired)
            {
                txtChat.AppendText("Вы можете писать сообщения!" + Environment.NewLine);
                btnSend.Enabled = true;
                GoMessaging();
            }
            else
            {
                NetMessaging.SetTextCallback d = new NetMessaging.SetTextCallback(OnStart);
                Invoke(d, new object[] { command, data });
                //GoMessaging();

            }
            //txtChat.AppendText("Вы можете писать сообщения!");
            //GoMessaging();
        }

        private void OnUserList(string command, string data)
        {
            if (!txtChat.InvokeRequired)
            {
                var us = data.Split(',');
                txtChat.AppendText("Список подключенных клиентов:" + Environment.NewLine);
                foreach (var cl in us)
                {
                    txtChat.Text += cl + ",";
                }
                txtChat.Text += "\r\n";
                txtChat.AppendText("___________________________" + Environment.NewLine);
            }
            else
            {
                object[] value = { command, data };
                Invoke(new NetMessaging.SetTextCallback(OnUserList), value);
            }
        }

        private string mess ="";
        private void GoMessaging()
        {
            th = new ThreadStart(MessageTest);
            t = new Thread(th);
            t.Start();
            /*new Thread(() =>
            {
                while (true)
                {
                    if (mess.Length>0)
                    {
                        net.SendData("MESSAGE", mess);
                        mess = "";
                    }
                    //String userData = "";
                    //userData = Console.ReadLine();
                    //this.Invoke((new NetMessaging(this.cSocket)).))
                    //net.SendData("MESSAGE", userData);
                }
            }
            ).Start();*/
        }

        private void MessageTest()
        {
            while (true)
            {
                if (mess.Length > 0)
                {
                    net.SendData("MESSAGE", mess);
                    mess = "";
                }
                //String userData = "";
                //userData = Console.ReadLine();
                //this.Invoke((new NetMessaging(this.cSocket)).))
                //net.SendData("MESSAGE", userData);
            }
        }

        void OnLogin(string c, string d)
        {
            String userName = "";
            //Console.WriteLine("Представьтесь: ");
            userName = txtUserName.Text;
            //txtChat.AppendText(txtUserName.Text + " присоеденился к чату" + Environment.NewLine);
            //userName = Console.ReadLine();
            //net.SendData("CHECKNAME", userName);
            net.SendData("LOGIN", userName);
        }
        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            //переделать если ноль то стандартный и изменить в самом тексте
                usHost = txtHost.Text;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //net.SendData("MESSAGE", txtMessage.Text);
            if (txtMessage.TextLength > 0)
            {
                mess = txtMessage.Text;
                txtMessage.Text = "";
            }
        }

        void OnCheckName(string c, string d)
        {
            if (d == "?")
                net.SendData("CHECKNAME", txtUserName.Text);
            if (d== "NO")
            {
                if (!txtChat.InvokeRequired)
                {
                    txtChat.AppendText("Измените имя и повторите попытку" + Environment.NewLine);
                    btnUserName.Visible = true;
                    txtUserName.Enabled = true;

                }
                else
                {
                    NetMessaging.SetTextCallback d1 = new NetMessaging.SetTextCallback(OnCheckName);
                    Invoke(d1, new object[] { "CHECKNAME", "NO" });
                }
            }
            if (d=="YES")
            {
                net.SendData("LOGIN", txtUserName.Text);
            }

        }

        private void btnUserName_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
            {
                net.SendData("CHECKNAME", txtUserName.Text);
                btnUserName.Visible = false;
                txtUserName.Enabled = false;
            }
            else
            {
                txtUserName.Text = "Введите имя!!!";
            }

        }

        private void Stop()
        {
            if (net != null)
                net.SendData("DISCONNECT", "!");
            if (t != null)
            {
                t.Abort();
                t.Join();
                t = null;
            }
            if (cSocket != null)
                cSocket.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Stop();
            //btnConnect.Text = "Подключить";
            //txtUserName.Enabled = true;
            //txtHost.Enabled = true;
            //btnSend.Enabled = false;
           
        }
    }
}
