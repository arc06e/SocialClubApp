# SocialClubApp-ASP.NETCore-MVC-With-EFCore

## Clubhouse
See it up and running: https://socialclubapp20221006112426.azurewebsites.net/

## Description

ClubHouse is an online platform for bringing people together. Whether it's connecting with people in your local community or beyond, ClubHouse provides a simple, easy-to-use interface for scheduling events or establishing clubs with people who share your interests or hobbies.

![SocialClubAppScreenshotResize2](https://user-images.githubusercontent.com/91097715/195120960-f829ab91-f348-4332-8ad7-e87fa7ad5041.jpg)

<!--
## Origin

I built this MVC ASP.NET Core app in .NET 6 in order to better acquaint myself with ASP.NET Core's Identity Framework. Through designing and building this app, I was able to learn about key features of the Identity Framework - such as authentication and authorization - and the ways in which you can restrict user access to parts of the app through assigning roles and claims in order to create a more secure app.
-->

## Current Features

 * Pleasant UI experience:
   * Easy-to-read and clearly defined web pages to help users navigate the application and use its intended features.
   * Utilizes model validation to ensure users receive detailed feedback to promptly resolve any user input errors or other unintended disruptions.
 * CRUD functionality:
   * Allows users to create and manage an account.
   * Ability to establish and maintain clubs.
   *  Ability to schedule and modify events. 
 * Authentication and Authorization (ASP.NET Core Identity):
   * Authenticates users to determine authorization status.
   * Utilizes claim-based authorization to determine which users can access which pages and alter db data.
   * Administrative features for maintaining distribution of registered user claims.   

<!-- * Seeds database with sample data to demonstrate app's key features. -->

## Set-Up Guide
1. Clone project in local directory:
``` git clone arc06e/SocialClubApp-ASP.NETCore-MVC-With-EFCore ```
2. Create local database and add connection string to DefaultConnection in appsettings.json
3. Create free Cloudinary account (https://cloudinary.com/) and add your CloudName, ApiKey, and ApiSecret to appsettings.json 
![appsettings json2](https://user-images.githubusercontent.com/91097715/195206015-50b89802-4b2a-4494-b872-3464d684c13a.jpg)


<!-- 
NEED SECTION ON HOW TO CLONE/FORK APP, CONFIGURE DB, CLOUDINARY, ETC
1. CLONE/FORK
  - CLONE PROJECT
  - *INCLUDE CODE ``` https://github.com/arc06e/SocialClubApp-ASP.NETCore-MVC-With-EFCore.git ```*
2. SET UP LOCAL DB/ADD CONNECTION STRING TO APPSETTINGS
3. CREATE CLOUDINARY ACCOUNT
-->
 
## App Screenshots

| App Login | Clubs Homepage | Create Club | Club Details | Edit Club | Delete Club |
| ------------- | ------------- | --- | --- | --- | --- |
| [![ClubSignInThumb3](https://user-images.githubusercontent.com/91097715/195196601-e83edbcb-048a-400f-8a1c-d4df3b776a6f.jpg)](https://user-images.githubusercontent.com/91097715/195199438-79b7c481-1988-4557-947f-4532a6b48d34.jpg) | [![ClubHomePageThumb](https://user-images.githubusercontent.com/91097715/195196794-60892407-e7eb-441e-bd50-7b5005ecef36.jpg)](https://user-images.githubusercontent.com/91097715/195199712-698e7312-bd27-49a7-80a4-9538225f0f66.jpg) | [![CreateClubThumb](https://user-images.githubusercontent.com/91097715/195197226-e4f315f5-9650-4d08-ab1b-bfc9ae027be4.jpg)](https://user-images.githubusercontent.com/91097715/195199807-0551925a-ae8d-46ea-b125-551cc99673e5.jpg) | [![ReadClubThumb](https://user-images.githubusercontent.com/91097715/195197523-806922a1-1460-478a-be56-b36da0ae9798.jpg)](https://user-images.githubusercontent.com/91097715/195199908-1be8859b-8631-4261-8313-ecbb246e2eb1.jpg) | [![EditClubThumb](https://user-images.githubusercontent.com/91097715/195197723-1172b059-ee77-4f8f-aaf3-3e247cf9ae59.jpg)](https://user-images.githubusercontent.com/91097715/195200026-51fcee5e-fa21-4789-8596-ba7b05c921f7.jpg) | [![DeleteClubThumb](https://user-images.githubusercontent.com/91097715/195197903-f114dbd2-8782-4865-a3d7-7a5c115c1a27.jpg)](https://user-images.githubusercontent.com/91097715/195200111-bb9d9345-6d44-424e-98ee-c408b65e1f96.jpg) |


## Intended Improvements

Going forward, I would like to incorporate search functionality and geolocation features that tailor results presented to the user according to their general area.  Another major feature I would like to add is a commenting system whereby authenicated members can comment on the various clubs and events in order to track updates and other pertinent details. 

<!--
![ClubHouseHomepage](https://user-images.githubusercontent.com/91097715/167471401-5dd897b3-23c0-4948-81b8-c46b97bf5178.JPG)

![ClubHouseListUsers](https://user-images.githubusercontent.com/91097715/167471424-463dfe25-d149-4214-b7d5-c21bb1d51fc3.JPG)


<![ClubHouseEditUser](https://user-images.githubusercontent.com/91097715/167471429-f74ae533-a31c-4fd4-882b-4a85e2734ae9.JPG)


-->
