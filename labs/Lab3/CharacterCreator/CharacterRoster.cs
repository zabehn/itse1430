using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterRoster : ICharacterRoster
    {
        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;

        public CharacterRoster()
        {
            
        }

        public Character Add ( Character character )
        {
            if (!ValidateCharacter(character, out var message))
            {
                //TODO: show message returned
                return null;
            }
            character.Id = _id++;
            _characters.Add(character);

            return CloneCharacter(character);
        }

        public void Delete ( int id )
        {
            //TODO: return error
            if (id>_id || id<0)
                return;

            _characters.Remove(FindById(id));
        }

        public Character[] GetAll ()
        {
            var items = new Character[_characters.Count];
            var Index = 0;
            foreach (var c in _characters)
            {
                items[Index++] = c;
            }
            return items;
        }

        public Character Get ( int id )
        {
            //TODO: return error
            if (id<1 || id>_id)
                return null;

            return CloneCharacter(FindById(id));
        }

        public void Update ( int id, Character character )
        {
            //TODO: return error;
            if (!ValidateCharacter(character, out var message) || id<0 || id>_characters.Capacity)
                return;

            var c = FindById(id);
            c = character;
        }

        private Character FindById(int id)
        {
            foreach (var c in _characters)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        private Character CloneCharacter( Character character)
        {
            return new Character() {
                Id = character.Id,
                Name = character.Name,
                Profession = character.Profession,
                Race = character.Race,
                Strength = character.Strength,
                Agility = character.Agility,
                Charisma = character.Charisma,
                Constitution = character.Constitution,
                Intelligence = character.Intelligence,
                Description = character.Description
            };
        }

        private bool ValidateCharacter(Character character, out string message)
        {
            if(character == null)
            {
                message = "null character";
                return false;
            }

            if (!character.Validate(out message))
                return false; 

            //TODO validate character and then make sure name isn't in list
            foreach (var c in _characters)
            {
                if (String.Compare(c?.Name, character.Name,true) == 0)
                {
                    message = "Name already exists";
                    return false;
                }
            }
            message = "";
            return true;
        }
    }
}
