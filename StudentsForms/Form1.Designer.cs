namespace StudentsForms
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
            this.components = new System.ComponentModel.Container();
            this.HelloButton = new System.Windows.Forms.Button();
            this.InformationTimer = new System.Windows.Forms.Timer(this.components);
            this.InformationLabel = new System.Windows.Forms.Label();
            this.TimerControlCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // HelloButton
            // 
            this.HelloButton.BackColor = System.Drawing.Color.Blue;
            this.HelloButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HelloButton.ForeColor = System.Drawing.Color.White;
            this.HelloButton.Location = new System.Drawing.Point(321, 146);
            this.HelloButton.Name = "HelloButton";
            this.HelloButton.Size = new System.Drawing.Size(178, 76);
            this.HelloButton.TabIndex = 0;
            this.HelloButton.Text = "Hello!!!";
            this.HelloButton.UseVisualStyleBackColor = false;
            this.HelloButton.Click += new System.EventHandler(this.HelloButton_Click);
            this.HelloButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HelloButton_OnMouseMove);
            // 
            // InformationTimer
            // 
            this.InformationTimer.Tick += new System.EventHandler(this.InformationTimer_Tick);
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Location = new System.Drawing.Point(252, 85);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(38, 15);
            this.InformationLabel.TabIndex = 1;
            this.InformationLabel.Text = "label1";
            // 
            // TimerControlCheckBox
            // 
            this.TimerControlCheckBox.AutoSize = true;
            this.TimerControlCheckBox.Location = new System.Drawing.Point(95, 146);
            this.TimerControlCheckBox.Name = "TimerControlCheckBox";
            this.TimerControlCheckBox.Size = new System.Drawing.Size(124, 19);
            this.TimerControlCheckBox.TabIndex = 2;
            this.TimerControlCheckBox.Text = "Включить таймер";
            this.TimerControlCheckBox.UseVisualStyleBackColor = true;
            this.TimerControlCheckBox.CheckedChanged += new System.EventHandler(this.TimerControlCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimerControlCheckBox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.HelloButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HelloButton;
        private System.Windows.Forms.Timer InformationTimer;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.CheckBox TimerControlCheckBox;
    }
}

