using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class Extensions
    {
        public static string ToHello(this string text)
        {
            string Hello = $"Hello {text}, good afternoon :)";
            return Hello;
        }
        public static string FormatText(this string text)
        {
            if (text.Contains("$"))
            {
                text.Replace("$", "");
            }
            return text.ToUpper().Trim();
        }
        public static bool IsTitle(this string text)
        {
            if (Regex.IsMatch(text, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string ToShortDate(this DateTime dateTime)
        {
            string date = dateTime.ToString("dd/MM/yyyy");
            return date;
        }
        /// <summary>
        /// Agregar un caracter "*" al inicio y al final del texto
        /// </summary>
        /// <param name="text">Cadena de texto</param>
        /// <returns>Nueva cadena de texto con el caracter "*" 
        /// insertado al inicio y al final</returns>
        public static string ToAddCharacter(this string text)
        {
            return $"*{text}*";
        }
    }
}
