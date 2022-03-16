Feature: AddItemToCard
	Add at least one item to a card

	Background:
		Given the following users exist
		  | Username | Email                  | Password   | IsLogged |
		  | elonMusk | elonMusk@tesla.com     | Azerty123& | true     |
		  | billGate | billgate@microsoft.com | Azerty123& | false    |
    
		Given some products exists
		  | Id | Label       | TaxedPrice | TaxRate | StockQuantity |
		  | 1  | Ryzen 5900X | 599        | 20      | 10            |
		  | 2  | Ryzen 5700X | 349        | 20      | 1             |

	Scenario: not logged user should throw exception
		Given an user with email "billgate@microsoft.com"
		When I try to add "1" quantity of "Ryzen 5900X"
		Then I should be notified with "NotLogged" message

	Scenario Outline: logged user add items in is cart
		Given a logged user as "elonMusk@tesla.com"
		When I try to add "<Quantity>" quantity of "<Product>"
		Then I should have correct items in my cart
		And My cart should have total of "<ExpectedTotal>"
		And stock for "<Product>" should be "<ExpectedStockQuantity>"

		Examples:
		  | Product     | Quantity | ExpectedTotal | ExpectedStockQuantity |
		  | Ryzen 5900X | 1        | 599           | 9                     |
		  | Ryzen 5900X | 2        | 1198          | 8                     |

	Scenario: logged user add to much items based on stock
		Given a logged user as "elonMusk@tesla.com"
		When I try to add "2" quantity of "Ryzen 5700X"
		Then I should be notified with "NotEnoughtStock" message