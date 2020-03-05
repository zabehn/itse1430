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
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var characterFormCreator = new CharacterForm(character);

            if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                return;

            _characters.Update(character.Id,characterFormCreator.Character as Character);
            UpdateCharacterList();
        }

        private Character GetSelectedCharacter ()
        {
            return characterList.SelectedItem as Character;
        }

        private void OnDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            DisplayMessage($"Are you sure you want to delete the Character, {character.Name}?", false, out var result);
            if (result == DialogResult.OK)
            {
                _characters.Delete(character.Id);
            }
            UpdateCharacterList();
        }

        private void UpdateCharacterList()
        {
            characterList.Items.Clear();
            var all = _characters.GetAll();

            foreach (var c in all)
            {
                characterList.Items.Add(c);
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

            _characters.Add(characterFormCreator.Character as Character);
            UpdateCharacterList();
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
