using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume();
        resume._name = "Alex Turner";

        Job job_1 = new Job();
        job_1._company = "Microsoft";
        job_1._jobTitle = "Programmer";
        job_1._startYear = 2021;
        job_1._endYear = 2024;
        
        resume._jobs.Add(job_1);

        Job job_2 = new Job();
        job_2._company = "Manager";
        job_2._jobTitle = "T-Mobile";
        job_2._startYear = 2024;
        job_2._endYear = 2027;

        resume._jobs.Add(job_2);

        resume.Display();
    }
}