namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnAnalisisLexico = new System.Windows.Forms.Button();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.numberedRTB1 = new GUI.NumberedRTB();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(716, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(468, 508);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // btnAnalisisLexico
            // 
            this.btnAnalisisLexico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalisisLexico.Location = new System.Drawing.Point(635, 10);
            this.btnAnalisisLexico.Name = "btnAnalisisLexico";
            this.btnAnalisisLexico.Size = new System.Drawing.Size(75, 23);
            this.btnAnalisisLexico.TabIndex = 2;
            this.btnAnalisisLexico.Text = "Lexico";
            this.btnAnalisisLexico.UseVisualStyleBackColor = true;
            this.btnAnalisisLexico.Click += new System.EventHandler(this.txtAnalisisLexico_Click);
            // 
            // btnSintactico
            // 
            this.btnSintactico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSintactico.Location = new System.Drawing.Point(635, 39);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(75, 23);
            this.btnSintactico.TabIndex = 3;
            this.btnSintactico.Text = "Sintactico";
            this.btnSintactico.UseVisualStyleBackColor = true;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
            // 
            // numberedRTB1
            // 
            this.numberedRTB1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberedRTB1.BackColor = System.Drawing.SystemColors.Window;
            this.numberedRTB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberedRTB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F);
            this.numberedRTB1.Lines = new string[] {
        "/*",
        " * To change this license header, choose License Headers in Project Properties.",
        " * To change this template file, choose Tools | Templates",
        " * and open the template in the editor.",
        " */",
        "",
        "class Test {",
        "",
        "    public static void main(String[] args) {",
        "        String aasd = \"234\";",
        "        double af = 3;",
        "            int a = 19;",
        "            float b = 0.5;",
        "            for (int i = 0; i < a; i++)",
        "            {",
        "                int c;",
        "                while (b < a)",
        "                {",
        "                    for (int h = 0; h < 12; h++)",
        "                    {",
        "                        {",
        "                            int x;",
        "                        }",
        "                        while (i < h)",
        "                        {",
        "                            {",
        "                                int x = 2;",
        "                            }",
        "                            int x = h * b;",
        "                            i++;",
        "                        }",
        "                        do",
        "                        {",
        "                            c = 2;",
        "                        } while (c != 2);",
        "                    }",
        "                }",
        "                int x = 12 * i / (b + a / 4) - 12 / b;",
        "                float y = x * 12.5 + 2;",
        "                c++;",
        "                b = 0;",
        "            }",
        "            for (int i = 0; i < 10; i++)",
        "            {",
        "            }",
        "            if (a < b)",
        "            {",
        "                b = a;",
        "            }",
        "            else",
        "            {",
        "                a = a + b;",
        "                a++;",
        "            }",
        "            b = a * b;",
        "",
        "        }",
        "    }"};
            this.numberedRTB1.Location = new System.Drawing.Point(11, 10);
            this.numberedRTB1.Margin = new System.Windows.Forms.Padding(2);
            this.numberedRTB1.Name = "numberedRTB1";
            this.numberedRTB1.Size = new System.Drawing.Size(619, 510);
            this.numberedRTB1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 532);
            this.Controls.Add(this.numberedRTB1);
            this.Controls.Add(this.btnSintactico);
            this.Controls.Add(this.btnAnalisisLexico);
            this.Controls.Add(this.richTextBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnAnalisisLexico;
        private System.Windows.Forms.Button btnSintactico;
        private NumberedRTB numberedRTB1;
    }
}

