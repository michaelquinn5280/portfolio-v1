# graphql cv portfolio server with graphiql
GraphQL endpoint proxy for rest services 
========================

1. Run 'npm install' in root directory
2. 'npm start'
3. Run test queries in GraphiQL at root url: http://localhost:8080/
----------------------------------------------------------------------------------------------
{
    ContactAttempts(profileId: "5605d7bf-ecd0-4c05-b481-514d8b830bfa") { 
        Id,
        ProfileId,
        Name,
        EmailAddress,
    	Subject,
        Message
	}
}
----------------------------------------------------------------------------------------------
{
     Portfolio(reference: "michaelquinn.azurewebsites.net") { 
		ReferenceValue
		ProfileId,
		ContactInfo {
			ContactMessage,
			ContactInstructions,
			EmailAddress,
			City,
			State,
			Zip
		},
		Greeting {
			GreetingTitle,
			GreetingMessage,
			SiteInfo
		},
		SiteInfo {
			Theme,
			Title,
			Description
		},
		Profile {
			ProfileImagePath,
			Name,
			Summary,
			Applications {
				Category,
				ToolsCsv
			},
			Proficiencies {
				Name,
				Percentage
			},
			EmployerSummary,
			Employers {
				Name,
				ExperienceDetails
			}
		}
	}
}
----------------------------------------------------------------------------------------------
4. Open your browser to http://localhost:8080/schema to view schema.
