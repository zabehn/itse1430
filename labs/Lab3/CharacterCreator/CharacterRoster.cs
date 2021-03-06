﻿/*
 * ITSE 1430
 * Lab 3
 * Character Roster
 * Spring 2020
 * Zachary Behn
 * 
 * This file is the abstract class implementation of the interface ICharacterRoster
 */

using System.Collections.Generic;
using System.Linq;

namespace CharacterCreator
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            if (character == null)
                return null;

            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return null;

            if (FindByName(character.Name) != null)
                return null;

            return AddCore(character);
        }

        protected abstract Character FindByName ( string name );
        protected abstract Character AddCore ( Character character );

        public void Delete ( int id )
        {
            if (id<1)
                return;

            DeleteCore( id );
        }

        protected abstract Character FindById ( int id );
        protected abstract void DeleteCore ( int id );

        public Character Get ( int id )
        {
            //TODO: return error
            if (id<1)
                return null;

            return GetCore(id);
        }

        protected abstract Character GetCore ( int id );

        public string Update ( int id, Character character )
        {
            if (character == null)
                return "Character == null";

            var errors = ObjectValidator.Validate(character);
            if (errors.Any())
                return "Error";

            if (id<1)
                return "Id is invalid";

            if (FindById(id) == null)
                return "Character doesn't exist";

            var testName = FindByName(character.Name);
            if (testName != null && testName.Id != character.Id)
                return "Character must have unique name";

            UpdateCore(id, character);

            return null;
        }

        public IEnumerable<Character> GetAll () => GetAllCore() ?? Enumerable.Empty<Character>();
        protected abstract IEnumerable<Character> GetAllCore ();
        protected abstract void UpdateCore ( int id, Character character );
    }
}
