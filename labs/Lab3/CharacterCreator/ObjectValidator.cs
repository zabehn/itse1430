/*
 * ITSE 1430
 * Lab 3
 * Object Validator
 * Spring 2020
 * Zachary Behn
 * 
 * This file is a container for a simple validation method
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate (object value)
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }
}
