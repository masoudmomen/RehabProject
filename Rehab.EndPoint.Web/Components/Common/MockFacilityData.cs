using Rehab.Application.Facilities;
using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Conditions;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.SubstancesWeTreat;
using Rehab.Domain.Treatments;
using Rehab.Domain.WhoWeTreat;
using Rehab.EndPoint.Web.ViewModels;

namespace Rehab.EndPoint.Web.Components.Common
{
    public static class MockFacilityData
    {
        public static List<FacilityViewModel> GetSampleFacilities()
        {
            return new List<FacilityViewModel>
            {
                new FacilityViewModel
                {
                    Id = 1,
                    Name = "Serene Gardens Recovery",
                    City = "Laguna Beach",
                    State = "CA",
                    Address = "31365 Monterey St",
                    Description = "A luxury recovery center offering personalized treatment plans in a serene coastal setting.",
                    Logo = "/images/FacilitiesSample/logo1.png",
                    Cover = "/images/FacilitiesSample/1.jpg",
                    PhoneNumber = "(949) 555-0123",
                    WebSite = "https://serenegardens.com",
                    Slug = "serene-gardens-recovery",
                    Email = "info@serenegardens.com",
                    IsVerified = true,
                    Founded = 2018,
                    OccupancyMin = 20,
                    OccupancyMax = 50,
                    Insurances = new List<InsuranceViewModel>
                    {
                        new InsuranceViewModel { Id = 1, Name = "Aetna" },
                        new InsuranceViewModel { Id = 2, Name = "Blue Cross Blue Shield" }
                    },
                    Accreditations = new List<AccreditationViewmodel>
                    {
                        new AccreditationViewmodel { Id = 1, Name = "Joint Commission" },
                        new AccreditationViewmodel { Id = 2, Name = "CARF" },
                        new AccreditationViewmodel { Id = 3, Name = "State Licensed" },
                        new AccreditationViewmodel { Id = 4, Name = "Medicare Certified" },
                        new AccreditationViewmodel { Id = 5, Name = "Medicaid Certified" }
                    },
                    Amenities = new List<AmenityViewmodel>
                    {
                        new AmenityViewmodel { Id = 1, Name = "Private Rooms" },
                        new AmenityViewmodel { Id = 2, Name = "Fitness Center" },
                        new AmenityViewmodel { Id = 3, Name = "Swimming Pool" }
                    },
                    Highlights = new List<HighlightViewmodel>
                    {
                        new HighlightViewmodel { Id = 1, Name = "Luxury Accommodations" },
                        new HighlightViewmodel { Id = 2, Name = "Ocean View" },
                        new HighlightViewmodel { Id = 3, Name = "Holistic Approach" },
                        new HighlightViewmodel { Id = 4, Name = "24/7 Medical Support" },
                        new HighlightViewmodel { Id = 5, Name = "Family Therapy" },
                        new HighlightViewmodel { Id = 6, Name = "Aftercare Planning" },
                        new HighlightViewmodel { Id = 7, Name = "Nutritional Counseling" },
                        new HighlightViewmodel { Id = 8, Name = "Mindfulness Training" }
                    },
                    Locs = new List<LocViewmodel>
                    {
                        new LocViewmodel { Id = 1, Name = "Detox" },
                        new LocViewmodel { Id = 2, Name = "Residential (Inpatient)" },
                        new LocViewmodel { Id = 3, Name = "Partial Hospitalization Program (PHP)" },
                        new LocViewmodel { Id = 4, Name = "Intensive Outpatient Program (IOP)" },
                        new LocViewmodel { Id = 5, Name = "Outpatient" },
                        new LocViewmodel { Id = 6, Name = "Aftercare / Continuing Care" }
                    },
                    Treatments = new List<TreatmentViewmodel>
                    {
                        new TreatmentViewmodel { Id = 1, Name = "Cognitive Behavioral Therapy" },
                        new TreatmentViewmodel { Id = 2, Name = "Dialectical Behavior Therapy" },
                        new TreatmentViewmodel { Id = 3, Name = "EMDR" },
                        new TreatmentViewmodel { Id = 4, Name = "Group Therapy" },
                        new TreatmentViewmodel { Id = 5, Name = "Individual Therapy" },
                        new TreatmentViewmodel { Id = 6, Name = "Medication Management" },
                        new TreatmentViewmodel { Id = 7, Name = "Art Therapy" },
                        new TreatmentViewmodel { Id = 8, Name = "Music Therapy" },
                        new TreatmentViewmodel { Id = 9, Name = "Equine Therapy" },
                        new TreatmentViewmodel { Id = 10, Name = "Yoga Therapy" },
                        new TreatmentViewmodel { Id = 11, Name = "Meditation" },
                        new TreatmentViewmodel { Id = 12, Name = "Acupuncture" },
                        new TreatmentViewmodel { Id = 13, Name = "Massage Therapy" },
                        new TreatmentViewmodel { Id = 14, Name = "Recreational Therapy" },
                        new TreatmentViewmodel { Id = 15, Name = "Life Skills Training" },
                        new TreatmentViewmodel { Id = 16, Name = "Relapse Prevention" },
                        new TreatmentViewmodel { Id = 17, Name = "12-Step Alternatives" },
                        new TreatmentViewmodel { Id = 18, Name = "Trauma-Informed Care" },
                        new TreatmentViewmodel { Id = 19, Name = "Dual Diagnosis Treatment" },
                        new TreatmentViewmodel { Id = 20, Name = "Family Systems Therapy" }
                    },
                    Condition = new List<ConditionViewModel>
                    {
                        new ConditionViewModel { Id = 1, Name = "Alcohol Addiction" },
                        new ConditionViewModel { Id = 2, Name = "Drug Addiction" },
                        new ConditionViewModel { Id = 3, Name = "Depression" },
                        new ConditionViewModel { Id = 4, Name = "Anxiety" },
                        new ConditionViewModel { Id = 5, Name = "PTSD" },
                        new ConditionViewModel { Id = 6, Name = "Bipolar Disorder" },
                        new ConditionViewModel { Id = 7, Name = "Eating Disorders" },
                        new ConditionViewModel { Id = 8, Name = "Gambling Addiction" },
                        new ConditionViewModel { Id = 9, Name = "Sex Addiction" },
                        new ConditionViewModel { Id = 10, Name = "Process Addictions" }
                    },
                    Swt = new List<SwtViewModel>
                    {
                        new SwtViewModel { Id = 1, Name = "Alcohol" },
                        new SwtViewModel { Id = 2, Name = "Cocaine" },
                        new SwtViewModel { Id = 3, Name = "Heroin" },
                        new SwtViewModel { Id = 4, Name = "Methamphetamine" },
                        new SwtViewModel { Id = 5, Name = "Prescription Opioids" },
                        new SwtViewModel { Id = 6, Name = "Benzodiazepines" },
                        new SwtViewModel { Id = 7, Name = "Marijuana" },
                        new SwtViewModel { Id = 8, Name = "Synthetic Drugs" }
                    },
                    Wwt= new List<WwtViewModel>
                    {
                        new WwtViewModel { Id = 1, Name = "Adults" },
                        new WwtViewModel { Id = 2, Name = "Young Adults" },
                        new WwtViewModel { Id = 3, Name = "Professionals" },
                        new WwtViewModel { Id = 4, Name = "LGBTQ+" },
                        new WwtViewModel { Id = 5, Name = "Veterans" },
                        new WwtViewModel { Id = 6, Name = "First Responders" }
                    },
                    FacilityImages = new List<FacilityImageViewmodel>
                    {
                        new FacilityImageViewmodel { Id = 1, Title = "Ocean View Therapy Room", ImageAddress = "/images/FacilitiesSample/facility1_1.jpg" },
                        new FacilityImageViewmodel { Id = 2, Title = "Private Beach Access", ImageAddress = "/images/FacilitiesSample/facility1_2.jpg" },
                        new FacilityImageViewmodel { Id = 3, Title = "Luxury Dining Area", ImageAddress = "/images/FacilitiesSample/facility1_3.jpg" },
                        new FacilityImageViewmodel { Id = 4, Title = "Meditation Garden", ImageAddress = "/images/FacilitiesSample/facility1_4.jpg" },
                        new FacilityImageViewmodel { Id = 5, Title = "Fitness Center", ImageAddress = "/images/FacilitiesSample/facility1_5.jpg" },
                        new FacilityImageViewmodel { Id = 6, Title = "Swimming Pool", ImageAddress = "/images/FacilitiesSample/facility1_6.jpg" }
                    }
                },
                new FacilityViewModel
                {
                    Id = 2,
                    Name = "Mountain View Wellness",
                    City = "Denver",
                    State = "CO",
                    Address = "789 Pine Ridge Dr",
                    Description = "A comprehensive treatment center nestled in the Rocky Mountains offering evidence-based recovery programs.",
                    Logo = "/images/FacilitiesSample/logo2.png",
                    Cover = "/images/FacilitiesSample/2.jpg",
                    PhoneNumber = "(303) 555-0456",
                    WebSite = "https://mountainviewwellness.com",
                    Slug = "mountain-view-wellness",
                    Email = "info@mountainviewwellness.com",
                    IsVerified = true,
                    Founded = 2015,
                    OccupancyMin = 15,
                    OccupancyMax = 40,
                    Insurances = new List<InsuranceViewModel>
                    {
                        new InsuranceViewModel { Id = 3, Name = "UnitedHealth" , Logo = "/images/FacilitiesSample/insurance-1.jpg"},
                        new InsuranceViewModel { Id = 4, Name = "Cigna"  },
                        new InsuranceViewModel { Id = 5, Name = "Aetna" , Logo = "/images/FacilitiesSample/insurance-2.jpg"},
                        new InsuranceViewModel { Id = 6, Name = "Untitled" },
                        new InsuranceViewModel { Id = 5, Name = "Sad Insurance" , Logo = "/images/FacilitiesSample/insurance-3.jpg"},
                        new InsuranceViewModel { Id = 5, Name = "HAppy Insurance" },
                        new InsuranceViewModel { Id = 5, Name = "Test Insurance" , Logo = "/images/FacilitiesSample/insurance-4.jpg"},
                    },
                    Accreditations = new List<AccreditationViewmodel>
                    {
                        new AccreditationViewmodel { Id = 6, Name = "Joint Commission" },
                        new AccreditationViewmodel { Id = 7, Name = "State Licensed" },
                        new AccreditationViewmodel { Id = 8, Name = "Medicare Certified" }
                    },
                    Amenities = new List<AmenityViewmodel>
                    {
                        new AmenityViewmodel { Id = 4, Name = "Mountain Views" },
                        new AmenityViewmodel { Id = 5, Name = "Hiking Trails" , Logo="/images/FacilitiesSample/Amenity-1.png"},
                        new AmenityViewmodel { Id = 6, Name = "Meditation Garden" }
                    },
                    Highlights = new List<HighlightViewmodel>
                    {
                        new HighlightViewmodel { Id = 9, Name = "Nature-Based Therapy" },
                        new HighlightViewmodel { Id = 10, Name = "Adventure Therapy" },
                        new HighlightViewmodel { Id = 11, Name = "Mindfulness Training" },
                        new HighlightViewmodel { Id = 12, Name = "Holistic Healing" }
                    },
                    Locs = new List<LocViewmodel>
                    {
                        new LocViewmodel { Id = 2, Name = "Residential (Inpatient)" },
                        new LocViewmodel { Id = 3, Name = "Partial Hospitalization Program (PHP)" },
                        new LocViewmodel { Id = 4, Name = "Intensive Outpatient Program (IOP)" },
                        new LocViewmodel { Id = 5, Name = "Outpatient" },
                        new LocViewmodel { Id = 6, Name = "Aftercare / Continuing Care" }
                    },
                    Treatments = new List<TreatmentViewmodel>
                    {
                        new TreatmentViewmodel {
                            Id = 21,
                            Name = "Wilderness Therapy" ,
                            Description ="Experience healing in nature's classroom through our wilderness therapy program. This innovative approach combines outdoor adventures with therapeutic intervention, helping participants develop resilience, self-confidence, and coping skills while navigating both natural challenges and personal growth. Our licensed therapists guide individuals through carefully structured outdoor experiences that promote emotional regulation, communication skills, and healthy risk-taking in a supportive natural environment."
                        },
                        new TreatmentViewmodel { 
                            Id = 22,
                            Name = "Cognitive Behavioral Therapy" ,
                            Description ="ransform negative thought patterns and behaviors through evidence-based cognitive behavioral therapy (CBT). Our skilled therapists work collaboratively with you to identify unhelpful thinking cycles, develop practical coping strategies, and create lasting behavioral changes. CBT is highly effective for treating anxiety, depression, trauma, and many other mental health concerns by focusing on the connection between thoughts, feelings, and actions."
                        },
                        new TreatmentViewmodel {
                            Id = 23, 
                            Name = "Group Therapy",
                            Description ="Find connection and healing alongside others who share similar experiences in our supportive group therapy sessions. Led by experienced facilitators, these sessions provide a safe space to practice new skills, gain different perspectives, and build meaningful relationships. Group therapy offers unique benefits including peer support, reduced isolation, and opportunities to both give and receive feedback in a therapeutic community setting."
                        },
                        new TreatmentViewmodel { 
                            Id = 24,
                            Name = "Individual Therapy",
                            Description ="Receive personalized, one-on-one support tailored to your unique needs and goals through individual therapy sessions. Our compassionate therapists create a confidential, non-judgmental space where you can explore challenges, process emotions, and develop personalized strategies for growth and healing. Whether addressing specific mental health concerns or seeking personal development, individual therapy provides focused attention and customized treatment approaches."
                        }
                    },
                    Condition = new List<ConditionViewModel>
                    {
                        new ConditionViewModel { Id = 11, Name = "Substance Abuse" },
                        new ConditionViewModel { Id = 12, Name = "Mental Health" },
                        new ConditionViewModel { Id = 13, Name = "Co-occurring Disorders" }
                    },
                    Swt = new List<SwtViewModel>
                    {
                        new SwtViewModel { Id = 9, Name = "Alcohol" },
                        new SwtViewModel { Id = 10, Name = "Opioids" },
                        new SwtViewModel { Id = 11, Name = "Stimulants" }
                    },
                    Wwt = new List<WwtViewModel>
                    {
                        new WwtViewModel { Id = 7, Name = "Anxiety Disorders" , Logo ="/images/FacilitiesSample/wwt-1.png"},
                        new WwtViewModel { Id = 8, Name = "Depression" , Logo ="/images/FacilitiesSample/wwt-2.png"},
                        new WwtViewModel { Id = 9, Name = "Bipolar Disorder" , Logo ="/images/FacilitiesSample/wwt-3.png"},
                        new WwtViewModel { Id = 10, Name = "Post-Traumatic Stress Disorder (PTSD)" , Logo ="/images/FacilitiesSample/wwt-4.png"}
                    },
                    FacilityImages = new List<FacilityImageViewmodel>
                    {
                        new FacilityImageViewmodel { Id = 7, Title = "Mountain View from Therapy Room", ImageAddress = "/images/FacilitiesSample/facility2_1.jpg" },
                        new FacilityImageViewmodel { Id = 8, Title = "Hiking Trail Entrance", ImageAddress = "/images/FacilitiesSample/facility2_2.jpg" },
                        new FacilityImageViewmodel { Id = 9, Title = "Meditation Garden", ImageAddress = "/images/FacilitiesSample/facility2_3.jpg" },
                        new FacilityImageViewmodel { Id = 10, Title = "Wilderness Therapy Area", ImageAddress = "/images/FacilitiesSample/facility2_4.jpg" },
                        new FacilityImageViewmodel { Id = 11, Title = "Rocky Mountain Vista", ImageAddress = "/images/FacilitiesSample/facility2_5.jpg" }
                    }
                },
                new FacilityViewModel
                {
                    Id = 3,
                    Name = "Urban Recovery Center",
                    City = "New York",
                    State = "NY",
                    Address = "456 Broadway Ave",
                    Description = "A modern, urban recovery center providing accessible treatment in the heart of Manhattan.",
                    Logo = "/images/FacilitiesSample/logo3.png",
                    Cover = "/images/FacilitiesSample/3.jpg",
                    PhoneNumber = "(212) 555-0789",
                    WebSite = "https://urbanrecovery.com",
                    Slug = "urban-recovery-center",
                    Email = "info@urbanrecovery.com",
                    IsVerified = true,
                    Founded = 2020,
                    OccupancyMin = 25,
                    OccupancyMax = 60,
                    Insurances = new List<InsuranceViewModel>
                    {
                        new InsuranceViewModel { Id = 6, Name = "Blue Cross Blue Shield" },
                        new InsuranceViewModel { Id = 7, Name = "Aetna" },
                        new InsuranceViewModel { Id = 8, Name = "Cigna" },
                        new InsuranceViewModel { Id = 9, Name = "UnitedHealth" }
                    },
                    Accreditations = new List<AccreditationViewmodel>
                    {
                        new AccreditationViewmodel { Id = 9, Name = "Joint Commission" },
                        new AccreditationViewmodel { Id = 10, Name = "CARF" },
                        new AccreditationViewmodel { Id = 11, Name = "State Licensed" }
                    },
                    Amenities = new List<AmenityViewmodel>
                    {
                        new AmenityViewmodel { Id = 7, Name = "Modern Facilities" },
                        new AmenityViewmodel { Id = 8, Name = "Technology Integration" },
                        new AmenityViewmodel { Id = 9, Name = "Urban Accessibility" }
                    },
                    Highlights = new List<HighlightViewmodel>
                    {
                        new HighlightViewmodel { Id = 13, Name = "Technology-Enhanced Treatment" },
                        new HighlightViewmodel { Id = 14, Name = "Urban Accessibility" },
                        new HighlightViewmodel { Id = 15, Name = "Modern Facilities" },
                        new HighlightViewmodel { Id = 16, Name = "Evidence-Based Programs" }
                    },
                    Locs = new List<LocViewmodel>
                    {
                        new LocViewmodel { Id = 3, Name = "Partial Hospitalization Program (PHP)" },
                        new LocViewmodel { Id = 4, Name = "Intensive Outpatient Program (IOP)" },
                        new LocViewmodel { Id = 5, Name = "Outpatient" },
                        new LocViewmodel { Id = 6, Name = "Aftercare / Continuing Care" }
                    },
                    Treatments = new List<TreatmentViewmodel>
                    {
                        new TreatmentViewmodel { Id = 25, Name = "Digital Therapy" },
                        new TreatmentViewmodel { Id = 26, Name = "Cognitive Behavioral Therapy" },
                        new TreatmentViewmodel { Id = 27, Name = "Group Therapy" },
                        new TreatmentViewmodel { Id = 28, Name = "Individual Therapy" },
                        new TreatmentViewmodel { Id = 29, Name = "Medication Management" }
                    },
                    Condition = new List<ConditionViewModel>
                    {
                        new ConditionViewModel { Id = 14, Name = "Substance Abuse" },
                        new ConditionViewModel { Id = 15, Name = "Mental Health" },
                        new ConditionViewModel { Id = 16, Name = "Dual Diagnosis" }
                    },
                    Swt = new List<SwtViewModel>
                    {
                        new SwtViewModel { Id = 12, Name = "Alcohol" },
                        new SwtViewModel { Id = 13, Name = "Opioids" },
                        new SwtViewModel { Id = 14, Name = "Stimulants" },
                        new SwtViewModel { Id = 15, Name = "Benzodiazepines" }
                    },
                    Wwt = new List<WwtViewModel>
                    {
                        new WwtViewModel { Id = 9, Name = "Adults" },
                        new WwtViewModel { Id = 10, Name = "Professionals" },
                        new WwtViewModel { Id = 11, Name = "Urban Residents" }
                    },
                    FacilityImages = new List<FacilityImageViewmodel>
                    {
                        new FacilityImageViewmodel { Id = 12, Title = "Modern Therapy Office", ImageAddress = "/images/FacilitiesSample/facility3_1.jpg" },
                        new FacilityImageViewmodel { Id = 13, Title = "Technology-Enhanced Treatment Room", ImageAddress = "/images/FacilitiesSample/facility3_2.jpg" },
                        new FacilityImageViewmodel { Id = 14, Title = "Urban Rooftop Garden", ImageAddress = "/images/FacilitiesSample/facility3_3.jpg" },
                        new FacilityImageViewmodel { Id = 15, Title = "Digital Therapy Station", ImageAddress = "/images/FacilitiesSample/facility3_4.jpg" },
                        new FacilityImageViewmodel { Id = 16, Title = "Modern Group Therapy Room", ImageAddress = "/images/FacilitiesSample/facility3_5.jpg" },
                        new FacilityImageViewmodel { Id = 17, Title = "Urban Accessibility Features", ImageAddress = "/images/FacilitiesSample/facility3_6.jpg" }
                    }
                }
            };
        }

        public static FacilityViewModel GetSampleFacility(int id = 1)
        {
            return GetSampleFacilities().FirstOrDefault(f => f.Id == id) ?? GetSampleFacilities().First();
        }
    }
}
