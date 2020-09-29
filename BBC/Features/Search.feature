Feature: Search
	In order to find only relevant articles
	As a user
	I want to be able to look up articles by keyword


Scenario: Look up articles by keyword 
	Given I am on the BBC home page
	When I click on News Tab
	And Copy the text of headline article's category
	And Search articles by pasting copied word into a search field
	Then The first article's name should contain my keyword
