Feature: UserLogin
As a logged user, I want to log to my account.

    Background:
        Given the following users exist
          | Email                  | Password   |
          | elonMusk@tesla.com     | Azerty123& |
          | billgate@microsoft.com | Azerty123& |
    
    Scenario: Trying to log into my account as logged user
        Given a logged user as "elonMusk"
        And my login information
          | Email              | Password   |
          | elonMusk@tesla.com | Azerty123& |
        When I log into my account
        Then I should be notified with "CantLogAccountWhenLogged" message
		
    Scenario: Trying to log into my account with non-existent email
        Given my login information
          | Email            | Password   |
          | damien@tesla.com | Azerty123& |
        When I log into my account
        Then I should be notified with "UserNotFound" message
		
    Scenario: Trying to log an account with bad password
        Given my login information
          | Email              | Password   |
          | elonMusk@tesla.com | Azerty124& |
        When I log into my account
        Then I should be notified with "UserNotFound" message
    
    Scenario: User log into his account successfully
        Given my login information
          | Email              | Password   |
          | elonMusk@tesla.com | Azerty123& |
        When I log into my account
        Then I should be connect