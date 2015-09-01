using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;
using System.Collections.Generic;
using System.Text;

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
        public void FindExistingOrGenerateAdditionalProfileReferences()
        {
            var id = repository.FindProfileId(profileReference);
            if (id == new Guid())
                id = repository.GenerateNewProfileId(profileReference);

            string profileLocalReferenceUrl = "localhost";
            var resultLocalUrl = repository.FindProfileId(profileLocalReferenceUrl);
            if (resultLocalUrl == new Guid())
            {
                repository.SaveProfileReference(new ProfileReference { ReferenceValue = profileLocalReferenceUrl, ProfileId = id });
                resultLocalUrl = repository.FindProfileId(profileLocalReferenceUrl);
            }
            string profileReferenceUrl = "michaelquinn.azurewebsites.net";
            var resultUrl = repository.FindProfileId(profileReferenceUrl);
            if (resultUrl == new Guid())
            {
                repository.SaveProfileReference(new ProfileReference { ReferenceValue = profileReferenceUrl, ProfileId = id });
                resultUrl = repository.FindProfileId(profileReferenceUrl);
            }
            Assert.AreNotEqual(resultLocalUrl, new Guid());
            Assert.AreNotEqual(resultUrl, new Guid());
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
                        Priority = 1,
                        Category = "Languages",
                        ToolsCsv = "C#.NET, VB.NET, ASP.NET, Razor, T-SQL, Linq, HTML, JavaScript, CSS, JSON, XML, PowerShell, ASP, VB6, Java"
                    },
                    new TechnicalApplication
                    {
                        Priority = 2,
                        Category = "Frameworks",
                        ToolsCsv = ".NET 1.1 - 4.5.2, MVC 2-5, WCF, Web API 2, Entity Framework, NHibernate, NPoco, AJAX, jQuery, AngularJS, KnockoutJS, Bootstrap, SignalR, OWIN, Rhino Mocks, Unity, Autofac, SLAB, ETW"
                    },
                    new TechnicalApplication
                    {
                        Priority = 3,
                        Category = "Tools",
                        ToolsCsv = "Visual Studio, SQL Server, DB2 Connect, IIS, TFS, NServiceBus, MS Test, VS Load Test, MongoDB, Visual Build, Quick Build, CC Tray, NuGet, SSIS, DTS, Ektron CMS, SSRS, RavenDB, Star Team, Build Forge"
                    }
                },
                Proficiencies = new List<Proficiency>
                {
                    new Proficiency
                    {
                        Priority = 1,
                        Name = "UI",
                        Percentage = 75
                    },
                    new Proficiency
                    {
                        Priority = 2,
                        Name = "Integration",
                        Percentage = 90
                    },
                    new Proficiency
                    {
                        Priority = 3,
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
                        Priority = 1,
                        ExperienceDetails = GetCompanyExperienceDetails("Nelnet Diversified Solutions")
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
                        Priority = 2,
                        ExperienceDetails = GetCompanyExperienceDetails("5280 Solutions")
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
                        Priority = 3,
                        ExperienceDetails = GetCompanyExperienceDetails("MetLife")
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
                        Priority = 4,
                        ExperienceDetails = GetCompanyExperienceDetails("Clayton Holdings")
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
                        Priority = 5,
                        ExperienceDetails = GetCompanyExperienceDetails("Sports Authority Corporate")
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
                        Priority = 6,
                        ExperienceDetails = GetCompanyExperienceDetails("University of Colorado")
                    }
                }
            };
            repository.SaveProfile(profile);
            var queriedProfile = repository.GetProfile(profileId);
            Assert.AreEqual(profile.ProfileId, queriedProfile.ProfileId);
        }

        private static string GetCompanyExperienceDetails(string companyName)
        {
            var details = new StringBuilder();
            switch (companyName)
            {
                case "Nelnet Diversified Solutions":
                    details.AppendLine("•	Collaboratively leading the development on new and existing systems using Domain Driven, Event Based, SOA, and CQRS architectures.");
                    details.AppendLine("•	Migrating company from SOAP to REST web services using Web API 2.");
                    details.AppendLine("•	Driving development efforts on enterprise service bus using NServiceBus and MSMQ.");
                    details.AppendLine("•	Built out of process cache service using MongoDB.");
                    details.AppendLine("•	Guiding company web standards towards MVVM and MVW with AngularJs, Web API, and SignalR.");
                    details.AppendLine("•	Created robust logging solution using Semantic Logging and ETW");
                    details.AppendLine("•	DB2 Interop using DB Connect and NPoco");
                    details.AppendLine("•	Prototyped apps with the SPA template in MVC5, KnockoutJS, AngularJS, SignalR, Web API 2, OData, RavenDB, MongoDB, Cassandra, NServiceBus, EF Code First.");
                    details.AppendLine("•	Estimate, design, develop, review, migrate, test, and document solutions.");
                    details.AppendLine("•	Performance tune and load test applications with memory and performance problems.");
                    details.AppendLine("•	Delivering software using Agile methodologies.");
                    details.AppendLine("•	Managed team of developers as the Web Platforms’ Client Experience team.");
                    details.AppendLine("•	TFS administration for merging, branching, and deploying code.");
                    break;
                case "5280 Solutions":
                    details.AppendLine("•	Develop new UIs using MVC, MVP and Web Forms.");  
                    details.AppendLine("•	Use Entity Framework to create Data Models and T4 Templates to generate POCOs and repositories.");
                    details.AppendLine("•	Use Linq queries to extract and translate data for business objects.");
                    details.AppendLine("•	Develop custom attributes and common membership, role, and event providers.");
                    details.AppendLine("•	WCF service development and configuration.");
                    details.AppendLine("•	Write unit test methods using MS Test with Rhino Mocks and load tests using VS Load Test.");
                    details.AppendLine("•	Design new and extend existing SQL Server databases.");
                    details.AppendLine("•	Configure and setup sites and services using IIS.");
                    break;
                case "MetLife":
                    details.AppendLine("•	Created new and enhanced existing web forms, user controls, and client side validations using ASP.NET, Java Script, CSS, and AJAX.");
                    details.AppendLine("•	Wrote view helpers, business logic layers, and strategy classes in C#.NET.");
                    details.AppendLine("•	Developed data access layers using Enterprise Library.");
                    details.AppendLine("•	XSD Schema upgrades and web service enhancements on SOA.");
                    details.AppendLine("•	Coded SQL Server components: stored procedures, views, tables, and indexes.");
                    details.AppendLine("•	Designed and coded new shells and frameworks for console and web apps.");
                    details.AppendLine("•	Setup and configured IIS 5, IIS 6, and virtual SMTP for new applications.");
                    break;
                case "Clayton Holdings":
                    details.AppendLine("•	Designed and developed fully automated ETL processes using SSIS and VB.NET. Used SQL Server 2005 APIs to code programmatic data flow tasks.");
                    details.AppendLine("•	Performance tuned SQL Server databases, SSIS packages, and upgraded DTS packages to SSIS.");
                    details.AppendLine("•	Designed new data loading and reporting services for international and external clients.");
                    details.AppendLine("•	Contributed to the team’s collaborative development effort on a web app queuing system using ASP.NET with VB.NET.Later participated in the n -Tier C#.NET re-write of this app.");
                    break;
                case "Sports Authority Corporate":
                    details.AppendLine("•	Monitored and supported 392 LANs consisting of a Cisco 1700 router, multiple switches and hubs all used to network the 7 store VPN computers, 10 - 20 fat client NCR or thin client IBM POS systems, and the IBM e-serve controller.");
                    details.AppendLine("•	Provided desktop and network support for over 600 corporate users.");
                    details.AppendLine("•	Assisted application group in the broadcasting, testing and troubleshooting of newly developed applications.");
                    details.AppendLine("•	Worked with the Database group to enhance and test our Oracle backend during new production releases.");
                    details.AppendLine("•	Designed, normalized and loaded database for corporate employee contact information using MS Access.");
                    break;
                case "University of Colorado":
                    details.AppendLine("•	Graduated with B.S., Information Systems Management");
                    details.AppendLine("•	Built E Commerce web application using .NET 1.1, C#, SQL, HTML, DHTML, Java Script, XML, and XSLT for .NET graduate level course.");
                    details.AppendLine("•	Took courses on C and C++");
                    details.AppendLine("•	Built Java modules using J Developer for Java course");
                    details.AppendLine("•	Courses on database focusing on TSQL, PL / SQL, and database normalization.");
                    details.AppendLine("•	Networking course using Cisco and Intel hardware");
                    details.AppendLine("•	Built academic informational site for University on China’s 3 Gorges Dam project using HTML");
                    details.AppendLine("•	General Business Administration core curriculum: Finance, Account, Management, Business Law etc.");
                    details.AppendLine("•	General common core classes");
                    break;
                default:
                    details.AppendLine("No details available");
                    break;
            }
            return details.ToString();
        }
    }
}
