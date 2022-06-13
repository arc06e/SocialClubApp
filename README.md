# SocialClubApp

## The Clubhouse
See it up and running: https://socialclubapp.azurewebsites.net/


## Description

Welcome to the ClubHouse! I built this MVC ASP.NET Core app in .NET 6 in order to better acquaint myself with ASP.NET Core's Identity Framework. It is a web app that allows users to create and manage social clubs and events in their area devoted to their shared interests. Through designing and building this app, I was able to learn about key features of the Identity Framework--such as authentication and authorization--and the ways in which you can restrict user access to parts of the app through assigning roles and claims in order to create a more secure app.

## Current Features
* Seeds database with sample data to demonstrate app's key features.
* Identity membership system:
  * Allows you to manage users, roles, and claims
    * Utilizes role-and-claim-based authorization to determine which users can access which pages and alter db data.    
* CRUD functionality:
  * Allows users with appropriate authorization to create, read, update, and delete social and events. 
  * Allows users with appropriate authorization to create, read, update, and delete  users, claims, and roles.
* PLeasant UI experience:
  * Easy-to-read and clearly defined web pages to help users navigate the application and use its 
  * Utilizes model validation to ensure users receive detailed feedback to promptly resolve any user input errors or other unintended disruptions.
* Repository Design Pattern:
  * Separates the database access code from the controller actions methods in order to implement more loosely-coupled code and reduce code duplication.   


## Intended Improvements

Going forward, I would like to incorporate geolocation features that tailor results presented to the user according to their general area. I would also like to include search functionality for the user's convenience. Another major feature I would like to add is form of commenting system whereby established members can comment on the various clubs and events in order to track updates and other pertinent details. 


![ClubHouseHomepage](https://user-images.githubusercontent.com/91097715/167471401-5dd897b3-23c0-4948-81b8-c46b97bf5178.JPG)
<!--
![ClubHouseListUsers](https://user-images.githubusercontent.com/91097715/167471424-463dfe25-d149-4214-b7d5-c21bb1d51fc3.JPG)


<![ClubHouseEditUser](https://user-images.githubusercontent.com/91097715/167471429-f74ae533-a31c-4fd4-882b-4a85e2734ae9.JPG)


-->
