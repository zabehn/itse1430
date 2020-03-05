﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    interface ICharacterRoster
    {

        Character Add (Character character);

        void Delete (int id);

        Character Get ( int id );

        Character[] GetAll ();

        string Update (int id, Character character);
    }
}
