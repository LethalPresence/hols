﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace hols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        string[] Arr1 = new string[] { "string", "real", "integer", "for", "boolean", ":=", "var", "begin", "end", "foreach", "while", "repeat", "if", "case", };
        string[] Arr2 = new string[] { "@" , "not", "^" , "*" , "/" , "div", "mod", "and", "shl", "shr", "+" , "-" , "or", "xor", "=" , ">" , "<" , "<>" , "<=" , ">=" , "as" , "is" , "in" };
        char[] Arr3 = new char[] { ';'};
        int oper = 0;
        int operand = 0;

        private void button2_Click(object sender, EventArgs e)
        { 
            if (textBox1.Text.Length == 0)
                MessageBox.Show("Ничего не введено!");
            else
            {
                oper = 0;
                operand = 0;
                string[] tex = textBox1.Text.Split(Arr3);
                for (int i = 0; i < Arr1.Length; i++)
                    foreach (string A in tex)
                        if (A.Contains(Arr1[i]))
                        {
                            oper++;
                        }
                for (int i = 0; i < Arr2.Length; i++)
                    foreach (string B in tex)
                        if (B.Contains(Arr2[i]))
                        {
                            operand++;
                        }
                Huynya();
            }
        }
        private void Huynya()
        {
            textBox2.Text = Convert.ToString(oper);
            textBox3.Text = Convert.ToString(operand);
        }
    }
}
