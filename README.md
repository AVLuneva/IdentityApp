# IdentityApp

<br/>

This is the solution for full control of the Identity UI

## Technologies
* [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [SendGrid API](https://sendgrid.com/free/)

## Getting Started
### SendGrid API Configuration
1. Create an account to Twilio SendGrid(https://sendgrid.com/free/)
2. Install the SendGrid NuGet package
`Install-Package SendGrid`
3. Configure SendGrid user secrets
`dotnet user-secrets set SendGridKey <key>`
`dotnet user-secrets set SendGridEmail <key>`
`dotnet user-secrets set SendGridName <key>`
