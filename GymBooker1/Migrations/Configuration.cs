namespace GymBooker1.Migrations
{
    using GymBooker1.Controllers;
    using GymBooker1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymBooker1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GymBooker1.Models.ApplicationDbContext";

            // Need this to avoid migration errors. From: https://stackoverflow.com/questions/24981593/specified-key-was-too-long-max-key-length-is-767-bytes-mysql-error-in-entity-fr  (ASP.NET only)
            // Answer half way down starting with: "Use the configuration code below... This solved my problem:"
            // The main problem was max length of id in migration history table. Before that there was a SqlGenerator error.

            // Need the line below uncommented to allow for migrations through package manager console.....
            // (although annotation in IdentityModels works instead)
            // (and code first approach - am just attempting a conversion to MySql so not needed for code first)
            // see https://docs.microsoft.com/en-gb/ef/ef6/fundamentals/configuring/code-based?redirectedfrom=MSDN for more details
            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
         
            // This line needed for migrations and can be left in as does not cause any later problems
            SetSqlGenerator(MySqlProviderInvariantName.ProviderName, new MySqlMigrationSqlGenerator()); // i.e. ProviderName = "MySql.Data.MySqlClient"

            // This line causes an error if you leave any references to MSSQL in the Web.config file
            SetHistoryContextFactory(MySqlProviderInvariantName.ProviderName, (connection, schema) => new MySqlHistoryContext(connection, schema));
        }

        protected override void Seed(GymBooker1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            

            AddClasses();
            
            //var x = new TimetableController();
            //x.UpdateCalendar();

            void AddClasses()
            {
                var BodyPump =      new GymClass() { Category = "Tone", Name = "BodyPump", Description = "Addictive workout challenges all of your major muscle groups by using a blend of the best gym exercises including squats, pressing and pulling movements. Using high repetitions and light weights, this class will help you to achieve a more toned and healthy body." };
                var Pilates =       new GymClass() { Category = "Mind", Name = "Pilates", Description = "A system of physical conditioning involving low-impact exercises and stretches designed to strengthen muscles of the torso and often performed using specialised equipment. Great if your goal is weight loss, toning, strength & conditioning, build muscle, training for an event or general fitness." };
                var Spinning =      new GymClass() { Category = "Cardio", Name = "Spinning", Description = "Group cycling classes combine interval based cycling drills with music to create challenging workouts for participants of all fitness levels." };
                var Kettlebells =   new GymClass() { Category = "Tone", Name = "Kettlebells", Description = "Strengthen and tone your whole body! You will swing, lunge and squat your way to a more toned body whilst improving your strength, flexibility and cardiovascular endurance in our Kettlebells class. Come join a class and get to grips with a kettlebell, and find out why it's a powerful tool for improving your fitness and overall body composition." };
                var Yoga =          new GymClass() { Category = "Mind", Name = "Yoga", Description = "Focuses on tuning into the body, building strength and maintaining flexibility for functional movements" };               
                var Circuits =      new GymClass() { Category = "Cardio", Name = "Circuits", Description = "A high intensity workout that will help tone your body and shed fat, this is a great class to attend. Circuits is a high energy and fast-paced class which involves working your way around different exercise stations performing each exercise as many times as you can in a set amount of time. Join in this classic class for a fun way to work out!" };
                var BoxFit =        new GymClass() { Category = "Cardio", Name = "Box Fit", Description = "A circuit style blend of many different fighting related exercises and drills. Incorporating the bag, battle ropes, skipping and some TRX. Participants will also pair up to perform some pad work. This class packs a real punch!" };
                var Step =          new GymClass() { Category = "Cardio", Name = "Step", Description = "This great cardio workout is choreographed. As you progress, so will the movements, always giving you something new and fun to experience in the class. You’ll have a fantastic athletic workout that helps to burn fat and tone up to some great music! Great if your goal is weight loss, toning or general fitness." };
                var Combat =        new GymClass() { Category = "Cardio", Name = "Combat", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." };
                var Zumba =         new GymClass() { Category = "Cardio", Name = "Zumba", Description = "Join the party with this fusion of Latin international rhythms and easy-to-follow moves. Through both low and high intensity movements, you’ll be dancing your way through this calorie burning dance workout. Great if your goal is weight loss or general fitness." };
                var Strength =      new GymClass() { Category = "Strength", Name = "Strength", Description = "Develop your full body STRENGTH! Each class includes 8 strength exercises with perfect form and control to hit the whole body.Plus, we always end with a finisher exercise to make sure you leave with those post-workout endorphins rushing round your body!" };
                var LegsBumsTums =  new GymClass() { Category = "Tone", Name = "Legs, Bums, Tums", Description = "Shape up and burn fat as you lunge, step and squat your way to fitness in this ever-popular, fun class using both weights and your own bodyweight. The high repetition based routines will put your legs, bums and tums through their paces in a bid to trim down those areas we love to hate - trust us, your body will thank you for it!" };
                var BodyTone =      new GymClass() { Category = "Tone", Name = "Body Tone", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" };
                var BurnIt =        new GymClass() { Category = "Cardio", Name = "Burn It", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." };
                var AbsoluteAbs =   new GymClass() { Category = "Tone", Name = "Absolute Abs", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" };

                if (!context.GymClasses.Any())
                {
                    context.GymClasses.AddOrUpdate((p => p.Name), BodyPump, Pilates, Spinning, Kettlebells, Yoga, Circuits, BoxFit, Step, Combat, Zumba, Strength, LegsBumsTums, BodyTone, BurnIt, AbsoluteAbs);
                }

                if (!context.StdGymClassTimetables.Any())
                {
                        context.StdGymClassTimetables.AddOrUpdate(
                        // Re GymClassId:
                        //    Before changing the way I used the foreign key I have to use an object GymClass as foreign key - because it's not been saved the foreign key value is not available and you cant just use an integer
                        //    After changing the way I used the foreign key I can use an integer

                        new StdGymClassTimetable() { GymClassId = 1, Day = 0, Hour = 8, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = 0, Hour = 9, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = 0, Hour = 10, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = 0, Hour = 11, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = 0, Hour = 13, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = 0, Hour = 14, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = 0, Hour = 15, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = 0, Hour = 16, Minute = 45, MaxPeople = 20 },
                        

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Monday, Hour = 6, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Monday, Hour = 7, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Monday, Hour = 8, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Monday, Hour = 9, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Monday, Hour = 11, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Monday, Hour = 12, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Monday, Hour = 13, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Monday, Hour = 14, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Monday, Hour = 16, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Monday, Hour = 17, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Monday, Hour = 18, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Monday, Hour = 19, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Monday, Hour = 21, Minute = 0, MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Tuesday, Hour = 7, Minute = 0, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Tuesday, Hour = 8, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Tuesday, Hour = 9, Minute = 30, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Tuesday, Hour = 10, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Tuesday, Hour = 12, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Tuesday, Hour = 13, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Tuesday, Hour = 14, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Tuesday, Hour = 15, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Tuesday, Hour = 16, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Tuesday, Hour = 18, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Tuesday, Hour = 19, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Tuesday, Hour = 20, Minute = 45, Instructor = "John Deer", MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Wednesday, Hour = 8, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Wednesday, Hour = 9, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Wednesday, Hour = 10, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Wednesday, Hour = 11, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Wednesday, Hour = 13, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Wednesday, Hour = 14, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Wednesday, Hour = 15, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Wednesday, Hour = 16, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Wednesday, Hour = 17, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Wednesday, Hour = 19, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Wednesday, Hour = 20, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Wednesday, Hour = 6, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Thursday, Hour = 9, Minute = 0, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Thursday, Hour = 10, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Thursday, Hour = 11, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Thursday, Hour = 12, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Thursday, Hour = 13, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Thursday, Hour = 15, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Thursday, Hour = 16, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Thursday, Hour = 17, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Thursday, Hour = 18, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Thursday, Hour = 20, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Thursday, Hour = 6, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Thursday, Hour = 7, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Friday, Hour = 10, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Friday, Hour = 11, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Friday, Hour = 12, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Friday, Hour = 13, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Friday, Hour = 14, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Friday, Hour = 16, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Friday, Hour = 17, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Friday, Hour = 18, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Friday, Hour = 20, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Friday, Hour = 6, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Friday, Hour = 7, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Friday, Hour = 8, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Saturday, Hour = 7, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Saturday, Hour = 8, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Saturday, Hour = 9, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Saturday, Hour = 10, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Saturday, Hour = 12, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Saturday, Hour = 13, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Saturday, Hour = 14, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Saturday, Hour = 15, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Saturday, Hour = 16, Minute = 0, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Saturday, Hour = 17, Minute = 15, Instructor = "Natalie Spears" }

                    );

                }

                // Or do manually. I created manually originally and used 1 and 2 as Ids. If you don't specify the system creates a long string id
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    role.Id = "1";
                    roleManager.Create(role);
                }

                if (!roleManager.RoleExists("User"))
                {
                    var role = new IdentityRole();
                    role.Name = "User";
                    role.Id = "2";
                    roleManager.Create(role);
                }

                //context.Database.ExecuteSqlCommand("delete from StdGymClassTimetables");
                // 
                // or:
                //context.StdGymClassTimetables.RemoveRange(context.StdGymClassTimetables);
                //context.SaveChanges();
            }

        }


    }
}
