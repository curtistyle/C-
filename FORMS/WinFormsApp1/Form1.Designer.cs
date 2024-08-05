namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxX = new TextBox();
            textBoxY = new TextBox();
            radioButtonSuma = new RadioButton();
            radioButtonResta = new RadioButton();
            buttonResultado = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Variable X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Variable Y:";
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(79, 17);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(100, 23);
            textBoxX.TabIndex = 2;
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(79, 63);
            textBoxY.Name = "textBoxY";
            textBoxY.Size = new Size(100, 23);
            textBoxY.TabIndex = 3;
            // 
            // radioButtonSuma
            // 
            radioButtonSuma.AutoSize = true;
            radioButtonSuma.Location = new Point(278, 20);
            radioButtonSuma.Name = "radioButtonSuma";
            radioButtonSuma.Size = new Size(55, 19);
            radioButtonSuma.TabIndex = 4;
            radioButtonSuma.TabStop = true;
            radioButtonSuma.Text = "Suma";
            radioButtonSuma.UseVisualStyleBackColor = true;
            // 
            // radioButtonResta
            // 
            radioButtonResta.AutoSize = true;
            radioButtonResta.Location = new Point(278, 62);
            radioButtonResta.Name = "radioButtonResta";
            radioButtonResta.Size = new Size(53, 19);
            radioButtonResta.TabIndex = 5;
            radioButtonResta.TabStop = true;
            radioButtonResta.Text = "Resta";
            radioButtonResta.UseVisualStyleBackColor = true;
            // 
            // buttonResultado
            // 
            buttonResultado.Location = new Point(297, 126);
            buttonResultado.Name = "buttonResultado";
            buttonResultado.Size = new Size(75, 23);
            buttonResultado.TabIndex = 6;
            buttonResultado.Text = "Resultado";
            buttonResultado.UseVisualStyleBackColor = true;
            buttonResultado.Click += buttonResultado_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(buttonResultado);
            Controls.Add(radioButtonResta);
            Controls.Add(radioButtonSuma);
            Controls.Add(textBoxY);
            Controls.Add(textBoxX);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Calculadora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private RadioButton radioButtonSuma;
        private RadioButton radioButtonResta;
        private Button buttonResultado;
    }
}
