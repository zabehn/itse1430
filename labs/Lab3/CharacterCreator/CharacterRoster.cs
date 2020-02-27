using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    class CharacterRoster : ICharacterRoster
    {
        Character[] _characters;

        public CharacterRoster()
        {
            _characters = new Character[100];
        }

        public Character AddCharacter ( Character character )
        {
            if (!ValidateCharacter(character.Name, out var message))
            {
                //TODO: show message returned and break method
                return null;
            }

            for (var i = 0; i<_characters.Length; i++)
            {
                if (_characters[i]==null)
                {
                    character.Id = i+1;
                    _characters[i] = character;
                    break;
                }
            }

            return CreateTempCharacter(character);
        }

        public void DeleteCharacter ( int id )
        {
            throw new NotImplementedException();
        }

        public Character[] GetAllCharacters ()
        {
            throw new NotImplementedException();
        }

        public Character GetCharacter ( int id )
        {
            throw new NotImplementedException();
        }

        public void UpdateCharacter ( int id )
        {
            throw new NotImplementedException();
        }

        private Character CreateTempCharacter( Character character)
        {
            throw new NotImplementedException();
        }

        private bool ValidateCharacter(string name, out string message)
        {
            //TODO validate character and then make sure name isn't in list
            throw new NotImplementedException();
        }
    }
}
