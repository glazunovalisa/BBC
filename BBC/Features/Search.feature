Feature: Search
	In order to find only relevant articles
	As a user
	I want to be able to look up articles by keyword


Scenario: Look up articles by keyword 
	Given I am on the BBC home page
	When I click on News Tab
	And I copy the text of the category link of the headline article (World)
	And I paste copied keyword into a search field
	And I click on Search button
	Then The first article's name should contain my keyword
