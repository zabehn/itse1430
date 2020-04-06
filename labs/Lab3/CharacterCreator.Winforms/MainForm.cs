/*
 * ITSE 1430
 * Lab 3
 * MainForm
 * Spring 2020
 * Zachary Behn
 * 
 * This contains the code for the main form that pops up on startup
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.Memory;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            _characters = new MemoryCharacterRoster();
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
            characterFormCreator.Character = character;
            do
            {
                if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Update(character.Id, characterFormCreator.Character);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateCharacterList();
                    return;
                }

                DisplayMessage(error, true, out _);
            } while (true);
        }

        private Character GetSelectedCharacter ()
        {
            return characterList.SelectedItems.OfType<Character>().FirstOrDefault();
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

            characterList.Items.AddRange(all.ToArray());
        }

        private void OnHelpAbout ( object sender, EventArgs e)
        {
            var about = new AboutBox();

            about.ShowDialog(this);
        }

        private void OnCharacterNew ( object sender, EventArgs e)
        {
            do
            {
                var characterFormCreator = new CharacterForm();


                if (characterFormCreator.ShowDialog(this) != DialogResult.OK)
                    return;

                var c = _characters.Add(characterFormCreator.Character);
                if (c != null)
                {
                    UpdateCharacterList();
                    return;
                }

                DisplayMessage("Add failed", true, out _);
            } while (true);
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

        private readonly ICharacterRoster _characters;
    }
}
