namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.CancelCharacter = new System.Windows.Forms.Button();
            this.ConfirmCharacter = new System.Windows.Forms.Button();
            this.RaceComboBox = new System.Windows.Forms.ComboBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.ProfessionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numberStrength = new System.Windows.Forms.NumericUpDown();
            this.numberIntelligence = new System.Windows.Forms.NumericUpDown();
            this.numberAgility = new System.Windows.Forms.NumericUpDown();
            this.numberConstitution = new System.Windows.Forms.NumericUpDown();
            this.numberCharisma = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberConstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCharisma)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelCharacter
            // 
            this.CancelCharacter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCharacter.Location = new System.Drawing.Point(228, 366);
            this.CancelCharacter.Name = "CancelCharacter";
            this.CancelCharacter.Size = new System.Drawing.Size(75, 23);
            this.CancelCharacter.TabIndex = 20;
            this.CancelCharacter.Text = "Cancel";
            this.CancelCharacter.UseVisualStyleBackColor = true;
            this.CancelCharacter.Click += new System.EventHandler(this.OnCancel);
            // 
            // ConfirmCharacter
            // 
            this.ConfirmCharacter.Location = new System.Drawing.Point(147, 366);
            this.ConfirmCharacter.Name = "ConfirmCharacter";
            this.ConfirmCharacter.Size = new System.Drawing.Size(75, 23);
            this.ConfirmCharacter.TabIndex = 19;
            this.ConfirmCharacter.Text = "Save";
            this.ConfirmCharacter.UseVisualStyleBackColor = true;
            this.ConfirmCharacter.Click += new System.EventHandler(this.OnOk);
            // 
            // RaceComboBox
            // 
            this.RaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RaceComboBox.FormattingEnabled = true;
            this.RaceComboBox.Location = new System.Drawing.Point(12, 64);
            this.RaceComboBox.Name = "RaceComboBox";
            this.RaceComboBox.Size = new System.Drawing.Size(121, 21);
            this.RaceComboBox.TabIndex = 4;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(12, 25);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(121, 20);
            this.textName.TabIndex = 2;
            // 
            // ProfessionComboBox
            // 
            this.ProfessionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfessionComboBox.FormattingEnabled = true;
            this.ProfessionComboBox.Location = new System.Drawing.Point(12, 104);
            this.ProfessionComboBox.Name = "ProfessionComboBox";
            this.ProfessionComboBox.Size = new System.Drawing.Size(121, 21);
            this.ProfessionComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Profession";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Race";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // numberStrength
            // 
            this.numberStrength.Location = new System.Drawing.Point(12, 144);
            this.numberStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberStrength.Name = "numberStrength";
            this.numberStrength.Size = new System.Drawing.Size(120, 20);
            this.numberStrength.TabIndex = 8;
            this.numberStrength.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numberIntelligence
            // 
            this.numberIntelligence.Location = new System.Drawing.Point(12, 183);
            this.numberIntelligence.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberIntelligence.Name = "numberIntelligence";
            this.numberIntelligence.Size = new System.Drawing.Size(120, 20);
            this.numberIntelligence.TabIndex = 10;
            this.numberIntelligence.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numberAgility
            // 
            this.numberAgility.Location = new System.Drawing.Point(12, 222);
            this.numberAgility.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberAgility.Name = "numberAgility";
            this.numberAgility.Size = new System.Drawing.Size(120, 20);
            this.numberAgility.TabIndex = 12;
            this.numberAgility.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numberConstitution
            // 
            this.numberConstitution.Location = new System.Drawing.Point(12, 261);
            this.numberConstitution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberConstitution.Name = "numberConstitution";
            this.numberConstitution.Size = new System.Drawing.Size(120, 20);
            this.numberConstitution.TabIndex = 14;
            this.numberConstitution.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numberCharisma
            // 
            this.numberCharisma.Location = new System.Drawing.Point(12, 300);
            this.numberCharisma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberCharisma.Name = "numberCharisma";
            this.numberCharisma.Size = new System.Drawing.Size(120, 20);
            this.numberCharisma.TabIndex = 16;
            this.numberCharisma.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Charisma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Agility";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Constitution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Intelligence";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Strength";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Description";
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(12, 340);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(121, 20);
            this.textDescription.TabIndex = 18;
            // 
            // CharacterForm
            // 
            this.AcceptButton = this.ConfirmCharacter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCharacter;
            this.ClientSize = new System.Drawing.Size(315, 401);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numberCharisma);
            this.Controls.Add(this.numberConstitution);
            this.Controls.Add(this.numberAgility);
            this.Controls.Add(this.numberIntelligence);
            this.Controls.Add(this.numberStrength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfessionComboBox);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.RaceComboBox);
            this.Controls.Add(this.ConfirmCharacter);
            this.Controls.Add(this.CancelCharacter);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(331, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(331, 440);
            this.Name = "CharacterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this.numberStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberConstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberCharisma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelCharacter;
        private System.Windows.Forms.Button ConfirmCharacter;
        private System.Windows.Forms.ComboBox RaceComboBox;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.ComboBox ProfessionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numberStrength;
        private System.Windows.Forms.NumericUpDown numberIntelligence;
        private System.Windows.Forms.NumericUpDown numberAgility;
        private System.Windows.Forms.NumericUpDown numberConstitution;
        private System.Windows.Forms.NumericUpDown numberCharisma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDescription;
    }
}