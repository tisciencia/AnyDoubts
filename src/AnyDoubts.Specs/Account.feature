#Visitors should be in control of creating an account

Feature: Creating an account
  As an anonymous user
  I want to be able to create an account  

#
# Account Creation: Get entry form
#
Scenario: Anonymous user can start creating an account
	Given an anonymous user
	When she goes to /signup
	Then she should be at the 'users/new' page
	And  she should see a <form> containing a textfield: Username, textfield: Email,  textfield: Confirm Email, password: Password, password: 'Confirm Password', submit: 'Sign up'
