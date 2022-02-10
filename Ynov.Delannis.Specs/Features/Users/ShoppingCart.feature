Feature: ShoppingCart
As a logged user, I want to add some product into my shopping cart.

	Background:
		Given the following users exist
		  | UserName | Email                  | Password   |
		  | elonMusk | elonMusk@tesla.com     | Azerty123& |
		  | billGate | billgate@microsoft.com | Azerty123& |
    
	Scenario: Trying to add a product into my shopping cart
		Given a logged user as "elonMusk"
		When I add a product to my shopping cart
		Then The shopping cart should get updated
		
	Scenario: Trying to add the same product into my shopping cart
		Given a logged user as "elonMusk"
		When I add the same product to my shopping cart
		Then The shopping cart should get updated with the right price and quantity
		
	Scenario: Trying to add different product into my shopping cart
		Given a logged user as "elonMusk"
		When I add different product to my shopping cart
		Then The shopping cart should get updated
		
	Scenario: Trying to remove a product from my shopping cart
		Given a logged user as "elonMusk"
		When I remove a product from my shopping cart
		Then The shopping cart should get updated
		
	Scenario: Trying to remove all product from my shopping cart
		Given a logged user as "elonMusk"
		When I remove all product from my shopping cart
		Then The shopping cart should be empty