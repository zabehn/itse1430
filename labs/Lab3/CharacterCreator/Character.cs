/*
 * ITSE 1430
 * Lab 3
 * Character
 * Spring 2020
 * Zachary Behn
 * 
 * This file contains the Character type and implements validation
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CharacterCreator
{
    public class Character : IValidatableObject
    {
        public override string ToString ()
        {
            return Name;
        }

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

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if(String.IsNullOrEmpty(_name))
            {
                yield return new ValidationResult("Name is required.", new[] { nameof(Name) });
            };

            if(Race == null)
            {
                yield return new ValidationResult("Race is required.", new[] { nameof(Race) });
            };

            if (Profession == null)
            {
                yield return new ValidationResult("Profession is required.", new[] { nameof(Profession) });
            };

            if(Strength<1 || Strength > 100)
            {
                yield return new ValidationResult("Strength must be between 1 and 100.", new[] { nameof(Strength) });
            };

            if (Agility<1 || Agility > 100)
            {
                yield return new ValidationResult("Agility must be between 1 and 100.", new[] { nameof(Agility) });
            };

            if (Intelligence<1 || Intelligence > 100)
            {
                yield return new ValidationResult("Intelligence must be between 1 and 100.", new[] { nameof(Intelligence) });
            };

            if (Charisma<1 || Charisma > 100)
            {
                yield return new ValidationResult("Charisma must be between 1 and 100.", new[] { nameof(Charisma) });
            };

            if (Constitution<1 || Constitution > 100)
            {
                yield return new ValidationResult("Constitution must be between 1 and 100.", new[] { nameof(Constitution) });
            };
        }
    }
}
