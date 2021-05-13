using JavaCompiler.AnalisisLexico;
using JavaCompiler.AnalisisSintactico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox2.Font = new Font(FontFamily.GenericMonospace, richTextBox2.Font.Size);
            numberedRTB1.Font = new Font(FontFamily.GenericMonospace, 9f);
            
        }

        private void txtAnalisisLexico_Click(object sender, EventArgs e)
        {
            string text = numberedRTB1.Text;
            Lexer lexer = new Lexer(text);
            richTextBox2.Text = string.Empty;
            StringBuilder textB = new StringBuilder();
            foreach (var token in lexer.TokensFilteredInfo)
            {
                textB.Append(token + "\n");
                //richTextBox2.Text += token + "\n";
            }
            richTextBox2.Text = textB.ToString();
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            string text = numberedRTB1.Text;
           
            richTextBox2.Text = string.Empty;
            try
            {
                Lexer lexer = new Lexer(text);
                Parser p = new Parser(lexer);
                p.parseProgram();
                richTextBox2.Text = "Programa analizado correctamente";
            } catch(Exception ex)
            {
                richTextBox2.Text = ex.Message;
            }
            
        }
    }
}
