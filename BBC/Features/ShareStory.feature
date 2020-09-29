Feature: Sharing a story
	In order to contribute to population's awareness regarding coronavirus
	As a user
	I want to be able to share my story with BBC news portal

@negative
Scenario: Submitting a story without filling in "Name" field isn't possible 
	Given I am on the BBC home page
	And I've opened the form in order to share my story

	And I submit my story
	Then I am still on the same page because the submitting wasn't successful
	And I get 1 validation error
	And The first error message is following: "Name can't be blank"

@negative
Scenario: Submitting an empty form isn't possible
    Given I am on the BBC home page
	And I've opened the form in order to share my story
	When I submit my story
	Then I am still on the same page because the submitting wasn't successful
	And I get 4 validation error
	And The first error message is following: "can't be blank"
	And The second error message is following: "Name can't be blank"
	And The third error message is following: "must be accepted"
	And The fourth error message is following: "must be accepted"


	@negative
Scenario: Submitting a story without agreeing to terms isn't possible
    Given I am on the BBC home page
	And I've opened the form in order to share my story

	And I submit my story
	Then I am still on the same page because the submitting wasn't successful
	And I get 1 validation error
	And The first error message is following: "must be accepted"

	@negative
Scenario: Submitting a story using invalid email isn't possible
    Given I am on the BBC home page
	And I've opened the form in order to share my story

	And I submit my story
	Then I am still on the same page because the submitting wasn't successful
	And I get 1 validation error
	And The first error message is following: "Email address is invalid"

	@negative
Scenario: Submitting a story without entering any message into a text field isn't possible
    Given I am on the BBC home page
	And I've opened the form in order to share my story

	Then I am still on the same page because the submitting wasn't successful
	And I get 1 validation error
	And The first error message is following: "can't be blank"

