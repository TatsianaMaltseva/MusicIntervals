using System;

namespace MusicIntervals
{
    class Interval
    {
        readonly string[] MusicIntervals = new string[] { " ", "m2", "M2", "m3", "M3", "P4", " ", "P5", "m6", "M6", "m7", "M7", "P8" };
        private string PossibleSemitones = "ABCDEFGABCDEFG";
        private string Dashes = "A--B-C--D--E-F--G--A--B-C--D--E-F--G";
        public int Semitone;
        public int Degree;
        public string Name;

        public Interval(string name)
        {
            Semitone = Array.IndexOf(MusicIntervals, name);
            Degree = name[1] - '0';
            Name = name;
        }

        public string IntervalIdentification(string firstNote, string lastNote, string direction = "asc")
        {
            if (direction != "asc")
            {
                Dashes = StringReverse(Dashes);
            }
            string dashes = Dashes[Dashes.IndexOf(firstNote[0]).. 
                (Dashes.IndexOf(lastNote[0], Dashes.IndexOf(firstNote[0])) + 1)];

            int semitone = 0;
            for (int i = 0; i < dashes.Length; i++)
            {
                if (dashes[i] == '-')
                {
                    semitone++;
                }
            }

            for (int i = 1; i < firstNote.Length; i++)
            {
                if (firstNote[i] == 'b')
                    semitone++;
                else if (firstNote[i] == '#')
                    semitone--;
            }
            //semitone = AddSemitones(firstNote, semitone, direction);
            //semitone = AddSemitones(lastNote, semitone, direction);

            for (int i = 1; i < lastNote.Length; i++)
            {
                if (lastNote[i] == 'b')
                    semitone--;
                else if (lastNote[i] == '#')
                    semitone++;
            }

            Console.WriteLine($"{semitone} semitones");
            return MusicIntervals[semitone];
        }

        //public int AddSemitones(string note, int semitone, string direction)
        //{
        //    for (int i = 1; i < note.Length; i++)
        //    {
        //        if (note[i] == 'b')
        //            semitone--;
        //        else if (note[i] == '#')
        //            semitone++;
        //    }

        //    return semitone;
        //}

        public string IntervalConstruction(string startNote, string direction)
        {
            if (direction != "asc")
            {
                Dashes = StringReverse(Dashes);
                PossibleSemitones = StringReverse(PossibleSemitones);
            }

            string startLetter = startNote[0..1];
            int startNumber = PossibleSemitones.IndexOf(startLetter);
            int endNumber = startNumber + Degree - 1;
            string endLetter = PossibleSemitones[endNumber..(endNumber + 1)];
            string dashes = Dashes[Dashes.IndexOf(startLetter)..(Dashes.IndexOf(endLetter, startNumber * 3) + 1)];

            int semitone = CountSemitones(dashes, startNote);

            endLetter = EditSemitones(semitone, endLetter, direction);
            return endLetter;
        }

        public string StringReverse(string toReverse)
        {
            char[] tempArray = toReverse.ToCharArray();
            Array.Reverse(tempArray);
            return new string(tempArray);
        }

        public int CountSemitones(string dashes, string startNote)
        {
            int semitone = 0;
            for (int i = 0; i < dashes.Length; i++)
            {
                if (dashes[i] == '-') semitone++;
            }

            if (startNote.Length != 1)
            {
                if (startNote[1] == '#') semitone -= startNote.Length - 1;
                else if (startNote[1] == 'b') semitone += startNote.Length - 1;
            }

            return semitone;
        }

        public string EditSemitones(int semitone, string endLetter, string direction)
        {
            int maxOperations = 0;
            while (semitone != Semitone && maxOperations != 2)
            {
                if (semitone > Semitone)
                {
                    if (direction == "asc")
                        endLetter += "b";
                    else
                        endLetter += "#";
                    semitone--;
                }
                if (semitone < Semitone)
                {

                    if (direction == "asc")
                        endLetter += "#";
                    else
                        endLetter += "b";
                    semitone++;
                }
                maxOperations++;
            }

            return endLetter;
        }
    }
}