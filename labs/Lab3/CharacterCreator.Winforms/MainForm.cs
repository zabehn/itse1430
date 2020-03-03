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
            _characters = new CharacterRoster();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateCharacterList();
        }

        private void OnEdit ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter(out var Id);
            if (character == null)
                return;

            var characterFormCreator = new CharacterForm(character);

            if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                return;

            _characters.Update(Id,characterFormCreator.Character);
        }

        private Character GetSelectedCharacter (out int Id)
        {
            Id = characterList.SelectedIndex++;
            return characterList.SelectedItem;
        }

        private void OnDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter(out var Id);
            if (character == null)
                return;

            DisplayMessage($"Are you sure you want to delete the Character, {character.Name}?", false, out var result);
            if (result == DialogResult.OK)
            {
                _characters.Delete(character.Id);
            }
        }

        private void UpdateCharacterList()
        {
            characterList.Items.Clear();
            var c = _characters.GetAll();

            foreach (var character in c)
            {
                characterList.Items.Add(character);
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

        private CharacterRoster _characters;
    }
}
