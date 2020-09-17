using System;
using System.Linq;
using EFCore_DatabaseFirst.Db;

namespace EFCore_DatabaseFirst
{
    class Program
    {

        static void Main(string[] args)
        {
            // ADD A RECORD
            AddRecord();

            // UPDATE A RECORD
            //UpdateRecord(1);

            // QUERY A RECORD
            //var p = GetRecord(1);

            //if (p != null)
            //{
            //    Console.WriteLine($"FullName: {p.FirstName} {p.LastName}");
            //    Console.WriteLine($"Birth Date: {p.DateOfBirth.ToShortDateString()}");
            //}

            //DELETE A RECORD
            //DeleteRecord(1);

            Console.WriteLine($"Record count: {GetPersonCount()}");
        }

        static readonly DbFirstDemoContext _dbContext = new DbFirstDemoContext();

        static int GetPersonCount()
        {
            return _dbContext.People.ToList().Count;
        }

        static void AddRecord()
        {
            var person = new Person
            {
                FirstName = "Vjor",
                LastName = "Durano",
                DateOfBirth = Convert.ToDateTime("06/19/2020")
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();
        }

        static void UpdateRecord(int id)
        {
            var person = _dbContext.People.Find(id);

            if(person == null)
            {
                return;
            }

            person.FirstName = "Vynn Markus";
            person.DateOfBirth = Convert.ToDateTime("11/22/2016");

            _dbContext.People.Update(person);
            _dbContext.SaveChanges();

        }

        static Person GetRecord(int id)
        {
            return _dbContext.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        static void DeleteRecord(int id)
        {
            var person = _dbContext.People.Find(id);

            if (person == null)
            {
                return;
            }

            _dbContext.People.Remove(person);
            _dbContext.SaveChanges();
        }
    }
}
