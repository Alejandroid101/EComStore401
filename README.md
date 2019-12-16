# Ecom Project
*Author: Biniam Tesfamariam* & *Enrique Rivera De Leon*    

#### What is the product you are selling?  
- The products we are selling on our site are, luxury cars.    
#### What claims are you capturing? Where? Why?  
- The claims we have created are, fullname, email, dob, and country. The fullname is claim that uses
the user input for first name and last name and stores it in the fullname claim. We are doing this during registration
to be able to show the full name of the user once they login. This will indicate to the user that they have successfully logged 
in with their account. The email claim is used to create a username for the application user. We will be using the user's input for their email
as their username since we can guarantee that its unique. We also do this during registration. The dob claim is a claim that is requesting the date of birth
of our application user. We are also doing this during registration. We created this claim because we want to have age restrictions later on and only
allow those above a certain age to access our site. Lastly, we created a country claim to be able to access the application user's location. We did this to be able
to get more information from our user and possibly send messages to users from specific countries. This claim is also taking place during registration.

#### Structure/Database Schema for store DB (not identity)  
![MyImage.png](https://dev.azure.com/Biniam-Enrique401ECom/c6a39389-7db6-452b-b285-1faf58ec21f1/_apis/git/repositories/78bf6ad1-d773-4add-aa30-5ac9b4cd81ea/Items?path=%2FSchema.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=Development&download=false&resolveLfs=true&%24format=octetStream&api-version=5.0-preview.1)


#### Explanation of your DB Schema (mostly interested in your basket/order tables)  
We haven't fully finished Sprint 2 however, we did create the table for the "basket". We decided to follow the ERD given to us by Amanada. Our basket which we named
"Cart" has a primary key and the userId. We do this inorder to create the foreign key in our "cartItems" table. So that whenever a user want to add an item to their cart 
we can successfully link the item to the correct cart for the user. As for the order table, we haven't created that yet however, we plan on doing that with our next submission.
We will create an "order" table and an "orderItems" table to keep track of all the orders for a user and all the items they've ordered thus far.

#### Vulnerability Report
https://github.com/biniamsea2/EcomStore/blob/Development/vulnerability-report.md

#### Link to your deployed website.  
https://ecom20191126124500.azurewebsites.net