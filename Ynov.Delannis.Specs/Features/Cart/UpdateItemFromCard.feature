Feature: UpdateItemFromCard
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

        Given user already have items
          | Email               | Name        | TaxedPrice | TaxRate | Quantity |
          | alexandre@gmail.com | Ryzen 5900X | 599        | 20      | 1        |
          | johndoe@gmail.com   | Ryzen 5700X | 349        | 20      | 1        |

    Scenario: not logged user should throw exception
        Given an user with email "billgate@microsoft.com"
        When I try to update "Ryzen 5900X" by 2
        Then I should be notified with "NotLogged" message

    Scenario: logged user update cart item quantity but not exist in cart
        Given a logged user as "elonMusk@tesla.com"
        When I try to update "Ryzen 5700X" by 2
        Then I should be notified with "CartDoesNotContainItem" message

    Scenario: logged user update cart item quantity
        Given a logged user as "elonMusk@tesla.com"
        When I try to update "Ryzen 5900X" by 2
        Then I should have correct items in my cart
        And My cart should have total of "1797"
        And stock for "Ryzen 5900X" should be "8"

    Scenario: loggued user update to much items based on stock
        Given a logged user as "elonMusk@tesla.com"
        When I try to add "12" quantity of "Ryzen 5900X"
        Then I should be notified with "NotEnoughtStock" message

    Scenario: logged user update cart item quantity to zero to delete it
        Given a logged user as "elonMusk@tesla.com"
        When I try to update "Ryzen 5900X" by -1
        Then I should have correct items in my cart
        And My cart should have total of "0"
        And stock for "Ryzen 5900X" should be "11"