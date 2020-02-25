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
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        private void OnCancel (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOk (object sender, EventArgs e)
        {
            var character = getCharacter();
            if(!character.Validate(out var message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private Character getCharacter ()
        {
            var character = new Character();

            character.Name = textName.Text?.Trim();
            character.Strength = (int)numberStrength.Value;
            character.Intelligence = (int) numberIntelligence.Value;
            character.Agility = (int) numberAgility.Value;
            character.Constitution = (int) numberConstitution.Value;
            character.Charisma = (int) numberCharisma.Value;
            character.Description = textDescription.Text.Trim();

            if (ProfessionComboBox.SelectedItem is Profession profession)
                character.Profession = profession;
            if (RaceComboBox.SelectedItem is Race race)
                character.Race = race;

            return character;
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            var races = Races.GetAllRaces();
            var professions = Professions.GetAllProfessions();
            RaceComboBox.Items.AddRange(races);
            ProfessionComboBox.Items.AddRange(professions);
        }
    }
}
