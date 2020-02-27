using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    interface ICharacterRoster
    {

        Character AddCharacter (Character character);

        void DeleteCharacter (int id);

        Character GetCharacter ( int id );

        Character[] GetAllCharacters ();

        void UpdateCharacter (int id);
    }
}
