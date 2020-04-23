/*
 * ITSE 1430
 * Lab 4
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

namespace Nile
{
    public static class ObjectValidator
    {
        /// <summary>Validates an object's values</summary>
        /// <param name="value">the object being validated</param>
        /// <returns>the erros that were found while validating</returns>
        public static IEnumerable<ValidationResult> Validate ( object value )
        {
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, new ValidationContext(value), errors, true);

            return errors;
        }
    }
}
