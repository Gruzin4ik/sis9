using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Shelia9
{
    public partial class Form1 : Form
    {
        private Process[] procs;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = Application.ExecutablePath;
            
            listBox1.Items.Add(appPath);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Add(System.AppDomain.CurrentDomain.BaseDirectory);

            listBox1.Items.Add(Application.StartupPath);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Process proc = new Process();
           
            proc.StartInfo.FileName = @"Notepad.exe";
            proc.StartInfo.Arguments = "";
            proc.Start();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            Process.Start("notepad.exe", "test.txt");
            
            Process.Start("iexplore.exe", "netsources.narod.ru");
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            ProcessStartInfo start_info = new ProcessStartInfo
            (@"C:\windows\system32\notepad.exe");
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            
            Process proc = new Process(); 
            proc.StartInfo = start_info;
            
            proc.Start();
            
            proc.WaitForExit();
            MessageBox.Show("Код завершения: " + proc.ExitCode, "Завершение " +
            "Код", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            procs = Process.GetProcessesByName("Notepad");
            int i = 0;
            while (i != procs.Length)
            {
                procs[i].Kill();
                i++;
                MessageBox.Show("Всего : " + i.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            string sysFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.System);
            
            ProcessStartInfo pInfo = new ProcessStartInfo();
            
            pInfo.FileName = sysFolder + @"\eula.txt";
            
            pInfo.UseShellExecute = true;
            Process p = Process.Start(@"C:\Users\gruzi\source\repos\Sis_Shelia9\eula.txt.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int am = Process.GetCurrentProcess().ProcessorAffinity.ToInt32();
            int processorCount = 0;
            while (am != 0)
            {
                processorCount++;
                am &= (am - 1);
            }
            MessageBox.Show(processorCount.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
          String.Format(
          "Число процессоров: {0}",
          Environment.ProcessorCount.ToString()));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            System.Threading.Thread.Sleep(3000);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
                listBox1.Items.Add(p.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Process p in
            Process.GetProcesses(System.Environment.MachineName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    
                    listBox1.Items.Add(p.ToString());
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            foreach (Process p in Process.GetProcessesByName("steam"))
                listBox1.Items.Add(p.ToString());

        }
        
    }
}
