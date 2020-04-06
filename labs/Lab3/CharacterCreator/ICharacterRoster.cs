/*
 * ITSE 1430
 * Lab 3
 * ICharacterRoster
 * Spring 2020
 * Zachary Behn
 * 
 * This is the interface implemented by CharacterRoster
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public interface ICharacterRoster
    {

        Character Add (Character character);

        void Delete (int id);

        Character Get ( int id );

        IEnumerable<Character> GetAll ();

        string Update (int id, Character character);
    }
}
