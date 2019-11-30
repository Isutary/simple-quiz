using System.Collections.Generic;

namespace FormsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question> { 
                new Question("Who was the first person to set foot on moon?", new List<string> { "Neil Armstrong", "Yuri Gagarin", "Buzz Aldrin", "Michael Collins" }, 0),
                new Question("When was the first Nobel prize awarded?", new List<string> { "1895", "1900", "1901", "1905" }, 2),
                new Question("Point when earth is closest to Sun is called:", new List<string> { "Aphelion", "Perihelion", "Perigee", "Solstices" }, 1),
                new Question("When did World War 2 start?", new List<string> { "1937", "1938", "1939", "1940" }, 2),
                new Question("Which ABBA song won Eurovision?", new List<string> { "Mamma Mia", "One of us", "Gimme! Gimme! Gimme!", "Waterloo" }, 3),
                new Question("Which English football club ended a season 2004/2005 without a lose?", new List<string> { "Arsenal", "Manchester United", "Liverpool", "Chelsea" }, 0),
                new Question("What city is considered the city of lights?", new List<string> { "Beijing", "Paris", "New York", "London" }, 1),
            };
            Quiz q1 = new Quiz(questions, 5);
            q1.Start();
        }
    }
}
