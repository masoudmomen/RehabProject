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
        public static List<FacilityCardViewmodel> GetSampleFacilities()
        {
            return new List<FacilityCardViewmodel>
            {
                new FacilityCardViewmodel
                {
                    Id = 1,
                    Name = "Serene Gardens ReCardImagey",

                    Address = "31365 Monterey St",

                    Logo = "img/FacilitiesSample/logo1.png",
                    CardImage = "img/FacilitiesSample/1.jpg",

                    Slug = "serene-gardens-reCardImagey",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5
                },
                new FacilityCardViewmodel
                {
                    Id = 2,
                    Name = "Mountain View Wellness",
                 
 
                    Address = "789 Pine Ridge Dr",
                   
                    Logo = "img/FacilitiesSample/logo2.png",
                    CardImage = "img/FacilitiesSample/2.jpg",
                   
                    Slug = "mountain-view-wellness",
                       InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5
                },
                new FacilityCardViewmodel
                {
                    Id = 3,
                    Name = "Urban ReCardImagey Center",
                     
                    Address = "456 Broadway Ave",
                   
                    Logo = "img/FacilitiesSample/logo3.png",
                    CardImage = "img/FacilitiesSample/3.jpg",
                 
                    Slug = "urban-reCardImagey-center",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5

                },
                new FacilityCardViewmodel
                {
                    Id = 4,
                    Name = "Urban ReCardImagey Center",

                    Address = "456 Broadway Ave",

                    Logo = "img/FacilitiesSample/logo3.png",
                    CardImage = "img/FacilitiesSample/3.jpg",

                    Slug = "urban-reCardImagey-center",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5

                }
                ,
                new FacilityCardViewmodel
                {
                    Id = 5,
                    Name = "Urban ReCardImagey Center",

                    Address = "456 Broadway Ave",

                    Logo = "img/FacilitiesSample/logo3.png",
                    CardImage = "img/FacilitiesSample/3.jpg",

                    Slug = "urban-reCardImagey-center",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5

                }
                ,
                new FacilityCardViewmodel
                {
                    Id = 6,
                    Name = "Urban ReCardImagey Center",

                    Address = "456 Broadway Ave",

                    Logo = "img/FacilitiesSample/logo3.png",
                    CardImage = "img/FacilitiesSample/3.jpg",

                    Slug = "urban-reCardImagey-center",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5

                }
                ,
                new FacilityCardViewmodel
                {
                    Id = 7,
                    Name = "Urban ReCardImagey Center",

                    Address = "456 Broadway Ave",

                    Logo = "img/FacilitiesSample/logo3.png",
                    CardImage = "img/FacilitiesSample/3.jpg",

                    Slug = "urban-reCardImagey-center",

                    InsuranceCount = 7,
                    AccreditationCount = 4,
                    AmenityCount = 3,
                    HighlightCount = 4,
                    WwtCount = 6,
                    TreatmentCount = 5,
                    ConditionCount = 4,
                    SwtCount = 5

                }
            };
        }

        public static FacilityCardViewmodel GetSampleFacility(int id = 1)
        {
            return GetSampleFacilities().FirstOrDefault(f => f.Id == id) ?? GetSampleFacilities().First();
        }
    }
}
