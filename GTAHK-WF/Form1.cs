using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTAHK_WF
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        string[] laninterfaces = null;
        bool interfacesDisconnected = false;
        bool althkb = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wl("Loading interfaces...");
            laninterfaces = GetInterfaces();
            foreach (string s in laninterfaces)
            {
                wl("Found interface: " + (s.Split(';'))[0]);
            }
            Form1.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 2, (int)Keys.NumPad1);
        }
        protected override void WndProc(ref Message m)
        {
            
            if (m.Msg == 0x312)
            {
                Keys vk = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int fsModifiers = ((int)m.LParam & 0xFFFF);
                if (vk == Keys.NumPad1 || vk == Keys.Right && fsModifiers == 2)
                {
                    InterfaceDisconnect();
                }
            }
            base.WndProc(ref m);
        }
        void wl(object m)
        {
            if (nconsole.Text.Length == 0)
            {
                nconsole.Text = m.ToString();
            }
            else
            {
                nconsole.Text = nconsole.Text.ToString() + Environment.NewLine + m.ToString();
            }
        }
        public void InterfaceDisconnect()
        {
            if (interfacesDisconnected)
            {
                wl("Must wait for interface reconnects before disconnecting again");
            }
            else
            {
                wl("Starting Disconnects");
                interfacesDisconnected = true;
                foreach (string s in laninterfaces)
                {
                    string[] spl = (s.Split(';'));
                    if (spl[1] == "True")
                    {
                        wl(string.Format("Disconnected Interface: {0}", spl[0]));
                        SendToNetSH(string.Format("interface set interface name=\"{0}\" admin=disabled", spl[0]), true);
                    }
                }
                wl("Disconnected at - " + DateTime.Now);
                wl("Reconnecting in 10 seconds");
                ReconnectTimer.Enabled = true;
            }
        }
        public void InterfaceReconnect(object sender, EventArgs e)
        {
            foreach (string s in laninterfaces)
            {
                string[] spl = (s.Split(';'));
                if (spl[1] == "True")
                {
                    SendToNetSH(string.Format("interface set interface name=\"{0}\" admin=enabled", spl[0]), true);
                    wl("Reconnected " + spl[0]);
                }
            }
            ReconnectTimer.Enabled = false;
            interfacesDisconnected = false;
        }
        public string SendToNetSH(string c, bool a = false)
        {
            Process cp = new Process();
            cp.StartInfo.FileName = @"C:\Windows\System32\netsh.exe";
            cp.StartInfo.Arguments = c;
            cp.StartInfo.RedirectStandardInput = true;
            cp.StartInfo.RedirectStandardOutput = true;
            cp.StartInfo.CreateNoWindow = true;
            cp.StartInfo.UseShellExecute = false;
            if (a) cp.StartInfo.Verb = "runas";
            cp.Start();
            string str = cp.StandardOutput.ReadToEnd();
            cp.Close();
            cp.Dispose();
            return str;
        }
        public string[] GetInterfaces()
        {
            string m = SendToNetSH("interface show interface");
            var list = m.Split(' ');
            m = string.Join(" ", list);
            var s = m.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var l = s.ToList();
            bool connected = false;
            l.RemoveAt(0);
            l.RemoveAt(0);
            l.RemoveAt(0);
            l.RemoveAt(l.Count - 1);
            l.RemoveAt(l.Count - 1);
            List<string> laninterfaces = new List<string>();
            for (var i = 0; i < l.Count; i++)
            {
                string[] spl = l[i].Split(' ');
                string str = l[i];
                int jump = 0;
                if (spl[0] == "Enabled")
                {
                    str = str.Substring(15);
                    jump += 8;
                }
                else
                {
                    str = str.Substring(16);
                    jump += 7;
                }
                if (spl[jump] == "Connected")
                {
                    str = str.Substring(15);
                    jump += 6;
                    connected = true;
                }
                else
                {
                    str = str.Substring(18);
                    jump += 3;
                }
                if (spl[jump] == "Dedicated")
                {
                    str = str.Substring(17);
                    jump += 8;
                }
                else
                {
                    wl("Message Simple_AOB with the following: " + string.Format("{0}:{1}:{2}", l[i], str, jump));
                }
                laninterfaces.Add(str + ";" + connected);
            }
            return laninterfaces.ToArray();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (interfacesDisconnected)
            {
                e.Cancel = true;
                wl("Cannot exit before interfaces are reconnected (Safeguard)");
            }
            Form1.UnregisterHotKey(this.Handle, this.GetType().GetHashCode());
        }

        private void ReloadInterfaces_Click(object sender, EventArgs e)
        {
            wl("Reloading interfaces");
            laninterfaces = GetInterfaces();
            foreach (string s in laninterfaces)
            {
                wl("Found interface: " + (s.Split(';'))[0]);
            }
        }

        private void althk_Click(object sender, EventArgs e)
        {
            if (!althkb)
            {
                Form1.UnregisterHotKey(this.Handle, this.GetType().GetHashCode());
                Form1.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 2, (int)Keys.Right);
                hklbl.Text = "Current HotKey: CTRL+RightArrow";
                althkb = true;
            }
            else
            {
                Form1.UnregisterHotKey(this.Handle, this.GetType().GetHashCode());
                Form1.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 2, (int)Keys.NumPad1);
                hklbl.Text = "Current HotKey: CTRL+NumPad1";
                althkb = false;
            }
        }
    }
}
