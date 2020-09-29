Feature: Sharing a story
	In order to contribute to population's awareness regarding coronavirus
	As a user
	I want to be able to share my story with BBC news portal


Background:  
   Given I am on the BBC home page
   And I've opened the form in order to share my story



@negative @emptyname
Scenario: After submitting a story without filling out name field I'm still on the same page
    When I fill out the form without entering my name
	Then I am still on the same page because the submitting wasn't successful

@negative @emptyname
Scenario: Sumbitting a story without filling out name field results in 1 validation error
    When I fill out the form without entering my name
	Then I get 1 validation error(s)
	And The first error message is following: "Name can't be blank"

	
@negative @emptyform
Scenario: After submitting an empty field I'm still on the same page
	When I submit my story
	Then I am still on the same page because the submitting wasn't successful

@negative @emptyform
Scenario: Submitting an empty story results in 4 validation errors
    When I submit my story
  	Then  I get 4 validation error(s)
	And The first error message is following: "can't be blank"
	And The second error message is following: "Name can't be blank"
	And The third error message is following: "must be accepted"
	And The fourth error message is following: "must be accepted"


@negative @noterms
Scenario: After submitting a story without agreeing to terms I'm still on the same page
    When I fill out the fowm without agreeing to terms 
	Then I am still on the same page because the submitting wasn't successful

@negative @noterms
Scenario: Sumbitting a story without agreeing to terms results in 1 validation error
    When I fill out the fowm without agreeing to terms
	Then I get 1 validation error(s)
	And The first error message is following: "must be accepted"


@negative @invalidemail
Scenario: After submitting a story using invalid email I'm still on the same page
    When I fill out the worm using using invalid email
	Then I am still on the same page because the submitting wasn't successful

@negative @invalidemail
Scenario: Sumbitting a story using invald email results in 1 validation error
    When I fill out the worm using using invalid email
	Then I get 1 validation error(s)
	And The first error message is following: "Email address is invalid"


@negative @nostory
Scenario: After submitting a story with empty message field I'm still on the same page
    When I fill out the form without entering any message into text field
	Then I am still on the same page because the submitting wasn't successful

@negative @nostory
Scenario: Sumbitting a story with empty message field results in 1 validation error
    When I fill out the form without entering any message into text field
	Then I get 1 validation error(s)
	And The first error message is following: "can't be blank"
