using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Character
    {
        public string Name
        {
            get 
            {
                return _name ?? "";
            }
            set { _name = value?.Trim(); }
        }
        private string _name;
        
        public string Description
        {
            get {
                return _description ?? "";
            }
            set { _description = value?.Trim(); }
        }
        private string _description;

        public int Strength { get; set; } = 50;

        public int Intelligence { get; set; } = 50;

        public int Agility { get; set; } = 50;

        public int Constitution { get; set; } = 50;

        public int Charisma { get; set; } = 50;

        public Race Race { get; set; }

        public Profession Profession { get; set; }

        public bool Validate ( out string error )
        {
            if(String.IsNullOrEmpty(_name))
            {
                error = "Name is required";
                return false;
            }

            if(Strength>100 || Strength < 1)
            {
                error = "Strength must be between 1 and 100";
                return false;
            }

            if (Intelligence>100 || Intelligence < 1)
            {
                error = "Intelligence must be between 1 and 100";
                return false;
            }

            if (Agility>100 || Agility < 1)
            {
                error = "Agility must be between 1 and 100";
                return false;
            }

            if (Constitution>100 || Constitution < 1)
            {
                error = "Constitution must be between 1 and 100";
                return false;
            }

            if (Charisma>100 || Charisma < 1)
            {
                error = "Charisma must be between 1 and 100";
                return false;
            }

            error = null;
            return true;
        }
    }
}
