
export function getPortfolio(referenceValue) {
    console.log('Mock getPortfolio called with referenceValue: ', referenceValue);
    var profile = 
 {
        ReferenceValue: "michaelquinn.azurewebsites.net",
        ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
    };
    return profile;
}

export function getContactInfo(profileId) {
    console.log('Mock getContactInfo called with profileId: ', profileId);
    var contactInfo = {
        Id: "56bb8aa03a516352b0a4b4f0",
        ProfileId: profileId,
        ContactMessage: "If you have any interesting technical challenges or unique business opportunities I would love to hear about them.",
        ContactInstructions: "Feel free to use this form to get in touch with me.  If for some reason you have any problems you can also use the email address provided below.",
        EmailAddress: "michaelquinn5280@gmail.com",
        City: "Irvine",
        State: "CA",
        Zip: "92604"
    };
    return contactInfo;
}

export function getContactAttempts(profileId) {
    console.log('Mock getContactAttempt called with profileId: ', profileId);
    var attempts = [
        {
            Id: "56bcc8905d64dc1814be9820",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Name: "Mike Smith",
            EmailAddress: "michaelquinn5280@gmail.com",
            Subject: "Test contact 1",
            Message: "First test contact message"
        },
        {
            Id: "56bcc8b35d64dc1814be9821",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Name: "Jane Doe",
            EmailAddress: "michaelquinn5280@live.com",
            Subject: "Test contact 2",
            Message: "Second contact message"
        },
        {
            Id: "56bcc8ca5d64dc1814be9822",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Name: "Rick Ross",
            EmailAddress: "michaelquinn5280@gmail.com",
            Subject: "Test contact 3",
            Message: "Third test contact message"
        }];
    return attempts;
}

export function getGreeting(profileId) {
    console.log('Mock getGreeting called with profileId: ', profileId);
    var greeting = 
 {
        Id: "56ad51d03a51630460ab5b21",
        ProfileId: profileId,
        GreetingTitle: "Michael Quinn",
        GreetingMessage: "full stack software developer",
        SiteInfo: "Using this site to explore ASP.NET 5, Web API 2.2 in 4.6, Visual Studio 2015, AngularJs, MongoDB.  UI is a Bootstrap wrapper called Cvilized I found on the wrapbootstap.com marketplace. Git source.  Hosted in Azure."
    };
    return greeting;
}

export function getSiteInfo(profileId) {
    console.log('Mock getSiteInfo called with profileId: ', profileId);
    var siteInfo = 
    {
        Id: "56ad51ce3a51630460ab5b1f",
        ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
        Theme: "blue",
        Title: "Michael Quinn - .NET Developer Irvine, CA",
        Description: "Michael Quinn - .NET Developer Irvine, CA"
    };
    return siteInfo;
}

export function getLegal(profileId) {
    console.log('Mock getLegal called with profileId: ', profileId);
    var copyright = 
    {
        CompanyName: "Michael Quinn",
        CopyrightStartYear: 2015,
        CopyrightEndYear: 2016
    };
    return copyright;
}

var applications = [
    {
        Priority: 1,
        Category: "Languages",
        ToolsCsv: "C#.NET, JavaScript, Razor, T-SQL, Linq, HTML, CSS, JSON, XML, PowerShell, Python, ASP.NET, ASP, VB.NET, VB6, Java"
    },
    {
        Priority: 2,
        Category: "Frameworks",
        ToolsCsv: ".NET 1.1 - 5, MVC 2-5, WCF, Web API, Entity Framework, NHibernate, NPoco, AJAX, jQuery, AngularJS, KnockoutJS, Bootstrap, SignalR, OWIN, GraphQL, Rhino Mocks, Unity, Autofac, SLAB, ETW"
    },
    {
        Priority: 3,
        Category: "Tools",
        ToolsCsv: "Visual Studio, SQL Server, DB2 Connect, IIS, TFS, Git, Node, NServiceBus, Azure, AWS, MS Test, VS Load Test, MongoDB, Visual Build, Quick Build, CC Tray, NuGet, SSIS, DTS, Ektron CMS, SSRS, RavenDB, Star Team, Build Forge, Ping Identity"
    }
];

var proficiencies = [
    {
        Priority: 1,
        Name: "UI",
        Percentage: 75
    },
    {
        Priority: 2,
        Name: "Integration",
        Percentage: 85
    },
    {
        Priority: 3,
        Name: "Data",
        Percentage: 80
    }
];

