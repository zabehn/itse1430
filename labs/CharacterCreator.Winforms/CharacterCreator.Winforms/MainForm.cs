using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnEdit ( object sender, EventArgs e )
        {
            if(_character == null)
            {
                DisplayMessage("No character to edit", true,out var result) ;
                return;
            }

            var characterFormCreator = new CharacterForm(_character);

            if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                return;

            _character = characterFormCreator.Character;
            UpdateCharacter(false);
        }

        private void UpdateCharacter ( bool deletedCharacter )
        {
            if (deletedCharacter)
            {
                label10.Text = "No Character Created";

                label1.Text = "Name";
                label2.Text = "Race";
                label3.Text = "Profession";
                label4.Text = "Strength";
                label5.Text = "Intelligence";
                label6.Text = "Agility";
                label7.Text = "Constitution";
                label8.Text = "Charisma";
                label9.Text = "Description";
            }
            else
            {
                label10.Text = "Current Character Created";

                label1.Text = $"Name: {_character.Name}";
                label2.Text = $"Race: {_character.Race.Description}";
                label3.Text = $"Profession: {_character.Profession.Description}";
                label4.Text = $"Strength: {_character.Strength}";
                label5.Text = $"Intelligence: {_character.Intelligence}";
                label6.Text = $"Agility: {_character.Agility}";
                label7.Text = $"Constitution: {_character.Constitution}";
                label8.Text = $"Charisma: {_character.Charisma}";
                label9.Text = $"Description: {_character.Description}";
            }
        }

        private void OnDelete ( object sender, EventArgs e )
        {
            DialogResult result;
            if (_character == null)
            {
                DisplayMessage("No character to delete", true, out result);
                return;
            }

            DisplayMessage($"Are you sure you want to delete the Character, {_character.Name}?", false, out result);
            if (result == DialogResult.OK)
            {
                _character = null;
                UpdateCharacter(true);
            }
        }

        private void OnHelpAbout ( object sender, EventArgs e)
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnCharacterNew ( object sender, EventArgs e)
        {
            var characterFormCreator = new CharacterForm();

            if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                return;

            _character = characterFormCreator.Character;
            UpdateCharacter(false); 
        }

        private void DisplayMessage( string message, bool error, out DialogResult result )
        {
            if (error)
            {
                result = MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private Character _character;
    }
}
