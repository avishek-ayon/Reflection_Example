
using Assignment1;

Course course = new Course
{
    Title = "Asp.net",
    Teacher = new Instructor
    {
        Name = "Ayon",
        Email = "Avkd@",
        PresentAddress = new Address
        {
            Street = "bbd",
            City = "Ctg",
            Country = "Ban"
        },
        PermanentAddress = new Address
        {
            Street = "bbd",
            City = "Ctg",
            Country = "Ban"
        },
        PhoneNumbers = new List<Phone>
            {
                new Phone
                {
                    Number = "0000000",
                    Extension = "018",
                    CountryCode = "114"
                }
            }
    },

    Topics = new List<Topic>
    {
        new Topic
        {
            Title = "Installation",
            Description = "Later Give on",
            Sessions = new List<Session>
             {
               new Session
               {
                  DurationInHour = 2,
                  LearningObjective = "By Starting Professional Careerer"
               }
            }
        }

    },
    Fees = 30000,
    Tests = new List<AdmissionTest>
    {
      new AdmissionTest
      {
          StartDateTime = DateTime.Now,
          EndDateTime = DateTime.Now,
          TestFees = 100
      }
    }

};

string json = JsonFormatter.Convert(course);
Console.WriteLine(json);