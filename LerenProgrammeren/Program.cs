using System;
using System.Linq;

namespace MijnProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var language = Language.English;
            if (args.Any(a=>"nl".Equals(a, StringComparison.OrdinalIgnoreCase))) {
                language = Language.Dutch;
            }


            var mensen = new[] { 
                new Person("Danu") {
                    Age = 12,
                    FavoriteFood = "Pasta",
                    Gender = Gender.Male
                }, 
                new Person("Rob") {
                    Age = 43,
                    FavoriteFood = "Shoarma",
                    Gender = Gender.Male
                }, 
                new Person("Luca") {
                    Age = 14,
                    FavoriteFood = "Pasta",
                    Gender = Gender.Male
                }, 
                new Person("Ilse") {
                    Age = 41,
                    FavoriteFood = "Wraps",
                    Gender = Gender.Female
                }   
            };
            foreach (var m in mensen.OrderBy(p => p.Age)) {
                //Console.WriteLine(m.Name + " is " + m.Age + " en " + m.Gender + " en houdt van " + m.FavoriteFood);

                string display;
                switch (language) {
                    case Language.Dutch: display = "{0} is {1} jaar en {2} en houdt van {3}"; break;
                    default: display = "{0} is {1} years and {2} and loves {3}"; break;
                }

                Console.WriteLine(display, m.Name, m.Age, TranslateGender(language, m.Gender), m.FavoriteFood);
            }
        }

        public static string TranslateGender(Language language, Gender gender) {
            switch (language) {
                case Language.Dutch:
                    switch (gender) {
                        case Gender.Male: return "Man";
                        case Gender.Female: return "Vrouw";
                        case Gender.Other: return "Overig";
                        default: return "Onbekend";
                    }
                default:
                    switch (gender) {
                        case Gender.Male: return "Male";
                        case Gender.Female: return "Female";
                        case Gender.Other: return "Other";
                        default: return "Unknown";
                    }
            }
        } 
    }  

    public enum Language {
        Dutch,
        English
    }

    public enum Gender {
        Male,
        Female,
        Other
    }

    public class Person
    {   
        public string Name { get; private set; }
        public int Age { get; set; }
        public string FavoriteFood { get; set; }
        public Gender Gender { get; set; }

        public Person(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            
            Name = name;
            
        }
    }
}
