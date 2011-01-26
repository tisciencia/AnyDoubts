Feature: List a user's answered questions
	In order to satisfy my curiosity about a given user
	As a visitor of the site
	I want to see all the questions answered by that user

Scenario: Listing the questions for a user that has no answered questions
	Given I am a visitor
	And There is a user called "vintem"
	And the user "vintem" has no answered questions
	When I visit "vintem"'s profile  page
	Then I should see "The user has not answered any questions"
