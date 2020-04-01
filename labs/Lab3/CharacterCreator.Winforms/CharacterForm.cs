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

        public CharacterForm( Character character) : this(character,character != null)
        {

        }

        public CharacterForm( Character character, bool edit) : this()
        {
            Character = character;
            Text = edit? "Edit Character":"Create New Character";
        }

        private void OnCancel (object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnOk (object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var character = getCharacter();
            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
            {
                DisplayError("Error");
                return;
            }

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Character getCharacter ()
        {
            var character = new Character();

            character.Name = textName.Text?.Trim();
            character.Strength = (int) numberStrength.Value;
            character.Intelligence = (int) numberIntelligence.Value;
            character.Agility = (int) numberAgility.Value;
            character.Constitution = (int) numberConstitution.Value;
            character.Charisma = (int) numberCharisma.Value;
            character.Description = richTextDescription.Text.Trim();

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

            if(Character != null)
            {
                textName.Text = Character.Name;
                richTextDescription.Text = Character.Description;
                numberAgility.Value = Character.Agility;
                numberCharisma.Value = Character.Charisma;
                numberConstitution.Value = Character.Constitution;
                numberIntelligence.Value = Character.Intelligence;
                numberStrength.Value = Character.Strength;

                if(Character.Profession != null)
                    ProfessionComboBox.SelectedText = Character.Profession.Description;
                if(Character.Race != null)
                    RaceComboBox.SelectedText = Character.Race.Description;

                ValidateChildren();
            }
        }

        private void textName_Validating ( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is Required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
