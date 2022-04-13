Feature: EmptyCard
	Empty user cart

	Background:
		Given the following users exist
		  | Username | Email                  | Password   | IsLogged |
		  | elonMusk | elonMusk@tesla.com     | Azerty123& | true     |
		  | billGate | billgate@microsoft.com | Azerty123& | false    |

		Given some products exists
		  | Id | Label       | TaxedPrice | TaxRate | StockQuantity |
		  | 1  | Ryzen 5900X | 599        | 20      | 10            |
		  | 2  | Ryzen 5700X | 349        | 20      | 1             |

		Given user already have items
		  | Email                  | Name        | TaxedPrice | TaxRate | Quantity |
		  | elonMusk@tesla.com     | Ryzen 5900X | 599        | 20      | 1        |
		  | billgate@microsoft.com | Ryzen 5700X | 349        | 20      | 1        |

	Scenario: not logged user should throw exception
		Given an user with email "elonMusk@tesla.com"
		When I try to empty my cart
		Then I should be notified with "NotLogged" message

	Scenario: logged user update cart item quantity
		Given a logged user with email "elonMusk@tesla.com"
		When I try to empty my cart
		Then my cart should be empty
		And stock for "Ryzen 5900X" should be "11"