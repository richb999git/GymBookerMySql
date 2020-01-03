using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GymBooker1.Models
{
    public class GymClasses : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class StdGymClassTimetables : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class CalendarItems : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class GymClass
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Deleted { get; set; } = false;
    }

    public class StdGymClassTimetable
    {
        public int Id { get; set; }

        [ForeignKey("GymClass")]
        [Display(Name = "Class Id")]
        public int GymClassId { get; set; }
        public virtual GymClass GymClass { get; set; } // navigation property for foreign key

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Instructor { get; set; } = "Jenny Body";

        [StringLength(12, MinimumLength = 2)]
        [Required]
        public string Hall { get; set; } = "Hall 1";

        [Range(20, 1440)]
        public int Duration { get; set; } = 60; // minutes

        [Range(0, 6)]
        public DayOfWeek Day { get; set; }

        [Range(0, 23)]
        public int Hour { get; set; }

        [Range(0, 59)]
        public int Minute { get; set; }

        [Range(1, 100)]
        [Display(Name = "Max People")]
        public int MaxPeople { get; set; } = 20;

        [Display(Name = "Cancelled")]
        public bool Deleted { get; set; } = false;
    }

    public class CalendarItem
    {
        public int Id { get; set; }

        [ForeignKey("GymClass")]
        public int GymClassId { get; set; }
        public virtual GymClass GymClass { get; set; } // navigation property for foreign key

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Instructor { get; set; }

        [Range(20, 1440)]
        public int Duration { get; set; }  // minutes

        [StringLength(12, MinimumLength = 2)]
        [Required]
        public string Hall { get; set; }

        public string UserIds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm tt}")]
        public DateTime GymClassTime { get; set; } // this is a specific date/time. In StdGymClassTimetable it uses Day/Hour/Minute

        [Range(1, 100)]
        [Display(Name = "Max People")]
        public int MaxPeople { get; set; }
    }


    public static class GetPics
    {
        public static string[] Get2Pics(string Name)
        {
            // show 2 pics from particular Gym class side by side (or only one on small screens)*@
            // use array for now

            string[] circuits = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140340/GymBooker/Circuits2.jpg",
                                                "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140342/GymBooker/Circuits3.jpg" };
            string[] step = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Step2.jpg",
                                            "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Step3.jpg" };
            string[] boxfit = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140324/GymBooker/BoxFit2.jpg",
                                              "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140326/GymBooker/BoxFit3.jpg" };
            string[] zumba = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Zumba2.jpg",
                                             "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Zumba3.jpg" };
            string[] spin = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Spin2.jpg",
                                            "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141002/GymBooker/Spin3.jpg" };
            string[] burnit = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140332/GymBooker/BurnIt2.jpg",
                                              "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140334/GymBooker/BurnIt3.jpg" };
            string[] combat = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140983/GymBooker/Combat2.jpg",
                                              "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140983/GymBooker/Combat3.jpg" };
            string[] abs = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140176/GymBooker/AbsoluteAbs2.jpg",
                                           "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140187/GymBooker/AbsoluteAbs3.jpg" };
            string[] lbt = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/LegsBumsTums2.jpg",
                                           "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140994/GymBooker/LegsBumsTums3.jpg" };
            string[] pump = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140199/GymBooker/BodyPump2.jpg",
                                            "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140203/GymBooker/BodyPump3.jpg" };
            string[] tone = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140213/GymBooker/BodyTone2.jpg",
                                            "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140216/GymBooker/BodyTone3.jpg" };
            string[] kettlebells = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/Kettlebells2.jpg",
                                                   "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/Kettlebells3.jpg" };
            string[] yoga = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141004/GymBooker/Yoga2.jpg",
                                            "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141001/GymBooker/Yoga3.jpg" };
            string[] pilates = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/Pilates2.jpg",
                                               "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/Pilates3.jpg" };
            string[] strength = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Strength2.jpg",
                                                "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Strength3.jpg" };
            string[] pics = new string[2];

            switch (Name)
            {
                case "Circuits":
                    pics = circuits;
                    break;
                case "Step":
                    pics = step;
                    break;
                case "Box Fit":
                    pics = boxfit;
                    break;
                case "Zumba":
                    pics = zumba;
                    break;
                case "Spinning":
                    pics = spin;
                    break;
                case "Burn It":
                    pics = burnit;
                    break;
                case "Combat":
                    pics = combat;
                    break;
                case "Absolute Abs":
                    pics = abs;
                    break;
                case "Legs, Bums, Tums":
                    pics = lbt;
                    break;
                case "BodyPump":
                    pics = pump;
                    break;
                case "Body Tone":
                    pics = tone;
                    break;
                case "Kettlebells":
                    pics = kettlebells;
                    break;
                case "Yoga":
                    pics = yoga;
                    break;
                case "Pilates":
                    pics = pilates;
                    break;
                case "Strength":
                    pics = strength;
                    break;
                default:
                    pics = abs;
                    break;
            }

            return pics;
        }


        public static string[] GetCategoryPic(string category)
        {

            string[] cardio = new string[7] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140319/GymBooker/BoxFit1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140329/GymBooker/BurnIt1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140337/GymBooker/Circuits1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140983/GymBooker/Combat1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141002/GymBooker/Spin1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Step1.jpg",
                                          "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141002/GymBooker/Zumba1.jpg" };
            string[] tone = new string[5] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140135/GymBooker/AbsoluteAbs1.jpg",
                                        "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140197/GymBooker/BodyPump1.jpg",
                                        "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140211/GymBooker/BodyTone1.jpg",
                                        "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140993/GymBooker/Kettlebells1.jpg",
                                        "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140994/GymBooker/LegsBumsTums3.jpg" };
            string[] mind = new string[2] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577140994/GymBooker/Pilates1.jpg",
                                        "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141004/GymBooker/Yoga1.jpg" };
            string[] strength = new string[1] { "https://res.cloudinary.com/cloudstoragerb/image/upload/v1577141003/GymBooker/Strength1.jpg" };
            string[] pics = new string[20];

            switch (category)
            {
                case "Cardio":
                    pics = cardio;
                    break;
                case "Tone":
                    pics = tone;
                    break;
                case "Mind":
                    pics = mind;
                    break;
                case "Strength":
                    pics = strength;
                    break;
                default:
                    pics = cardio;
                    break;
            }
            return pics;
        }

    }

    




    public static class CategoryDescs
    {
        public static string[] GetCategoryDescs()
        {
            string[] descs = new string[4];
            descs[0] = "Get fitter and burn calories. These classes are for anyone that loves music and energy.";
            descs[1] = "Change the shape of your body by strengthening and conditioning your muscles.";
            descs[2] = "All rounder classes for wellbeing, core strength, flexibility and low impact conditioning.";
            descs[3] = "Feel stronger and fitter using functional kit such as battle ropes, assault bikes and kettlebells.";
            return descs;
        }
    }

}