/*
 * ITSE 1430
 * Lab 3
 * MemoryCharacterRoster
 * Spring 2020
 * Zachary Behn
 * 
 * This file is a memory implementation of CharacterRoster used in the winforms application
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Memory
{
    public class MemoryCharacterRoster : CharacterRoster
    {
        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;

        protected override Character AddCore ( Character character )
        {
            character.Id = _id++;
            _characters.Add(character);

            return CloneCharacter(character);
        }

        private Character CloneCharacter ( Character character )
        {
            var c = new Character();
            CopyCharacter(c, character, true);

            return c;
        }

        protected override Character FindByName ( string name )
        {
            foreach( var c in _characters)
            {
                if (String.Compare(c?.Name, name, true) == 0)
                    return c;
            };

            return null;
        }

        protected override Character FindById ( int id )
        {
            foreach (var c in _characters)
            {
                if (id == c?.Id)
                    return c;
            };

            return null;
        }

        protected override void DeleteCore ( int id )
        {
            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);
        }

        protected override Character GetCore ( int id )
        {
            var character = FindById(id);
            if (character ==null)
                return null;

            return CloneCharacter(character);
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            foreach (var c in _characters)
            {
                yield return CloneCharacter(c);
            };
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var current = FindById(id);

            CopyCharacter(current, character, false);
        }

        private void CopyCharacter ( Character current, Character copyFrom, bool IdToo )
        {
            if (IdToo)
                current.Id = copyFrom.Id;
            current.Name = copyFrom.Name;
            current.Strength = copyFrom.Strength;
            current.Agility = copyFrom.Agility;
            current.Charisma = copyFrom.Charisma;
            current.Intelligence = copyFrom.Intelligence;
            current.Constitution = copyFrom.Constitution;
            if (copyFrom.Race != null)
                current.Race = new Race(copyFrom.Race.Description);
            else
                current.Race = null;
            if (copyFrom.Profession != null)
                current.Profession = new Profession(copyFrom.Profession.Description);
            else
                current.Profession = null;

        }
    }
}
