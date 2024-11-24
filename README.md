## General 
This project is created to solve task in recruitment process.

## Architecture
This solution is build from 3 components:

- ASP.NET CORE API application
- Azure Cache for Redis
- API Management service

## How to run
To run application you need to configure Redis Cache and copy connection string.
Set Evn: REDISCACHECONNSTR_Redis to Redis connection string.
Run app from repository.

## Test env

You can test fully configured app hosted in Azure:

Api URL: https://arturadamek.azure-api.net/HackerNews/GetBestNews?n=1
Set header - Ocp-Apim-Subscription-Key with subscription id: c696967ba0d04680bfe3f31f32a30fcc