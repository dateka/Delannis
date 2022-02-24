Feature: ShoppingCart
As a logged user, I want to add some product into my shopping cart.

	Background:
		Given the following users exist
		  | UserName | Email                  | Password   |
		  | elonMusk | elonMusk@tesla.com     | Azerty123& |
		  | billGate | billgate@microsoft.com | Azerty123& |
		Given the following products exist
		  | Name      | Price | Quantity |
		  | pull      | 40    | 1        |
		  | pantalon  | 50    | 1        |
		  | tee-shirt | 15    | 2        |
    
	Scenario: Trying to add one product into my shopping cart
		Given a logged user as "elonMusk"
		When I add one "pull" to my shopping cart
		Then The shopping cart should get updated
		
	Scenario: Trying to add the same product twice into my shopping cart
		Given a logged user as "elonMusk"
		When I add "tee-shirt" twice to my shopping cart
		Then The shopping cart quantity should be two and the price should be twice the initial price
		
	Scenario: Trying to add two different products into my shopping cart
		Given a logged user as "elonMusk"
		When I add "pull" and "pantalon" to my shopping cart
		Then The shopping cart should get updated
		
	Scenario: Trying to remove one product from my shopping cart
		Given a logged user as "elonMusk"
		When I remove one "pull" from my shopping cart
		Then The shopping cart should get updated