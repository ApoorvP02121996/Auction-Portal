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
  Login/Sign-up for both types of accounts (auctioneers and bidders)
    With respect to the auctioneer:
      Adding items
      Removing items
      Finalizing/Closing bids
      Acknowledging the buyer(s)
      Selling items
      Etcetera
    With respect to bidders:
      Viewing items
      Bidding on items
      Paying for item(s)
      Etcetera

The database tables used are:
  Credentials: The login credentials of all users
  Auctioneer: Information about the auctioneers such as their ID, name, etcetera
  Bidder: Information about the bidders such as their ID, name, etcetera
  Current Items: Details of the items currently on auction
  Sold Items: Details of the items which have been sold via auction
  Item History: Record of the bids on all items
 
The front-end for the application is created using Visual C#, and the back-end implemented using MySQL.
