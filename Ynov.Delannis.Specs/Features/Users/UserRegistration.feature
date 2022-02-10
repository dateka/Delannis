Feature: UserRegistration
As a visitor, I want to create an account, so that I can be logged in.

    Background:
        Given the following users exist
          | UserName | Email                  | Password   |
          | elonMusk | elonMusk@tesla.com     | Azerty123& |
          | billGate | billgate@microsoft.com | Azerty123& |

    Scenario: Trying to create an account as logged user
        Given a logged user as "elonMusk"
        And my registration information
          | UserName | Email              | Password   |
          | elonMusk | elonMusk@tesla.com | Azerty123& |
        When I create an account
        Then I should be notified with "CantCreateAccountWhenLogged" message

    Scenario Outline: Trying to create an account with bad password
        Given my registration information
          | UserName     | Email          |
          | alexTeixeira | alex@gmail.com |
        And I set an unvalid password "<Password>"
        When I create an account
        Then I should be notified with "UnvalidPassword" message

        Examples:
          | Password |
          | Azert    |
          | Azerty1  |
          | Azerty&  |
          | azerty1& |
          |          |

    Scenario Outline: Trying to create an account with bad email
        Given my registration information
          | UserName     | Password   |
          | alexTeixeira | Azerty123& |
        And I set an unvalid email "<Email>"
        When I create an account
        Then I should be notified with "UnvalidEmail" message

        Examples:
          | Email         |
          | alex          |
          | alex@gmail    |
          | alex@gmail.   |
          | alexgmail.com |
          |               |

    Scenario Outline: Trying to create an account with bad userName
        Given my registration information
          | Password   | Email          |
          | Azerty123& | alex@gmail.com |
        And I set an unvalid userName "<UserName>"
        When I create an account
        Then I should be notified with "UnvalidUsername" message

        Examples:
          | UserName |
          | Aze      |
          | Azer&    |
          |          |

    Scenario Outline: Trying to create an account with an existing email
        Given my registration information
          | UserName     | Email              | Password   |
          | alexTeixeira | elonMusk@tesla.com | Azerty123& |
        When I create an account
        Then I should be notified with "EmailAlreadyExist" message

    Scenario Outline: Trying to create an account with an existing userName
        Given my registration information
          | UserName | Email           | Password   |
          | elonMusk | alex1@gmail.com | Azerty123& |
        When I create an account
        Then I should be notified with "UserNameAlreadyExist" message
        
    Scenario Outline: User create an account successfully
      Given my registration information
        | UserName | Email            | Password   |
        | damien02 | damien@gmail.com | Azerty123& |
      When I create an account
      Then I should have an account