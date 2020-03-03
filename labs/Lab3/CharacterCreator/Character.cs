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

        public int Id { get; set; }

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

            if(Race == null)
            {
                error = "Race is required";
                return false;
            }

            if (Profession == null)
            {
                error = "Profession is required";
                return false;
            }

            error = null;
            return true;
        }
    }
}
