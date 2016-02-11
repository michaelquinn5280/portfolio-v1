import {
  GraphQLEnumType,
  GraphQLInterfaceType,
  GraphQLObjectType,
  GraphQLList,
  GraphQLNonNull,
  GraphQLSchema,
  GraphQLString,
  GraphQLInt,
  GraphQLID,
} from 'graphql';

//import { getPortfolio, getContactInfo, getContactAttempts, getGreeting, getSiteInfo, getLegal, getProfile, getProjects } from './data/portfolioServiceProxyMock.js';
import { getPortfolio, getContactInfo, getContactAttempts, getGreeting, getSiteInfo, getLegal, getProfile, getProjects } from './data/portfolioServiceProxy.js';

var projectType = new GraphQLObjectType( {
    name: 'Project',
    fields: () => ({
        Id: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        Title: { type: GraphQLString },
        Description: { type: GraphQLString },
        StartDate: { type: GraphQLString },
        EndDate: { type: GraphQLString },
        Priority: { type: GraphQLInt }
    })
});

var technicalApplicationType = new GraphQLObjectType( {
    name: 'TechnicalApplication',
    fields: () => ({
        Priority: { type: GraphQLInt },
        Category: { type: GraphQLString },
        ToolsCsv: { type: GraphQLString }
    })
});

var proficiencyType = new GraphQLObjectType({
    name: 'Proficiency',
    fields: () => ({
        Priority: { type: GraphQLInt },
        Name: { type: GraphQLString },
        Percentage: { type: GraphQLInt }
    })
});

var companyType = new GraphQLObjectType({
    name: 'Company',
    fields: () => ({
        Name: { type: GraphQLString },
        Description: { type: GraphQLString },
        Details: { type: GraphQLString },
        ImagePath: { type: GraphQLString },
        CompanyUrl: { type: GraphQLString },
        StartDate: { type: GraphQLString },
        EndDate: { type: GraphQLString },
        City: { type: GraphQLString },
        State: { type: GraphQLString },
        Country: { type: GraphQLString },
        Priority: { type: GraphQLString },
        ExperienceDetails: { type: new GraphQLList(GraphQLString) }
    })
});

var profileType = new GraphQLObjectType( {
    name: 'Profile',
    fields: () => ({
        Id: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        ProfileImagePath: { type: GraphQLString },
        Name: { type: GraphQLString },
        Summary: { type: GraphQLString },
        Applications: { type: new GraphQLList(technicalApplicationType) },
        Proficiencies: { type: new GraphQLList(proficiencyType) },
        EmployerSummary: { type: GraphQLString },
        Employers: { type: new GraphQLList(companyType) }
    })
});

var siteInfoType = new GraphQLObjectType({
    name: 'SiteInfo',
    fields: () => ({
        Id: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        Theme: { type: GraphQLString },
        Title: { type: GraphQLString },
        Description: { type: GraphQLString }
    })
});

var greetingType = new GraphQLObjectType({
    name: 'Greeting',
    description: 'Greeting',
    fields: () => ({
        Id: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        GreetingTitle: { type: GraphQLString },
        GreetingMessage: { type: GraphQLString },
        SiteInfo: { type: GraphQLString}
    })
});

var contactInfoType = new GraphQLObjectType({
  name: 'ContactInfo',
  description: 'Contact Info',
  fields: () => ({
    Id: { type: GraphQLString },
    ProfileId: { type: GraphQLString },
    ContactMessage: { type: GraphQLString },
    ContactInstructions: { type: GraphQLString },
    EmailAddress: { type: GraphQLString },
    City: { type: GraphQLString },
    State: { type: GraphQLString },
    Zip: { type: GraphQLString }
  })
});

var portfolioType = new GraphQLObjectType({
    name: 'Portfolio',
    description: 'Portfolio',
    fields: () => ({
        Id: { type: GraphQLString },
        ReferenceValue: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        ContactInfo: {
            type: contactInfoType,
            resolve: portfolio => getContactInfo(portfolio.ProfileId)
        },
        Greeting: {
            type: greetingType,
            resolve: portfolio => getGreeting(portfolio.ProfileId)
        },
        SiteInfo: {
            type: siteInfoType,
            resolve: portfolio => getSiteInfo(portfolio.ProfileId)
        },
        Profile: {
            type: profileType,
            resolve: portfolio => getProfile(portfolio.ProfileId)
        },
        Projects: {
            type: new GraphQLList(projectType),
            resolve: portfolio => getProjects(portfolio.ProfileId)
        }
    })
});

var contactAttemptType = new GraphQLObjectType({
    name: 'ContactAttempt',
    fields: () => ({
        Id: { type: GraphQLString },
        ProfileId: { type: GraphQLString },
        Name: { type: GraphQLString },
        EmailAddress: { type: GraphQLString },
        Subject: { type: GraphQLString },
        Message: { type: GraphQLString }
    })
});

var copyrightType = new GraphQLObjectType({
    name: 'Copyright',
    fields: () => ({
        CompanyName: { type: GraphQLString },
        CopyrightStartYear: { type: GraphQLString },
        CopyrightEndYear: { type: GraphQLString }
    })
});

var queryType = new GraphQLObjectType({
    name: 'Query',
    fields: () => ({
        Portfolio: {
          type: portfolioType,
          args: {
              reference: {
                description: 'Lookup value of portfolio',
                type: new GraphQLNonNull(GraphQLString)
            }
          },
          resolve: (root, { reference }) => getPortfolio(reference),
        },
        ContactAttempts: {
            type: new GraphQLList(contactAttemptType),
            args: {
                profileId: {
                    description: 'Profile Id',
                    type: new GraphQLNonNull(GraphQLString)
                }
            },
            resolve: (root, { profileId }) => getContactAttempts(profileId),
        },
        Copyright: {
            type: copyrightType,
            args: {
                profileId: {
                    description: 'Profile Id',
                    type: new GraphQLNonNull(GraphQLString)
                }
            },
            resolve: (root, { profileId }) => getLegal(profileId),
        },
    })
});

export var PortfolioSchema = new GraphQLSchema({
  query: queryType
});