var employers = [
    {
        Name: "Nelnet Diversified Solutions",
        Description: "Title IV student loan servicer for the Department of Education and FSA.",
        Details: null,
        ImagePath: "img/companies/nelnetlogo.jpg",
        CompanyUrl: "http://www.n-d-s.com/",
        StartDate: "0001-01-01T00:00:00Z",
        EndDate: "0001-01-01T00:00:00Z",
        City: "Remote from Irvine",
        State: "CA",
        Country: "USA",
        Priority: 1,
        ExperienceDetails: [
            "Collaboratively leading the development on new and existing systems using Domain Driven, Event Based, SOA, and CQRS architectures.",
            "Migrating company from SOAP to REST web services using Web API 2.",
            "Driving development efforts on enterprise service bus using NServiceBus and MSMQ.",
            "Built out of process cache service using MongoDB.",
            "Guiding company web standards towards MVVM and MVW with AngularJs, Web API, and SignalR.",
            "Created robust logging solution using Semantic Logging and ETW",
            "DB2 Interop using DB Connect and NPoco",
            "Prototyped apps with the SPA template in MVC5, KnockoutJS, AngularJS, SignalR, Web API 2, OData, RavenDB, MongoDB, Cassandra, NServiceBus, EF Code First.",
            "Estimate, design, develop, review, migrate, test, and document solutions.",
            "Performance tune and load test applications with memory and performance problems.",
            "Delivering software using Agile methodologies.",
            "Managed team of developers as the Web Platforms’ Client Experience team.",
            "TFS administration for merging, branching, and deploying code."]
    },
    {
        Name: "5280 Solutions",
        Description: "IT service provider for Nelnet.",
        Details: null,
        ImagePath: "img/companies/5280solutionslogo.jpg",
        CompanyUrl: "http://www.5280solutions.com/",
        StartDate: "0001-01-01T00:00:00Z",
        EndDate: "0001-01-01T00:00:00Z",
        City: "Highlands Ranch",
        State: "CO",
        Country: "USA",
        Priority: 2,
        ExperienceDetails: [
            "Develop new UIs using MVC, MVP and Web Forms.",
            "Use Entity Framework to create Data Models and T4 Templates to generate POCOs and repositories.",
            "Use Linq queries to extract and translate data for business objects.",
            "Develop custom attributes and common membership, role, and event providers.",
            "WCF service development and configuration.",
            "Write unit test methods using MS Test with Rhino Mocks and load tests using VS Load Test.",
            "Design new and extend existing SQL Server databases.",
            "Configure and setup sites and services using IIS."]

    }];

export function getProfile(profileId) {
    console.log('Mock getProfile called with profileId: ', profileId);
    var profile = 
 {
        Id: "56ad51d13a51630460ab5b22",
        ProfileId: profileId,
        ProfileImagePath: "img/profile-picture-me.jpg",
        Name: "Michael Quinn",
        Summary: "Software professional with background in web application and web service development, SOA, object-oriented programming, database, ETL, and networking.  Great success with building systems to support complex business processes in student loan, annuity, mortgage, and retail industries.",
        Applications: applications,
        Proficiencies: proficiencies,
        EmployerSummary: "I've worked for number of good companies over the past decade, but more importantly I have worked with some amazing people who have helped me grow into the developer I am today.",
        Employers: employers
    };
    return profile;
}

export function getProjects(profileId) {
    console.log('Mock getProjects called with profileId: ', profileId);
    var projects = [
        {
            Id: "56ae59933a515520e84b84af",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Title: "Workspace Single Sign-on",
            Description: "SAML based single sign-on authentication for Workspace application using Ping One and Ping Federate.",
            StartDate: "2015-08-01T07:00:00Z",
            EndDate: "2016-02-01T08:00:00Z",
            Priority: 1
        },
        {
            Id: "56ae59933a515520e84b84b0",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Title: "Payment System Proof of Concept",
            Description: "Used Bootstrap, Angular, Web APIs, and EF to demonstrate a core system that can be easily extended to support new business verticals.",
            StartDate: "2015-10-01T07:00:00Z",
            EndDate: "2016-01-01T08:00:00Z",
            Priority: 2
        },
        {
            Id: "56ae59933a515520e84b84b1",
            ProfileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa",
            Title: "Performance Metrics ETL Process",
            Description: "Generates near real time Beacon framework performance metrics from logged SLAB events using SSIS.",
            StartDate: "2015-08-01T07:00:00Z",
            EndDate: "2015-11-01T07:00:00Z",
            Priority: 3
        }];
    return projects;
}