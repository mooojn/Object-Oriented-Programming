using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkoutRoutine MyRoutine = new WorkoutRoutine("Wings");
            Exercise LatPulls = new Exercise("Lat Pull Down");
            Exercise PushUp = new Exercise("Push Ups");
            Exercise BentOverRow = new Exercise("Bent Over Row");
            
            Set Set1 = new Set(100, 13);
            Set Set2 = new Set(135, 5);
            Set Set3 = new Set(125, 1);
            
            LatPulls.AddSet(Set1);
            PushUp.AddSet(Set2);
            BentOverRow.AddSet(Set3);
            
            MyRoutine.AddExercise(LatPulls);
            MyRoutine.AddExercise(PushUp);
            MyRoutine.AddExercise(BentOverRow);
            
            Console.WriteLine($"My Routine: {MyRoutine.GetName()}");
            foreach (Exercise exercise in MyRoutine.GetExercises())
            {
                Console.WriteLine("Exercise: " + exercise.GetName());
                foreach (Set S in exercise.GetSets())
                {
                    Console.WriteLine("Weight: " + S.GetWeight() + " Repititons: " + S.GetRepetitions());
                }
            }
            Console.ReadKey();


        }
    }
}
