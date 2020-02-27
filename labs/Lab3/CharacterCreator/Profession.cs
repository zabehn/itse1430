﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public class Profession
    {
        public Profession ( string description )
        {
            Description = description ?? "";
        }

        public string Description { get; }

        public override string ToString ()
        {
            return Description;
        }
    }

    public class Professions
    {
        public static Profession[] GetAllProfessions()
        {
            var items = new Profession[5];
            items[0] = new Profession("Fighter");
            items[1] = new Profession("Hunter");
            items[2] = new Profession("Priest");
            items[3] = new Profession("Rogue");
            items[4] = new Profession("Wizard");
            return items;
        }
    }
}
