<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>
 
# K Donation Portal

[![Actions Status](https://github.com/twilio-labs/sample-template-nodejs/workflows/Node%20CI/badge.svg)](https://github.com/twilio-labs/sample-appointment-reminders/actions)

## About

Twilio - Hackathon Event in that held in DEV.TO.
This is about a donation e-website for people to make purchase and keep track on the donation items. 

Implementations in other languages:

.NET  - Blazor (C#)

### How it works

This is an application that using .NetCore 3.1 with Blazor. 

## Features

- Can donation according to the selection and quantity.
- Able to keep track the donation.

## How to use it

1. Create a copy using [GitHub's repository template](https://github.com/homeyong/Kdonationportal) 
2. Install SQL LocalDB
3. Open the project and navigate to src/NetLearner.Blazor
4. Execute command dotnet build  - to build the application.
5. Execute command dotnet run


## Set up

### Requirements

- Install SQL LocalDB
- Install .NetCore 3.1 (https://dotnet.microsoft.com/download/dotnet-core)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)

### Twilio Account Settings

This application should give you a ready-made starting point and setup Whatapps SandBox.
Before we begin, we need to collect all the config values we need to run the application:
After you have the TWILIO_ACCOUNT_SID and TWILIO_AUTH_TOKEN, please set up according the link below:
https://www.twilio.com/blog/2017/01/how-to-set-environment-variables.html

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
cd src/netlearner.blazor
dotnet build

```
2. Set your environment variables

See [Twilio Account Settings](#twilio-account-settings) to locate the necessary environment variables.

4. Run the application

```bash
dotnet run
```
```bash
npm run dev
```

5. Navigate to [http://localhost:5001](http://localhost:5001)

That's it!
## Resources

- [GitHub's K Donation Portal](https://github.com/homeyong/Kdonationportal) functionality

## Contributing

This template is open source and welcomes contributions. All contributions are subject to our [Code of Conduct](https://github.com/twilio-labs/.github/blob/master/CODE_OF_CONDUCT.md).

[Visit the project on GitHub](https://github.com/twilio-labs/sample-template-nodejs)

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com