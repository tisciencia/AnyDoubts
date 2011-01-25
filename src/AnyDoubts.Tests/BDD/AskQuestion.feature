Feature: Asking
    Qualquer pessoa que acessar o site poderá realizar perguntas.


Scenario: Browse to ask a question
	When the user goes to the home screen
	Then the ask page view should be displayed

Scenario: Ask Question
    Given I access the site
    And I ask a question
    When I press send
    Then the result should be a question asked