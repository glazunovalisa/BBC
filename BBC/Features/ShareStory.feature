Feature: Sharing a story
	In order to contribute to population's awareness regarding coronavirus
	As a user
	I want to be able to share my story with BBC news portal

	@negative
Scenario: Submitting a story without filling in "Name" field isn't possible 
	Given I am on the BBC home page
	And I've opened the form in order to share my story
	When I enter the text of my story
	And I enter a valid email
	And I enter a phone number
	And I enter a location
	And I confirm that I'm over 16
	And I accept terms and conditions
	And I submit my story
	Then I am still on the same page because the submitting wasn't successful
	And I get 1 validation error
	And The error message is following: "Name can't be blank"