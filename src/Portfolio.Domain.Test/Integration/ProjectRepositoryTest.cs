using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Domain.Entities;
using System.Linq;

namespace Portfolio.Domain.Test.Integration
{
    /// <summary>
    /// Summary description for ProjectRepositoryTest
    /// </summary>
    [TestClass]
    public class ProjectRepositoryTest
    {
        private ProfileRepository profileRepository = new ProfileRepository();
        private ProjectRepository projectRepository = new ProjectRepository();
        private readonly string profileReference = "michaelquinn5280@gmail.com";
        private static int _projectPriority;

        [TestMethod]
        public void CreateNewProjects()
        {
            var profileId = profileRepository.FindProfileId(profileReference);
            projectRepository.DeleteProjects(profileId);
            var projects = new List<Project>
            {
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Workspace Authorization",
                    Description = "Application authorization with Open ID Connect and OAuth 2 using Identity Server 3.",
                    StartDate = DateTime.Parse("2016-03-01"),
                    EndDate = DateTime.Parse("2016-05-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "External Client Single Sign-on",
                    Description = "SAML based single sign-on authentication using Ping One and Ping Federate.",
                    StartDate = DateTime.Parse("2015-08-01"),
                    EndDate = DateTime.Parse("2016-04-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Payment System Proof of Concept",
                    Description = "Used Bootstrap, Angular, Web APIs, and EF to demonstrate a core system that can be easily extended to support new business verticals.",
                    StartDate = DateTime.Parse("2015-10-01"),
                    EndDate = DateTime.Parse("2016-01-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Performance Metrics ETL Process",
                    Description = "Generates near real time Beacon framework performance metrics from logged SLAB events using SSIS.",
                    StartDate = DateTime.Parse("2015-08-01"),
                    EndDate = DateTime.Parse("2015-11-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Out of Process Caching Solution",
                    Description = "Document database caching solution using MongoDB.",
                    StartDate = DateTime.Parse("2015-04-01"),
                    EndDate = DateTime.Parse("2015-10-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Enterprise Service Bus",
                    Description = "Created ESB using NServiceBus, MSMQ, and SQL Server persistence.",
                    StartDate = DateTime.Parse("2014-11-01"),
                    EndDate = DateTime.Parse("2015-09-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "REST Web Services",
                    Description = "Transitioned web services from WCF SOAP to REST using .NET Web API 2.",
                    StartDate = DateTime.Parse("2014-11-01"),
                    EndDate = DateTime.Parse("2015-09-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Workspace Call Center Application",
                    Description = "Used Bootstrap, AngularJs, SignalR, and Web API 2 to create a web application that provides loan servicing functionality to thousands of call center reps.",
                    StartDate = DateTime.Parse("2014-06-01"),
                    EndDate = DateTime.Parse("2015-07-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Data Virtualization Strategy",
                    Description = "Used a Unity service locator pattern with TPL to aggregate data for reads, and publish and subscribe for writes.",
                    StartDate = DateTime.Parse("2014-06-01"),
                    EndDate = DateTime.Parse("2014-11-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Software Architect - NDS Technical Initiatives Team",
                    Description = "Transitioned to new enterprise team at Nelnet dedicated to evaluating and prototyping technology new to the organization.",
                    StartDate = DateTime.Parse("2014-11-01"),
                    EndDate = DateTime.Parse("2014-11-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Beacon Research and Development",
                    Description = "Prototyped potential system solutions using KnockoutJS with the Single Page Application template in MVC5, SignalR, Web API 2, OData, RavenDB, MongoDB, Cassandra, NServiceBus, and EF Code First.",
                    StartDate = DateTime.Parse("2013-11-01"),
                    EndDate = DateTime.Parse("2014-06-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "secure.disabilitydischarge.com Rewrite",
                    Description = "Re-designed site to support regulatory changes, improved UX, and converted from MVP to MVC4.",
                    StartDate = DateTime.Parse("2013-04-01"),
                    EndDate = DateTime.Parse("2014-04-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Web Service API for IVR Systems",
                    Description = "WCF and Cryptography were used to expose read / write functionality to internal and external IVR systems.",
                    StartDate = DateTime.Parse("2013-01-01"),
                    EndDate = DateTime.Parse("2013-07-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Client Manager Branding Application",
                    Description = "Used MVC3 and Entity Framework to create a custom content and configuration management application to administer the branding of multi-tenant applications.",
                    StartDate = DateTime.Parse("2012-02-01"),
                    EndDate = DateTime.Parse("2013-10-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Team Lead on Web Platforms Client Experience Team",
                    Description = "Development team dedicated to multi-tenant setup and support.",
                    StartDate = DateTime.Parse("2012-04-01"),
                    EndDate = DateTime.Parse("2012-11-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Software Architect - NDS Web Platforms Team",
                    Description = "Nelnet's .NET web application team.",
                    StartDate = DateTime.Parse("2012-04-01"),
                    EndDate = DateTime.Parse("2012-04-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Two-Factor Authentication Service",
                    Description = "Exposed Symantec / VeriSign multi-factor authentication through WCF services.",
                    StartDate = DateTime.Parse("2012-12-01"),
                    EndDate = DateTime.Parse("2013-03-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Federal Student Aid (FSA) and School Portal Web Application",
                    Description = "Web Forms application with Entity Framework and SQL Server that aggregates borrower data across systems for FSA and college administrators.",
                    StartDate = DateTime.Parse("2011-10-01"),
                    EndDate = DateTime.Parse("2012-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Multi-tenant Web Applications",
                    Description = "Converted existing applications to support a SaaS offering to external student loan servicers.",
                    StartDate = DateTime.Parse("2011-04-01"),
                    EndDate = DateTime.Parse("2012-11-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Manage My Account Impersonation",
                    Description = "Added an impersonation feature giving Customer Service Reps the ability to view what borrowers are viewing on our public facing self-service site.",
                    StartDate = DateTime.Parse("2011-09-01"),
                    EndDate = DateTime.Parse("2012-04-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Manage My Account Rewrite",
                    Description = "Complete rewrite and redesign of borrower self-service web application for more than 10 million borrowers.  Web forms, jQuery, CSS3, WCF, and Entity Framework and SQL Server.",
                    StartDate = DateTime.Parse("2011-02-01"),
                    EndDate = DateTime.Parse("2011-09-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "CSR Payment and Web Admin Portal",
                    Description = "Model View Presenter (MVP) web forms application, WCF web services, Entity Framework, and SQL Server.  Payment and web security administration portal for Customer Service Reps.",
                    StartDate = DateTime.Parse("2010-10-01"),
                    EndDate = DateTime.Parse("2011-02-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "www.disabilitydischarge.com",
                    Description = "New system built to support servicing of disability based student loan debt forgiveness by the Department of Education.  Public site is a content management system built with Ektron, secure site was a web forms application built using the MVP pattern, WCF web services and Entity Framework.",
                    StartDate = DateTime.Parse("2010-05-01"),
                    EndDate = DateTime.Parse("2010-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Software Developer - NDS Web Platforms Team",
                    Description = ".NET application developer at Nelnet / 5280 Solutions",
                    StartDate = DateTime.Parse("2010-04-01"),
                    EndDate = DateTime.Parse("2010-04-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Web Service Schema Upgrades",
                    Description = "ACORD XSD Schema Upgrades for public and private facing web services.",
                    StartDate = DateTime.Parse("2009-12-01"),
                    EndDate = DateTime.Parse("2010-05-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Enterprise Fund Administration Enhancements",
                    Description = "Extended functionality of Fund Trading system.  ASP.Net application that front ends DB2 fund trading source system.",
                    StartDate = DateTime.Parse("2009-02-01"),
                    EndDate = DateTime.Parse("2009-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Smart App Enhancements",
                    Description = "On going feature enhancements on Broker / Business annuinty adminstration web application.",
                    StartDate = DateTime.Parse("2008-10-01"),
                    EndDate = DateTime.Parse("2009-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Systematic Withdrawal Program in Smart App",
                    Description = "Program within Smart App that uses actuarial tables to calculate when annuity holders are required to start withdrawing funds.",
                    StartDate = DateTime.Parse("2008-02-01"),
                    EndDate = DateTime.Parse("2008-10-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Batch Correspondence System Conversion",
                    Description = "Converted legacy correspondence applications from vb6 to a centralized C#.NET console application.",
                    StartDate = DateTime.Parse("2007-05-01"),
                    EndDate = DateTime.Parse("2008-02-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Software Developer - MetLife",
                    Description = ".NET application development on MetLife's US Annuities platforms",
                    StartDate = DateTime.Parse("2007-04-01"),
                    EndDate = DateTime.Parse("2007-04-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "www.michaelandmaki.com",
                    Description = "Built wedding website with asp.net to provide wedding information in both English and Japanese, and manage photo collections for the attending guests.",
                    StartDate = DateTime.Parse("2006-06-01"),
                    EndDate = DateTime.Parse("2007-08-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "CFIS High Risk Reporting",
                    Description = "Used SSRS to create reports based on electronic re-underwriting data to flag loans in portfolios with high default risk.",
                    StartDate = DateTime.Parse("2006-02-01"),
                    EndDate = DateTime.Parse("2007-02-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Collateral Assets Workflow Application",
                    Description = "Web forms workflow application used to queue Due Diligence tape cracking requests and report team performance metrics.",
                    StartDate = DateTime.Parse("2006-01-01"),
                    EndDate = DateTime.Parse("2006-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "ETL Loan Origination and Servicing Data",
                    Description = "ETL loan origination and servicing data using SSIS and .NET Dts90 APIs.",
                    StartDate = DateTime.Parse("2005-12-01"),
                    EndDate = DateTime.Parse("2006-12-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Software Developer - Clayton Holdings",
                    Description = ".NET application development and ETL for Due Diligence segment.",
                    StartDate = DateTime.Parse("2005-11-01"),
                    EndDate = DateTime.Parse("2005-11-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "IT Support Technician - The Sports Authority",
                    Description = "Network troubleshooting for corporate and stores, desktop support for business, iSeries account administration.",
                    StartDate = DateTime.Parse("2005-01-01"),
                    EndDate = DateTime.Parse("2005-01-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Graduated Information Systems - University of Colorado at Denver",
                    Description = "B.S. Business Administration Information Systems",
                    StartDate = DateTime.Parse("2004-12-01"),
                    EndDate = DateTime.Parse("2004-12-01"),
                    Priority = GetPriority(),
                    Milestone = true
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Ecommerce Site Class Project",
                    Description = "Build a fully functional .NET 1.1 Ecommerce site for class project.",
                    StartDate = DateTime.Parse("2004-08-01"),
                    EndDate = DateTime.Parse("2004-11-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Three Gorges Dam Informational Site",
                    Description = "Static HTML information site hosted by University of Colorado to provide information on the Three Gorges Dam project in China.",
                    StartDate = DateTime.Parse("2001-01-01"),
                    EndDate = DateTime.Parse("2001-06-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
                new Project
                {
                    Id = string.Empty,
                    ProfileId = profileId,
                    Title = "Studied Information Systems - University of Colorado at Denver",
                    Description = "Studied C, C++, Java, Networking, Database, and .NET 1.1 Web Development",
                    StartDate = DateTime.Parse("2000-08-01"),
                    EndDate = DateTime.Parse("2000-08-01"),
                    Priority = GetPriority(),
                    Milestone = false
                },
            };
            projectRepository.SaveProjects(projects);
            var results = projectRepository.GetProjects(profileId);
            Assert.AreEqual(profileId, results.FirstOrDefault().ProfileId);
        }

        private int GetPriority()
        {
            _projectPriority = _projectPriority + 1;
            return _projectPriority;
        }
    }
}
