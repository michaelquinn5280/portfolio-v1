using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;
using System.Collections.Generic;

namespace Portfolio.Domain.Test.Integration
{
    [TestClass]
    public class ProfileRepositoryTests
    {
        private ProfileRepository repository = new ProfileRepository();
        private readonly string profileReference = "michaelquinn5280@gmail.com";

        [TestMethod]
        public void FindExistingOrGenerateNewProfileId()
        {
            var id = repository.FindProfileId(profileReference);
            if (id == new Guid())
                id = repository.GenerateNewProfileId(profileReference);
            Assert.AreNotEqual(id, new Guid());
        }

        [TestMethod]
        public void CreateNewProfile()
        {
            var profileId = repository.FindProfileId(profileReference);
            repository.DeleteProfile(profileId);
            var profile = new Profile
            {
                Id = string.Empty,
                ProfileId = profileId,
                Name = "Michael Quinn",
                ProfileImagePath = "img/profile-picture-me.jpg",
                Summary = "Software professional with background in web application and web service development, SOA, object-oriented programming, database, ETL, and networking.  Great success with building systems to support complex business processes in student loan, annuity, mortgage, and retail industries.",
                Applications = new List<TechnicalApplication>
                {
                    new TechnicalApplication
                    {
                        Order = 1,
                        Category = "Languages",
                        ToolsCsv = "C#.NET, VB.NET, ASP.NET, Razor, T-SQL, Linq, HTML, JavaScript, CSS, JSON, XML, PowerShell, ASP, VB6, Java"
                    },
                    new TechnicalApplication
                    {
                        Order = 2,
                        Category = "Frameworks",
                        ToolsCsv = ".NET 1.1 - 4.5.2, MVC 2-5, WCF, Web API 2, Entity Framework, NHibernate, NPoco, AJAX, jQuery, AngularJS, KnockoutJS, Bootstrap, SignalR, OWIN, Rhino Mocks, Unity, Autofac, SLAB, ETW"
                    },
                    new TechnicalApplication
                    {
                        Order = 3,
                        Category = "Tools",
                        ToolsCsv = "Visual Studio, SQL Server, DB2 Connect, IIS, TFS, NServiceBus, MS Test, VS Load Test, MongoDB, Visual Build, Quick Build, CC Tray, NuGet, SSIS, DTS, Ektron CMS, SSRS, RavenDB, Star Team, Build Forge"
                    }
                },
                Proficiencies = new List<Proficiency>
                {
                    new Proficiency
                    {
                        Order = 1,
                        Name = "UI",
                        Percentage = 75
                    },
                    new Proficiency
                    {
                        Order = 2,
                        Name = "Integration",
                        Percentage = 90
                    },
                    new Proficiency
                    {
                        Order = 3,
                        Name = "Data",
                        Percentage = 80
                    }
                },
                EmployerSummary = "I've worked for number of good companies over the past decade, but more importantly I have worked with some amazing people who have helped me grow into the developer I am today.",
                Employers = new List<Company>
                {
                    new Company
                    {
                        Name = "Nelnet Diversified Solutions",
                        Description = "Title IV student loan servicer for the Department of Education and FSA.",
                        ImagePath = "img/companies/nelnetlogo.jpg",
                        CompanyUrl = "http://www.n-d-s.com/",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Remote from Irvine",
                        State = "CA",
                        Country = "USA",
                        Order = 1
                    },
                    new Company
                    {
                        Name = "5280 Solutions",
                        Description = "IT service provider for Nelnet.",
                        ImagePath = "img/companies/5280solutionslogo.jpg",
                        CompanyUrl = "http://www.5280solutions.com/",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Highlands Ranch",
                        State = "CO",
                        Country = "USA",
                        Order = 2
                    },
                    new Company
                    {
                        Name = "MetLife",
                        Description = "US annuities line of business.",
                        ImagePath = "img/companies/metlifelogo.jpg",
                        CompanyUrl = "https://www.metlife.com/individual/investment-products/index.html?WT.ac=GN_individual_investment-products",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Denver",
                        State = "CO",
                        Country = "USA",
                        Order = 3
                    },
                    new Company
                    {
                        Name = "Clayton Holdings",
                        Description = "Mortgage-backed securities due diligence.",
                        ImagePath = "img/companies/claytonlogo.jpg",
                        CompanyUrl = "http://www.clayton.com/",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Denver",
                        State = "CO",
                        Country = "USA",
                        Order = 4
                    },
                    new Company
                    {
                        Name = "Sports Authority Corporate",
                        Description = "Corporate offices.",
                        ImagePath = "img/companies/sportsauthoritylogo.jpg",
                        CompanyUrl = "http://www.sportsauthority.com/corp/",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Englewood",
                        State = "CO",
                        Country = "USA",
                        Order = 5
                    },
                    new Company
                    {
                        Name = "University of Colorado",
                        Description = "B.S. Business Administration and Information Systems.",
                        ImagePath = "img/companies/cubuilding.jpg",
                        CompanyUrl = "http://www.ucdenver.edu/academics/colleges/business/degrees/bachelor/Pages/Information-Systems.aspx",
                        StartDate = new DateTime(),
                        EndDate = new DateTime(),
                        City = "Denver",
                        State = "CO",
                        Country = "USA",
                        Order = 6
                    }
                }
            };
            repository.SaveProfile(profile);
            var queriedProfile = repository.GetProfile(profileId);
            Assert.AreEqual(profile.ProfileId, queriedProfile.ProfileId);
        }
    }
}
