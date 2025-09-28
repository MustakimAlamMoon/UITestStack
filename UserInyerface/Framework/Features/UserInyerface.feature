Feature: UserInyerface

Scenario: Card Data Checking
	Given the welcome page is opened
    When I click the link 'Please click HERE to GO to the next page'
    Then the '1' card is open
    When I input random valid password, email, domain, top level domain, accept the terms of use and click 'Next' button
    Then the '2' card is open
    When I choose '3' random interests, upload image and click 'Next' button
    Then the '3' card is open 

Scenario: Hide Help Form
    Given the welcome page is opened
    When I click the link 'Please click HERE to GO to the next page'
    Then the '1' card is open
    When I hide help form
    Then form content is hidden

Scenario: Accept Cookies
    Given the welcome page is opened
    When I click the link 'Please click HERE to GO to the next page'
    Then the '1' card is open
    When I accept cookies
    Then form is closed

Scenario: Validate Timer
    Given the welcome page is opened
    When I click the link 'Please click HERE to GO to the next page'
    Then the '1' card is open
    And I validate that timer starts from '00:00'
