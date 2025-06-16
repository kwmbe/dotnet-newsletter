# dotnet-newsletter
Small .NET API for newsletters

The API uses [Abstract API](https://www.abstractapi.com/guides/free-email-validation) for email validation. Be sure to copy the `.env.example` file to a file called `.env` add your own API key as value to the `AbstractAPIKey`-key.
After this, use `docker compose up` in the root directory to start both the front- and backend.
