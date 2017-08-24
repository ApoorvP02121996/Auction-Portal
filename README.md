# Auction-Portal
Auction portal for college auctions

This project is developed for handling lost-and-found item auctions held in certain colleges.
It aims to provide an elegant, utilitarian system to abet people with aforementioned auctions.
The principal actors in this application are sellers/auctioneer and buyers/bidders.

This application provides full maintenance and auctioning privileges to the seller/auctioneer.
They can add items to the auction, remove items from the auction, finalize bids, sell items, etcetera.
The buyer’s role is implemented in an easy, intuitive manner, thereby providing a superior comprehension of the software.
The buyer must initially login, or create an account with their credentials.
Upon doing so successfully, they can view, bid or buy items.
The login for bidders and auctioneers will be distinct.
There will be extensive record storage for auction items.

The functionalities implemented are:
  1. Login/Sign-up for both types of accounts (auctioneers and bidders)
  2. With respect to the auctioneer:
     1. Adding items
     2. Removing items
     3. Finalizing/Closing bids
     4. Acknowledging the buyer(s)
     5. Selling items
     6. Etcetera
  3. With respect to bidders:
     1. Viewing items
     2. Bidding on items
     3. Paying for item(s)
     4. Etcetera

The database tables used are:
  1. Credentials: The login credentials of all users
  2. Auctioneer: Information about the auctioneers such as their ID, name, etcetera
  3. Bidder: Information about the bidders such as their ID, name, etcetera
  4. Current Items: Details of the items currently on auction
  5. Sold Items: Details of the items which have been sold via auction
  6. Item History: Record of the bids on all items
 
The front-end for the application is created using Visual C#, and the back-end implemented using MySQL.
