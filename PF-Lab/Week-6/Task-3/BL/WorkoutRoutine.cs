using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class WorkoutRoutine
    {
        private string Name;
        private List<Exercise> Exercises = new List<Exercise>();

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public List<Exercise> GetExercises()
        {
            return Exercises;
        }

        public void AddExercise(Exercise exercise)
        {
            Exercises.Add(exercise);
        }

        public WorkoutRoutine(string name)
        {
            SetName(name);
        }
    }
}
