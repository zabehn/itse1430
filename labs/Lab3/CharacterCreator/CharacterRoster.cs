using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class CharacterRoster : ICharacterRoster
    {
        private readonly List<Character> _characters;
        private int _id = 1;

        public CharacterRoster()
        {
            _characters = new List<Character>();
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

        public string Update ( int id, Character character )
        {
            //TODO: return error;
            if (!ValidateCharacter(character, out var message))
                return message;

            var c = FindById(id);
            CopyCharacter(c, character, false);
            return "";
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

        private void CopyCharacter(Character target, Character source, bool copyId)
        {
            if(copyId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Profession = new Profession(source.Profession.Description.Trim());
            target.Race = new Race(source.Race.Description.Trim());
            target.Strength = source.Strength;
            target.Agility = source.Agility;
            target.Charisma = source.Charisma;
            target.Constitution = source.Constitution;
            target.Intelligence = source.Intelligence;
            target.Description = source.Description;
        }

        private Character CloneCharacter( Character character)
        {
            var temp = new Character();
            CopyCharacter(temp, character, true);
            return temp;
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
